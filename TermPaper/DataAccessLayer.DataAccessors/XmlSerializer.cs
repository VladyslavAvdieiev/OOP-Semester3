using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccessors
{
    public class XmlSerializer<T> : ISerializer<T> {
        public string FilePath { get; }

        public XmlSerializer() {
            Type[] genericTypes = typeof(T).GetGenericArguments();
            if (genericTypes == Type.EmptyTypes)
                FilePath = $"{typeof(T).Name}.xml";
            else
                FilePath = $"{genericTypes[0].Name}.xml";
        }

        public XmlSerializer(string filePath) {
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
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (FileStream stream = new FileStream(FilePath, FileMode.Open))
                return (T)xmlSerializer.Deserialize(stream);
        }

        public void Serialize(T data) {
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (FileStream stream = new FileStream(FilePath, FileMode.OpenOrCreate))
                xmlSerializer.Serialize(stream, data);
        }
    }
}
