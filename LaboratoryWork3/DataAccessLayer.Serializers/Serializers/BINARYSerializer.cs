using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Serializers
{
    public class BINARYSerializer<T> : ISerializer<T> {
        public string FilePath { get; set; }

        public BINARYSerializer() {
            FilePath = $"{typeof(T).GetGenericArguments()[0].Name}_serialization.data";
        }
        public BINARYSerializer(string filePath) {
            FilePath = filePath;
        }

        public void Clear() {
            if (!File.Exists(FilePath))
                throw new FileNotFoundException($"File '{FilePath}' does not exist.");
            FileStream stream = new FileStream(FilePath, FileMode.Truncate);
            stream.Close();
        }

        public T Deserialize() {
            if (!File.Exists(FilePath))
                throw new FileNotFoundException($"File '{FilePath}' does not exist.");
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(FilePath, FileMode.Open))
                return (T)binaryFormatter.Deserialize(stream);
        }

        public void Serialize(T data) {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(FilePath, FileMode.OpenOrCreate))
                binaryFormatter.Serialize(stream, data);
        }
    }
}
