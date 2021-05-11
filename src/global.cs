using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Management;
using System.Net.Sockets;
using System.Net;
namespace MinecraftServerClient
{
    public static class global
    {
        public const string PropertiesPath = "server.properties";
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public static void UpdateServerPropery(string property, string newvalue)
        {
            string[] lines = File.ReadAllLines(PropertiesPath);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith(property))
                {
                    lineChanger($"{property}={newvalue}", PropertiesPath, i + 1);
                    return;
                }
            }
        }

        public static void KillProcessAndChildren(int pid)
        {
            // Cannot close 'system idle process'.
            if (pid == 0)
            {
                return;
            }
            ManagementObjectSearcher searcher = new ManagementObjectSearcher
                    ("Select * From Win32_Process Where ParentProcessID=" + pid);
            ManagementObjectCollection moc = searcher.Get();
            foreach (ManagementObject mo in moc)
            {
                KillProcessAndChildren(Convert.ToInt32(mo["ProcessID"]));
            }
            try
            {
                Process proc = Process.GetProcessById(pid);
                proc.Kill();
            }
            catch (ArgumentException)
            {
                // Process already exited.
            }
        }

        public static string GetServerProperty(string property)
        {

            string[] lines = File.ReadAllLines(PropertiesPath);

            foreach (string prop in lines)
            {
                if (prop.StartsWith(property))
                {
                    return prop.Split('=')[1];
                }
            }
            return null;
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }


        public static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }

        public static string GetCommandLine(Process process)
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + process.Id))
            using (ManagementObjectCollection objects = searcher.Get())
            {
                return objects.Cast<ManagementBaseObject>().SingleOrDefault()?["CommandLine"]?.ToString();
            }
        }

        public static bool IsServerRunning
        {
            get
            {
               // MineStatLib.MineStat minestat = new MineStatLib.MineStat("127.0.0.1", (ushort)GetPort(PortTypes.Server), 500);

                //return minestat.ServerUp;
                
                foreach (Process proc in Process.GetProcessesByName("java"))
                {
                    if (GetCommandLine(proc).Contains(Config.CurrentConfig.launchargs))
                    {
                        return true;
                    }
                    
                }
                return false;
            }
        }

        public enum PortTypes
        {
            Server,
            Rcon
        }

        public static int GetPort(PortTypes port)
        {
            if (port == PortTypes.Rcon)
            {
                return int.Parse(GetServerProperty("rcon.port"));
               // return 25575;
            }
            if (port == PortTypes.Server)
            {
                return int.Parse(GetServerProperty("server-port"));
                //return 25565;
            }
            return 0;
        }
        

        public static void StopServer()
        {
            Process[] serverproc = Process.GetProcessesByName("java");

                foreach (Process proc in serverproc)
                {
                if (!proc.HasExited)
                {
                    if (GetCommandLine(proc).Contains("--nogui"))
                    {
                        proc.Kill();
                    }
                }
                }
        }


        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnop";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
