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
    public interface IDataAccessService {
        void Clear();
        Person[] Read(IFormat format);
        void Write(Person data, IFormat format);
    }
}
