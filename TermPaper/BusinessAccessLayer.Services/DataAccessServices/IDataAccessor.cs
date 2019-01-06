using System;
using DataAccessLayer.DataAccessors;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public interface IDataAccessor<TData> {
        List<TData> Data { get; }
        ISerializer<List<TData>> Serializer { get; }
        void Clear();
        void Read();
        bool Write();
    }
}
