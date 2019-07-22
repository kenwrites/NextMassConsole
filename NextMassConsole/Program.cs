using System;

namespace NextMassConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Config config = new Config();

            //ConfigFile configFile = new ConfigFile();
            //configFile.BaseConnectionString = "(local)\\SQLExpress";
            //configFile.UserName = "sa";
            //configFile.Password = "LovelyB123!";

            //config.WriteConfigFile(configFile, "config.json");

            ConfigFile configuration = config.ReadConfigFile("config.json");
            Console.ReadKey(true);

        }
    }
}
