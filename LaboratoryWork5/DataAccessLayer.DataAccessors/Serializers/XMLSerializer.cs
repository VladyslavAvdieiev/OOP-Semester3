using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataAccessLayer.DataAccessors
{
    public class XMLSerializer<T> : ISerializer<T> {
        public string FilePath { get; set; }

        public XMLSerializer() {
            FilePath = $"{typeof(T).GetGenericArguments()[0].Name}.xml";
        }
        public XMLSerializer(string filePath) {
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
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (FileStream stream = new FileStream(FilePath, FileMode.Open))
                return (T)xmlSerializer.Deserialize(stream);
        }

        public void Serialize(T data) {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (FileStream stream = new FileStream(FilePath, FileMode.OpenOrCreate))
                xmlSerializer.Serialize(stream, data);
        }
    }
}
