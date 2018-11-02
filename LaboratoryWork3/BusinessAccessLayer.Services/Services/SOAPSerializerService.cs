using System;
using DataAccessLayer.Serializers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public class SOAPSerializerService<T> : DataAccessService<T> {
        public SOAPSerializerService() {
            _serializer = new SOAPSerializer<T>();
        }
        public SOAPSerializerService(string filePath) {
            _serializer = new SOAPSerializer<T>(filePath);
        }
    }
}
