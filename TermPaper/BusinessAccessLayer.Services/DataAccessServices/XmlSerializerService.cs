using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataAccessors;

namespace BusinessAccessLayer.Services
{
    public class XmlSerializerService<T> : IDataAccessor<T> {
        
        public List<T> Data { get; internal set; }
        public ISerializer<List<T>> Serializer { get; }

        public XmlSerializerService() {
            Serializer = new XmlSerializer<List<T>>();
        }

        public XmlSerializerService(string filePath) {
            Serializer = new XmlSerializer<List<T>>(filePath);
        }

        public void Clear() {
            Serializer.Clear();
        }

        public void Read() {
            Data = Serializer.Deserialize();
        }

        public void Write() {
            Serializer.Serialize(Data);
        }
    }
}
