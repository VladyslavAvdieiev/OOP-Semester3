using System;
using BusinessAccessLayer.Entities;
using DataAccessors.DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public class TeacherDataAccessService : IDataAccessService {
        IDataAccessor _accessor;

        public TeacherDataAccessService() {
            _accessor = new TextDataAccessor();
        }

        public TeacherDataAccessService(string filePath) {
            _accessor = new TextDataAccessor(filePath);
        }

        public void Clear() {
            _accessor.Clear();
        }

        public Person[] Read(IFormat format) {
            string sourseString = _accessor.ReadData();
            string[,] parsedData = format.Disassemble(sourseString, typeof(Teacher).Name, 
                                                      typeof(Teacher).GetProperties().Count());
            Teacher[] result = new Teacher[parsedData.GetLength(0)];
            for (int i = 0; i < parsedData.GetLength(0); i++)
                result[i] = new Teacher(parsedData[i, 0], parsedData[i, 1], parsedData[i, 2]);
            return result;
        }

        public void Write(Person data, IFormat format) {
            if (data is Teacher teacher)
                _accessor.WriteData(format.Assemble(teacher.Disassemble()));
        }
    }
}
