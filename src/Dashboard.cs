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
namespace MinecraftServerClient
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            Region = Region.FromHrgn(global.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            if (Config.CurrentConfig.BotToken != "NONE")
            {
                discordcheckbox.Checked = true;
                BotTokenlabel.Visible = true;
                bottoken.Visible = true;
                bottoken.Text = Config.CurrentConfig.BotToken;
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                global.ReleaseCapture();
                global.SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateSettingsBox();
            launchargs.Text = Config.CurrentConfig.launchargs;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            global.KillProcessAndChildren(Process.GetCurrentProcess().Id);
            //Process.GetCurrentProcess().Kill();
        }

        private void serverproperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            new InfoDialog(serverproperties.SelectedItem.ToString()).ShowDialog();
        }
        void UpdateSettingsBox()
        {
            serverproperties.Items.Clear();
            string[] settings = File.ReadAllLines(global.PropertiesPath);
            Array.Sort(settings);
            foreach (string setting in settings)
            {
                if (setting.Contains("="))
                {
                    serverproperties.Items.Add(setting);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (global.GetServerProperty("rcon.password").Length < 1)
                global.UpdateServerPropery("rcon.password", global.RandomString(10));


            new ServerUI(this, bool.Parse(global.GetServerProperty("enable-rcon"))).ShowDialog();
        }
        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            UpdateSettingsBox();
        }
        private void launchargs_TextChanged(object sender, EventArgs e)
        {
            Config.CurrentConfig.launchargs = launchargs.Text;
            Config.SaveConfig();
        }

        private void discordcheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (discordcheckbox.Checked)
            {
                BotTokenlabel.Visible = true;
                bottoken.Visible = true;
            }
            else
            {
                Config.CurrentConfig.BotToken = "NONE";
                Config.SaveConfig();
                BotTokenlabel.Visible = false;
                bottoken.Text = "";
                bottoken.Visible = false;
            }   
        }

        private void bottoken_TextChanged(object sender, EventArgs e)
        {
            Config.CurrentConfig.BotToken = bottoken.Text;
            Config.SaveConfig();
        }
    }
}
