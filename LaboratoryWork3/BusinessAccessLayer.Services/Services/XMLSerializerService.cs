using System;
using DataAccessLayer.Serializers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public class XMLSerializerService<T> : IDataAccessService<T> {
        public XMLSerializerService() {
            _serializer = new XMLSerializer<T>();
        }
        public XMLSerializerService(string filePath) {
            _serializer = new XMLSerializer<T>(filePath);
        }
    }
}
