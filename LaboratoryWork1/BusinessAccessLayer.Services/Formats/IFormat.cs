using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public interface IFormat {
        string Assemble(string[] data);
        string[,] Disassemble(string data, string type, int itemCount);
    }
}
