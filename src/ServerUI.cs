using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
namespace MinecraftServerClient
{
    public partial class ServerUI : Form
    {
        public ServerUI(Form originalform, bool rcon)
        {
            InitializeComponent();
            Region = Region.FromHrgn(global.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            originf = originalform;
            originf.Hide();
            UsingRcon = rcon;
            
            if (!rcon)
            {
                rconsend.Visible = false;
                rconbox.Visible = false;
            }

            //25565 is default mc port

            string serverport = global.GetPort(global.PortTypes.Server).ToString();

            if (serverport != "25565")
            label1.Text = "IP Address: " + global.GetLocalIPAddress() + ":" + serverport;
            else
             label1.Text = "IP Address: " + global.GetLocalIPAddress();
        }
        public static bool UsingRcon { get; set; }
        public Form originf { get; set; }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                global.ReleaseCapture();
                global.SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (global.IsServerRunning)
            {
                MessageBox.Show("Server is still running! Please stop it first!");
            }
            else
            {
                Hide();
                originf.Show();
                Close();
            }
        }
        private void P_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            if (!string.IsNullOrEmpty(e.Data))
            {
                textBox1.AppendText(e.Data + Environment.NewLine);
                if (DiscordBot.Bot._client.LoginState == Discord.LoginState.LoggedIn)
                    DiscordBot.Bot.SendMsgAsync(e.Data);
            }
        }

        private static Thread _botthread = new Thread(DiscordBot.Bot.StartBot);

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (_botthread.IsAlive)
                _botthread.Abort();

            _botthread = new Thread(DiscordBot.Bot.StartBot);
            _botthread.Start();
            textBox1.Clear();
            if (!global.IsServerRunning && !server.IsBusy)
                server.RunWorkerAsync();
            else
                MessageBox.Show("Server is already running!");
        }
        
        private void server_DoWork(object sender, DoWorkEventArgs e)
        {
            //java -Xmx1024M -Xms1024M -jar server.jar --nogui

            Process serverproc = new Process();
            serverproc.StartInfo.FileName = "java";
            serverproc.StartInfo.Arguments = Config.CurrentConfig.launchargs;
            serverproc.StartInfo.RedirectStandardOutput = true;
            serverproc.StartInfo.UseShellExecute = false;
            serverproc.StartInfo.CreateNoWindow = true;
            serverproc.OutputDataReceived += new DataReceivedEventHandler(P_OutputDataReceived);
            serverproc.Start();
            serverproc.BeginOutputReadLine();
        }

        private void SendCmd(string cmd)
        {
            if (UsingRcon)
            {
                if (global.IsServerRunning)
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
                    textBox1.Text += resp.Body + Environment.NewLine;
                    // Cleanly disconnect when finished.
                    client.Close();
                }
                else
                {
                    MessageBox.Show("Server isnt running!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (global.IsServerRunning)
            {
                SendCmd("stop");
                MessageBox.Show("Server stopped!");
            }
            else
            {
                MessageBox.Show("Server is not running!");
            }
            if (DiscordBot.Bot._client.LoginState == Discord.LoginState.LoggedIn)
                DiscordBot.Bot._client.StopAsync();

            if (_botthread.IsAlive)
                _botthread.Abort();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SendCmd(rconbox.Text);
            rconbox.Clear();
        }


        private void rcon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                button4_Click(this, new EventArgs());
            }
        }

        private void Run_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (global.IsServerRunning)
            {
                MessageBox.Show("Server is still running!");
                e.Cancel = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            MineStatLib.MineStat minestat = new MineStatLib.MineStat("127.0.0.1", (ushort)global.GetPort(global.PortTypes.Server), 500);

            if (minestat.ServerUp)
            {
                MessageBox.Show($"Server Info for :{minestat.Motd}\nPlayers: {minestat.CurrentPlayers}/{minestat.MaximumPlayers}\nVersion: {minestat.Version}");
            }
            else
            {
                MessageBox.Show("Server is not running");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string serverport = global.GetPort(global.PortTypes.Server).ToString();
            if (serverport != "25565")
                Clipboard.SetText(global.GetLocalIPAddress() + ":" + serverport);
            else
                Clipboard.SetText(global.GetLocalIPAddress());

            MessageBox.Show("Copied Server IP and Port to your clipboard");
        }

        private void ServerUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                SendCmd("stop");
                Thread.Sleep(5000);
            }
            catch
            {
            }
            if (global.IsServerRunning)
            {
                global.StopServer();
            }
        }
        
    }
}
