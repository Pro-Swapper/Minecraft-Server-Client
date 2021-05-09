using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
namespace MinecraftServerClient
{
    class Config
    {
        private const string ConfigPath = "config.json";
        private static JavaScriptSerializer js = new JavaScriptSerializer();


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

        public static T FromJSON<T>(string json)
        {
            return js.Deserialize<T>(json);
        }
        public static string ToJson(Object config)
        {
            return js.Serialize(config);
        }

        public class ConfigObj
        {
            public string launchargs { get; set; } = "-Xmx1024M -Xms1024M -jar server.jar --nogui";
            public string BotToken { get; set; } = "NONE";
            public ulong LastChannel { get; set; }
        }

    }
}
