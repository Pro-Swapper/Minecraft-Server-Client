using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;

namespace MineStatLib
{
	// Originally from https://github.com/FragLand/minestat
	//https://www.nuget.org/packages/MineStat/

	/*MineStatVersion = "1.0.1";
private const ushort dataSize = 512;
private const ushort numFields = 6;
private const int defaultTimeout = 5;
*/

	public class MineStat
	{
		public string Address { get; set; }
		public ushort Port { get; set; }
		public int Timeout { get; set; }
		public string Motd { get; set; }
		public string Version { get; set; }
		public string CurrentPlayers { get; set; }
		public string MaximumPlayers { get; set; }
		public bool ServerUp { get; set; }
		public long Latency { get; set; }
		public MineStat(string address, ushort port, int timeout = 500)
		{
			byte[] array = new byte[512];
			Address = address;
			Port = port;
			Timeout = timeout;
			try
			{
				Stopwatch stopwatch = new Stopwatch();
				TcpClient tcpClient = new TcpClient
				{
					ReceiveTimeout = Timeout
				};
				stopwatch.Start();
				tcpClient.Connect(address, port);
				stopwatch.Stop();
				Latency = stopwatch.ElapsedMilliseconds;
				NetworkStream stream = tcpClient.GetStream();
				byte[] array2 = new byte[]
				{
					254,
					1
				};
				stream.Write(array2, 0, array2.Length);
				stream.Read(array, 0, 512);
				tcpClient.Close();
			}
			catch
			{
				ServerUp = false;
				return;
			}
			if (array == null || array.Length == 0)
			{
				ServerUp = false;
			}
			else
			{
				string[] array3 = Encoding.Unicode.GetString(array).Split("\0\0\0".ToCharArray());
				if (array3 != null && array3.Length >= 6)
				{
					ServerUp = true;
					Version = array3[2];
					Motd = array3[3];
					CurrentPlayers = array3[4];
					MaximumPlayers = array3[5];
				}
				else
				{
					ServerUp = false;
				}
			}
		}
	}
}
