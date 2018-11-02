using System;
using DataAccessLayer.Serializers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public class JSONSerializerService<T> : IDataAccessService<T> {
        public JSONSerializerService() {
            _serializer = new JSONSerializer<T>();
        }
        public JSONSerializerService(string filePath) {
            _serializer = new JSONSerializer<T>(filePath);
        }
    }
}
