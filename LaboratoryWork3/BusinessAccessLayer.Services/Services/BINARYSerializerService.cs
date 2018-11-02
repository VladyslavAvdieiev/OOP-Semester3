using System;
using DataAccessLayer.Serializers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public class BINARYSerializerService<T> : IDataAccessService<T> {
        public BINARYSerializerService() {
            _serializer = new BINARYSerializer<T>();
        }
        public BINARYSerializerService(string filePath) {
            _serializer = new BINARYSerializer<T>(filePath);
        }
    }
}
