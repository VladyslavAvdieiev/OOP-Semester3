using System;
using BusinessAccessLayer.Entities;
using DataAccessors.DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public class StudentDataAccessService : IDataAccessService {
        IDataAccessor _accessor;

        public StudentDataAccessService() {
            _accessor = new TextDataAccessor();
        }

        public StudentDataAccessService(string filePath) {
            _accessor = new TextDataAccessor(filePath);
        }

        public void Clear() {
            _accessor.Clear();
        }

        public Person[] Read(IFormat format) {
            string sourseString = _accessor.ReadData();
            string[,] parsedData = format.Disassemble(sourseString, typeof(Student).Name, 
                                                      typeof(Student).GetProperties().Count());
            Student[] result = new Student[parsedData.GetLength(0)];
            for (int i = 0; i < parsedData.GetLength(0); i++)
                result[i] = new Student(parsedData[i, 0], parsedData[i, 1], parsedData[i, 2],
                                        parsedData[i, 3], parsedData[i, 4], int.Parse(parsedData[i, 5]));
            return result;
        }

        public void Write(Person data, IFormat format) {
            if (data is Student student)
                _accessor.WriteData(format.Assemble(student.Disassemble()));
        }
    }
}
