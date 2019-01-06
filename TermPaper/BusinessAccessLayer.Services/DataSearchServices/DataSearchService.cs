using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public static class DataSearchService<TEntity> where TEntity : class {

        public static TEntity FindByKey(IDataAccessor<TEntity> dataAccessor, string key) {
            if (dataAccessor != null)
                foreach (var datum in dataAccessor.Data)
                    if (datum.ToString().Contains(key))
                        return datum;
            return null;
        }

        public static List<TEntity> FindAllByKey(IDataAccessor<TEntity> dataAccessor, string key) {
            List<TEntity> entities = new List<TEntity>();
            if (dataAccessor != null)
                foreach (var datum in dataAccessor.Data)
                    if (datum.ToString().Contains(key))
                        entities.Add(datum);
            return entities;
        }

        public static TEntity FindLastByKey(IDataAccessor<TEntity> dataAccessor, string key) {
            List<TEntity> entities = dataAccessor.Data;
            entities.Reverse();
            if (dataAccessor != null)
                foreach (var datum in entities)
                    if (datum.ToString().Contains(key))
                        return datum;
            return null;
        }
    }
}
