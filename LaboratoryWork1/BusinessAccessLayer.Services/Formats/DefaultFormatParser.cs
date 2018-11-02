using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    // Object{item1="",item2="",item3=""};
    public class DefaultFormatParser : IFormat {
        public string Assemble(string[] data) {
            string result = string.Empty;
            if (data.Length > 0) {
                result += $"{data[0]}{{";
                if (data.Length > 3) {
                    int index = 1;
                    while (index < data.Length) {
                        result += $"{data[index++]}=\"{data[index++]}\"";
                        if (data.Length > index)
                            result += ',';
                    }
                }
                result += "};";
            }
            return result;
        }

        public string[,] Disassemble(string data, string type, int itemCount) {
            int i = 0, j = 0;
            MatchCollection objects = Regex.Matches(data, $"{type}.+?;");
            string[,] result = new string[objects.Count, itemCount];
            foreach (Match obj in objects) {
                foreach (Match item in Regex.Matches(obj.Value, "\".+?\""))
                    result[i, j++] = (Regex.Match(item.Value, @"(\w|\d|\.|/)+")).Value;
                i++;
                j = 0;
            }
            return result;
        }
    }
}
