using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public static class DataEditService<TEntity> {  

        public static bool Add(IDataAccessor<TEntity> dataAccessor, TEntity entity) {
            dataAccessor.Data.Add(entity);
            return true;
        }

        public static bool Modify(IDataAccessor<TEntity> dataAccessor, TEntity currentEntity, TEntity newEntity) {
            if (dataAccessor.Data.Contains(currentEntity)) {
                int index = dataAccessor.Data.IndexOf(currentEntity);
                dataAccessor.Data[index] = newEntity;
                return true;
            }
            return false;
        }

        public static bool Remove(IDataAccessor<TEntity> dataAccessor, TEntity entity) {
            return dataAccessor.Data.Remove(entity);
        }
    }
}
