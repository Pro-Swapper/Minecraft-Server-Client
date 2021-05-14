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
namespace MinecraftServerClient
{
    public partial class InfoDialog : Form
    {
        public InfoDialog(string selecteditem, Form dashboard)
        {
            InitializeComponent();
            DashboardF = dashboard;
            Region = Region.FromHrgn(global.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            string[] data = selecteditem.Split('=');
            configproperty = data[0];

                config = ConfigType.String;
                if (bool.TryParse(data[1], out _))
                {
                    config = ConfigType.Bool;
                    BoolBox.Visible = true;
                    BoolBox.Text = data[1];
                }
                else if (int.TryParse(data[1], out _))
                {
                    config = ConfigType.Int;
                    StringBox.Visible = true;
                    StringBox.Text = data[1];
                    StringBox.MaxLength = 10;
                StringBox.KeyPress += KeyPress;
                }
                else
                {
                    config = ConfigType.String;
                    StringBox.Visible = true;
                    StringBox.Text = data[1];
                }
            
            label1.Text = $"{configproperty} ({config})";
        }
        private Form DashboardF { get; set; }
        private ConfigType config { get; set; }
        private string configproperty { get; set; }

        private enum ConfigType
        {
            Bool,
            Int,
            String
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                global.ReleaseCapture();
                global.SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)=> Close();
        private void button2_Click(object sender, EventArgs e)
        {
            if (config == ConfigType.Bool)
            {
                global.UpdateServerPropery(configproperty, BoolBox.SelectedItem.ToString());
            }
            if (config == ConfigType.String || config == ConfigType.Int)
            {
                global.UpdateServerPropery(configproperty, StringBox.Text);
            }

            //Updates server properties ListBox in Dashboard
            foreach (Control c in DashboardF.Controls)
                if (c.Tag == "ServerProperties")
                {
                    ListBox serverproperties = ((ListBox)c);
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
            Close();
        }

        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }
    }
}
