using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessors.DataAccessLayer
{
    public interface IDataAccessor {
        string FilePath { get; set; }
        string ReadData();
        void WriteData(string data);
        void Clear();
    }
}
