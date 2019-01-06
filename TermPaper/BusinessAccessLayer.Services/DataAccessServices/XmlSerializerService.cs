using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataAccessors;

namespace BusinessAccessLayer.Services
{
    public class XmlSerializerService<TData> : IDataAccessor<TData> {
        
        public List<TData> Data { get; internal set; }
        public ISerializer<List<TData>> Serializer { get; }

        public XmlSerializerService() {
            Serializer = new XmlSerializer<List<TData>>();
        }

        public XmlSerializerService(string filePath) {
            Serializer = new XmlSerializer<List<TData>>(filePath);
        }

        public void Clear() {
            Serializer.Clear();
        }

        public void Read() {
            Data = Serializer.Deserialize();
        }

        public bool Write() {
            if (Data != null) {
                Serializer.Serialize(Data);
                return true;
            }
            return false;
        }
    }
}
