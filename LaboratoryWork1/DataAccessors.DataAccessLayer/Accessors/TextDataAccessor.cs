using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessors.DataAccessLayer
{
    public class TextDataAccessor : IDataAccessor {
        public string FilePath { get; set; }

        public TextDataAccessor() {
            FilePath = "data.txt";
        }
        public TextDataAccessor(string filePath) {
            FilePath = filePath;
        }

        public void Clear() {
            if (!File.Exists(FilePath))
                throw new FileNotFoundException($"File '{FilePath}' is not exist.");
            FileStream stream = new FileStream(FilePath, FileMode.Truncate);
            stream.Close();
        }

        public string ReadData() {
            if (!File.Exists(FilePath))
                throw new FileNotFoundException($"File '{FilePath}' is not exist.");
            using (StreamReader reader = new StreamReader(FilePath, Encoding.Default))
                return reader.ReadToEnd();
        }

        public void WriteData(string data) {
            using (StreamWriter writer = new StreamWriter(FilePath, false, Encoding.Default))
                writer.Write(data);
        }
    }
}
