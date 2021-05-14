using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace MinecraftServerClient
{
    class Config
    {
        private const string ConfigPath = "config.json";
        
        public static ConfigObj CurrentConfig;

        public static void InitConfig()
        {
            if (!File.Exists(ConfigPath))
                File.WriteAllText(ConfigPath, ToJson(new ConfigObj()));

            CurrentConfig = FromJSON<ConfigObj>(File.ReadAllText(ConfigPath));
        }

        public static void SaveConfig()
        {
            File.WriteAllText(ConfigPath, ToJson(CurrentConfig));
        }

        public static T FromJSON<T>(string json)//Make a json string to obj
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        public static string ToJson(Object config)//Make obj to json string
        {
            return JsonConvert.SerializeObject(config);
        }

        public class ConfigObj
        {
            public string launchargs { get; set; } = "-Xmx1024M -Xms1024M -jar server.jar --nogui";
            public string BotToken { get; set; } = "";
            public bool UsingDiscord { get; set; } = false;
            public ulong LogChannel { get; set; } = 0;
            public ulong ChatChannel { get; set; } = 0;
        }

    }
}
