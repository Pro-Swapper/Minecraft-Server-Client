using System;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using System.Text;
namespace MinecraftServerClient
{
	//https://github.com/willroberts/minecraft-client-csharp/blob/main/src/MinecraftClient/Client.cs
	public class RCON
	{
		private const int MaxMessageSize = 4110; // 4096 + 14 bytes of header data.

		private TcpClient client;
		private NetworkStream conn;
		private int lastID = 0;
		public RCON(string host, int port)
		{
			client = new TcpClient(host, port);
			conn = client.GetStream();
		}

		public void Close()
		{
			conn.Close();
			client.Close();
		}

		public bool Authenticate(string password)
		{
			Message resp;
			return sendMessage(new Message(
				password.Length + Encoder.HeaderLength,
				Interlocked.Increment(ref lastID),
				MessageType.Authenticate,
				password
			), out resp);
		}

		public bool SendCommand(string command, out Message resp)
		{
			return sendMessage(new Message(
				command.Length + Encoder.HeaderLength,
				Interlocked.Increment(ref lastID),
				MessageType.Command,
				command
			), out resp);
		}

		private bool sendMessage(Message req, out Message resp)
		{
			// Send the message.
			byte[] encoded = Encoder.EncodeMessage(req);
			conn.Write(encoded, 0, encoded.Length);

			// Receive the response.
			byte[] respBytes = new byte[MaxMessageSize];
			int bytesRead = conn.Read(respBytes, 0, respBytes.Length);
			Array.Resize(ref respBytes, bytesRead);

			// Decode the response and check for errors before returning.
			resp = Encoder.DecodeMessage(respBytes);
			if (req.ID != resp.ID) { return false; };
			return true;
		}
	}

	//https://github.com/willroberts/minecraft-client-csharp/blob/main/src/MinecraftClient/MessageEncoder.cs
	public enum MessageType : int
	{
		Response,
		_,
		Command,
		Authenticate
	}

	public readonly struct Message
	{
		public readonly int Length;
		public readonly int ID;
		public readonly MessageType Type;
		public readonly String Body;

		public Message(int length, int id, MessageType type, String body)
		{
			Length = length;
			ID = id;
			Type = type;
			Body = body;
		}
	}

	public class Encoder
	{
		public const int HeaderLength = 10; // Does not include 4-byte message length.

		public static byte[] EncodeMessage(Message msg)
		{
			List<byte> bytes = new List<byte>();

			bytes.AddRange(BitConverter.GetBytes(msg.Length));
			bytes.AddRange(BitConverter.GetBytes(msg.ID));
			bytes.AddRange(BitConverter.GetBytes((int)msg.Type));
			bytes.AddRange(Encoding.ASCII.GetBytes(msg.Body));
			bytes.AddRange(new byte[] { 0, 0 });

			return bytes.ToArray();
		}

		public static Message DecodeMessage(byte[] bytes)
		{
			int len = BitConverter.ToInt32(bytes, 0);
			int id = BitConverter.ToInt32(bytes, 4);
			int type = BitConverter.ToInt32(bytes, 8);

			int bodyLen = bytes.Length - (HeaderLength + 4);
			if (bodyLen > 0)
			{
				byte[] bodyBytes = new byte[bodyLen];
				Array.Copy(bytes, 12, bodyBytes, 0, bodyLen);
				Array.Resize(ref bodyBytes, bodyLen);
				return new Message(len, id, (MessageType)type, Encoding.ASCII.GetString(bodyBytes));
			}
			else { return new Message(len, id, (MessageType)type, ""); }
		}
	}
}
