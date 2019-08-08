using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NextMassConsole
{
    public class JsonTools : ISerializerTools
    {
        private DirectoryInfo _directory = new DirectoryInfo(Directory.GetCurrentDirectory());
        private JsonSerializer _serializer = new JsonSerializer();

        public void WriteFile<T>(T fileContents, string filename)
        {
            string filePath = Path.Combine(_directory.FullName, filename);

            using (StreamWriter writer = new StreamWriter(filePath))
            using (JsonTextWriter jsonWriter = new JsonTextWriter(writer))
            {
                _serializer.Serialize(jsonWriter, fileContents);
            }
        }

        public T ReadFile<T>(string filename)
        {
            string filePath = Path.Combine(_directory.FullName, filename);

            using (StreamReader reader = new StreamReader(filePath))
            using (JsonTextReader jsonReader = new JsonTextReader(reader))
            {
                return _serializer.Deserialize<T>(jsonReader);
            }
        }

        /// <summary>
        /// Converts JSON string to C# object.
        /// </summary>
        /// <typeparam name="T">Type of the object to be created</typeparam>
        /// <param name="jsonString">JSON string of type T.</param>
        /// <param name="encoding">Encoding of the JSON string</param>
        /// <returns>Object of type T from given JSON string.</returns>

        public T ReadString<T>(string jsonString, Encoding encoding)
        {
            byte[] bytes = encoding.GetBytes(jsonString);

            using (Stream stream = new MemoryStream(bytes))
            using (StreamReader reader = new StreamReader(stream))
            using (JsonTextReader jsonReader = new JsonTextReader(reader))
            {
                return _serializer.Deserialize<T>(jsonReader);
            }

        }

    }
}
