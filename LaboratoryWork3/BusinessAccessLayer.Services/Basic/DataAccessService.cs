using System;
using DataAccessLayer.Serializers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public abstract class DataAccessService<T> {
        protected ISerializer<T> _serializer;

        public void Clear() {
            _serializer.Clear();
        }

        public T Read() {
            return _serializer.Deserialize();
        }

        public void Write(T data) {
            _serializer.Serialize(data);
        }
    }
}
