using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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

            
            if (File.Exists("server-icon.png"))
            {
                //Image.FromFile("server-icon.png"); // Image fromfile locks the image to process so file stream does it nicely  //https://social.msdn.microsoft.com/Forums/vstudio/en-US/d08397c3-94b9-4f47-8095-c701a8dd63b1/how-can-i-work-around-the-fact-tha-imagefromfile-locks-the-file?forum=csharpgeneral
                using (FileStream stream = new FileStream("server-icon.png", FileMode.Open, FileAccess.Read))
                    pictureBox1.Image = Image.FromStream(stream);
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
            new InfoDialog(serverproperties.SelectedItem.ToString(), this).ShowDialog();
        }
        public void UpdateSettingsBox()
        {
            if (File.Exists(global.PropertiesPath))
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
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (global.GetServerProperty("enable-rcon") != "true")
            {
                MessageBox.Show("Enabled-rcon MUST be set to true");
                return;
            }

            if (global.GetServerProperty("rcon.password").Length < 1)
                global.UpdateServerPropery("rcon.password", global.RandomString(10));


            new ServerUI(this, bool.Parse(global.GetServerProperty("enable-rcon"))).ShowDialog();
        }
        private void launchargs_TextChanged(object sender, EventArgs e)
        {
            Config.CurrentConfig.launchargs = launchargs.Text;
            Config.SaveConfig();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog a = new OpenFileDialog())
            {
                a.Title = "Select the server icon";

                if (a.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists("server-icon.png"))
                        File.Delete("server-icon.png");
                    Bitmap servericon = global.ResizeImage(Image.FromFile(a.FileName), 64,64);
                    
                    servericon.Save("server-icon.png", ImageFormat.Png);

                    pictureBox1.Image = servericon;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new DiscordUI(this).ShowDialog(); 
        }
    }
}
