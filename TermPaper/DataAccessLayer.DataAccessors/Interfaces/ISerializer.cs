using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccessors
{
    public interface ISerializer<TData> {
        string FilePath { get; }
        void Clear();
        TData Deserialize();
        void Serialize(TData data);
    }
}
