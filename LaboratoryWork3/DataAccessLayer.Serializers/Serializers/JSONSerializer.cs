using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Serializers
{
    public class JSONSerializer<T> : ISerializer<T> {
        public string FilePath { get; set; }

        public JSONSerializer() {
            FilePath = $"{typeof(T).GetGenericArguments()[0].Name}_serialization.json";
        }
        public JSONSerializer(string filePath) {
            FilePath = filePath;
        }

        public void Clear() {
            if (!File.Exists(FilePath))
                throw new FileNotFoundException($"File '{FilePath}' is not exist.");
            FileStream stream = new FileStream(FilePath, FileMode.Truncate);
            stream.Close();
        }

        public T Deserialize() {
            if (!File.Exists(FilePath))
                throw new FileNotFoundException($"File '{FilePath}' is not exist.");
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
            using (FileStream stream = new FileStream(FilePath, FileMode.Open))
                return (T)jsonSerializer.ReadObject(stream);
        }

        public void Serialize(T data) {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
            using (FileStream stream = new FileStream(FilePath, FileMode.OpenOrCreate))
                jsonSerializer.WriteObject(stream, data);
        }
    }
}
