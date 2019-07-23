using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NextMassConsole
{
    public class Config : IConfig
    {
        DirectoryInfo _directory = new DirectoryInfo(Directory.GetCurrentDirectory());
        JsonSerializer _serializer = new JsonSerializer();

        public void WriteConfigFile(ConfigFile file, string filename)
        {
            string filePath = Path.Combine(_directory.FullName, filename);

            using (StreamWriter writer = new StreamWriter(filePath))
            using (JsonTextWriter jsonWriter = new JsonTextWriter(writer))
            {
                _serializer.Serialize(jsonWriter, file);
            }
        }

        public ConfigFile ReadConfigFile(string filename)
        {
            string filePath = Path.Combine(_directory.FullName, filename);

            using (StreamReader reader = new StreamReader(filePath))
            using (JsonTextReader jsonReader = new JsonTextReader(reader))
            {
                return _serializer.Deserialize<ConfigFile>(jsonReader);
            }
        }

    }
}
