using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Net;
using Discord.WebSocket;
using System.Diagnostics;
using System.Management;

namespace MinecraftServerClient.DiscordBot
{
    class Bot
    {
        public static void StartBot()
        {
            if (Config.CurrentConfig.BotToken != "NONE" && Config.CurrentConfig.BotToken.Length > 10) new Bot().MainAsync().GetAwaiter().GetResult();
        }

        public static DiscordSocketClient _client = new DiscordSocketClient();



        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();

            //_client.Log += Log;
            _client.MessageUpdated += MessageUpdated;
            _client.MessageReceived += MessageReceived;
            await _client.LoginAsync(TokenType.Bot, Config.CurrentConfig.BotToken);
            await _client.StartAsync();
            await Task.Delay(-1);
        }

        public static async Task SendMsgAsync(string msg)
        {
            if (msg.Contains("Rcon connection from: /127.0.0.1"))
                return;

            try
            {
                if (Config.CurrentConfig.LastChannel.ToString().Length > 1)
                {
                    var chnl = _client.GetChannel(Config.CurrentConfig.LastChannel) as IMessageChannel; // 4
                    await chnl.SendMessageAsync("`" + msg + "`"); // 5
                }
            }
            catch
            {

            }
            

        }

        private Task MessageUpdated(Cacheable<IMessage, ulong> before, SocketMessage after, ISocketMessageChannel channel)
        {
            Console.WriteLine(after.ToString());
            return Task.CompletedTask;
        }

        private async Task MessageReceived(SocketMessage message)
        {
            if (message.Author.IsBot)
                return;
            string response = message.Content;
            Config.CurrentConfig.LastChannel = message.Channel.Id;
            Config.SaveConfig();
            if (response == "!!status")
            {

                MineStatLib.MineStat minestat = new MineStatLib.MineStat("127.0.0.1", (ushort)global.GetPort(global.PortTypes.Server), 500);

                if (minestat.ServerUp)
                {
                    EmbedBuilder builder = new EmbedBuilder();

                    builder.WithTitle($"Server Status for {minestat.Motd}");
                    builder.AddField("Players:", $"{minestat.CurrentPlayers}/{minestat.MaximumPlayers}", true);
                    builder.AddField("Version: ", minestat.Version, true);
                    builder.AddField("RAM: ", CurrentServerRAM(), true);
                    builder.WithColor(Color.Red);
                    await message.Channel.SendMessageAsync("", false, builder.Build());
                }
                else
                {
                    await message.Channel.SendMessageAsync("Server is not running!");
                }
                return;
            }
            if (response.StartsWith("!!"))
            {
                response = response.Remove(0, 2);//Removes the first char
                Console.WriteLine(response);
                await message.Channel.SendMessageAsync(SendCmd(response));
                return;
            }

        }

        private string CurrentServerRAM()
        {
            long ram = 0;
            foreach (Process proc in Process.GetProcessesByName("java"))
            {
                    if (global.GetCommandLine(proc).Contains(Config.CurrentConfig.launchargs))
                    {
                        ram += proc.WorkingSet64;
                    }
            }
            return BytesAsString(ram);
        }

        //https://stackoverflow.com/a/19674451/12897035
        public static string BytesAsString(float bytes)
        {
            string[] suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double doubleBytes = 0;

            for (i = 0; (int)(bytes / 1024) > 0; i++, bytes /= 1024)
            {
                doubleBytes = bytes / 1024.0;
            }

            return string.Format("{0:0.00} {1}", doubleBytes, suffix[i]);
        }


        private string SendCmd(string cmd)
        {
                if (global.IsServerRunning && ServerUI.UsingRcon)
                {
                    // Create a new client and connect to the server.
                    RCON client = new RCON("127.0.0.1", global.GetPort(global.PortTypes.Rcon));

                    // Send some commands.
                    // Commands use the Try-Parse pattern for error handling instead of throwing Exceptions.
                    // Pass a Message by reference to get a bool return value indicating success or failure.
                    // The Sockets library can still raise Exceptions you'd want to catch (e.g. connection failures).
                    if (!client.Authenticate(global.GetServerProperty("rcon.password"))) { /* handle authentication error */ };

                    Message resp;
                    
                    if (!client.SendCommand(cmd, out resp)) { };
                    // Cleanly disconnect when finished.
                    client.Close();
                    return resp.Body;
                }
                else
                {
                    return "Please enable RCON in server properties or server may be offline";
                }
            
        }
    }
}
