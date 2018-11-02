using System;
using BusinessAccessLayer.Entities;
using DataAccessors.DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public class TextDataAccessorService<T> : DataAccessService<T> where T : Person {
        public TextDataAccessorService() {
            _accessor = new TextDataAccessor();
        }
        public TextDataAccessorService(string filePath) {
            _accessor = new TextDataAccessor(filePath);
        }
    }
}
