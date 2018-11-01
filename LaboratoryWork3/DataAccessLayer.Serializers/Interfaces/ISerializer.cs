using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Serializers
{
    public interface ISerializer<T> {
        string FilePath { get; set; }
        void Clear();
        T Deserialize();
        void Serialize(T data);
    }
}
