using System;
using DataAccessLayer.DataAccessors;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public interface IDataAccessor<T> {
        List<T> Data { get; }
        ISerializer<List<T>> Serializer { get; }
        void Clear();
        void Read();
        void Write();
    }
}
