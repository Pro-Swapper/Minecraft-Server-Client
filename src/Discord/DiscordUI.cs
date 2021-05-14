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
using System.Text.RegularExpressions;

namespace MinecraftServerClient
{
    public partial class DiscordUI : Form
    {
        public DiscordUI(Form originalform)
        {
            InitializeComponent();
            Region = Region.FromHrgn(global.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            originf = originalform;
            originf.Hide();
                discordcheckbox.Checked = Config.CurrentConfig.UsingDiscord;
                bottoken.Text = Config.CurrentConfig.BotToken;
                logchannel.Text = Config.CurrentConfig.LogChannel.ToString();
                chatchannel.Text = Config.CurrentConfig.ChatChannel.ToString();
            
        }
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
            //A bit messy but it works

             Config.CurrentConfig.UsingDiscord = discordcheckbox.Checked;


            Config.CurrentConfig.BotToken = bottoken.Text;

            if (logchannel.Text.Length == 0)
                Config.CurrentConfig.LogChannel = 0;
            else
                Config.CurrentConfig.LogChannel = ulong.Parse(logchannel.Text);

            if (chatchannel.Text.Length == 0)
                Config.CurrentConfig.ChatChannel = 0;
            else
                Config.CurrentConfig.ChatChannel = ulong.Parse(logchannel.Text);


            Config.SaveConfig();
            Hide();
            originf.Show();
            Close();
        }

        private void logchannel_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Only allows numbers in text box
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&(e.KeyChar != '.'))
                e.Handled = true;
        }
    }
}
