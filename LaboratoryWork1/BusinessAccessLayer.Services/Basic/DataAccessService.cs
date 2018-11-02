using System;
using BusinessAccessLayer.Entities;
using DataAccessors.DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BusinessAccessLayer.Services
{
    public abstract class DataAccessService<T> where T : Person {
        protected IDataAccessor _accessor;

        public void Clear() {
            _accessor.Clear();
        }

        public T[] Read(IFormat format) {
            string sourseString = _accessor.ReadData();
            string[,] parsedData = format.Disassemble(sourseString, typeof(T).Name, typeof(T).GetProperties().Count());
            T[] result = new T[parsedData.GetLength(0)];
            PropertyInfo[] propertyInfo = typeof(T).GetProperties();
            for (int i = 0; i < parsedData.GetLength(0); i++) {

            }
            return result;
        }

        public void Write(T data, IFormat format) {
            _accessor.WriteData(format.Assemble(data.Disassemble()));
        }
    }
}
