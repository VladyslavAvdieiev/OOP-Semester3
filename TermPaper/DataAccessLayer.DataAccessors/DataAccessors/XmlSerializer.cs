using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccessors
{
    public class XmlSerializer<TData> : ISerializer<TData> {

        public string FilePath { get; }

        public XmlSerializer() {
            Type[] genericTypes = typeof(TData).GetGenericArguments();
            if (genericTypes == Type.EmptyTypes)
                FilePath = $"{typeof(TData).Name}.xml";
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

        public TData Deserialize() {
            if (!File.Exists(FilePath))
                throw new FileNotFoundException($"File '{FilePath}' does not exist.");
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(TData));
            using (FileStream stream = new FileStream(FilePath, FileMode.Open))
                return (TData)xmlSerializer.Deserialize(stream);
        }

        public void Serialize(TData data) {
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(TData));
            using (FileStream stream = new FileStream(FilePath, FileMode.OpenOrCreate))
                xmlSerializer.Serialize(stream, data);
        }
    }
}
