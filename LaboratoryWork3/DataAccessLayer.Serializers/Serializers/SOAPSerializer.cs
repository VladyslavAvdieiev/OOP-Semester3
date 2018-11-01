using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Serializers
{
    public class SOAPSerializer<T> : ISerializer<T> {
        public string FilePath { get; set; }

        public SOAPSerializer() {
            FilePath = $"{typeof(T).GetGenericArguments()[0].Name}_serialization.soap";
        }
        public SOAPSerializer(string filePath) {
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
            SoapFormatter soapFormatter = new SoapFormatter();
            using (FileStream stream = new FileStream(FilePath, FileMode.Open))
                return (T)soapFormatter.Deserialize(stream);
        }

        public void Serialize(T data) {
            SoapFormatter soapFormatter = new SoapFormatter();
            using (FileStream stream = new FileStream(FilePath, FileMode.OpenOrCreate))
                soapFormatter.Serialize(stream, data);
        }
    }
}
