using System;
using DataAccessLayer.DataAccessors;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public class XmlSerializerService<T> : DataAccessService<T> {

        public XmlSerializerService() {
            _serializer = new XmlSerializer<T>();
        }

        public XmlSerializerService(string filePath) {
            _serializer = new XmlSerializer<T>(filePath);
        }
    }
}
