using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public static class DataSearchService<TEntity> where TEntity : class {

        public static TEntity SearchByKey(IDataAccessor<TEntity> dataAccessor, string key) {
            if (dataAccessor != null)
                foreach (var datum in dataAccessor.Data)
                    if (datum.ToString().Contains(key))
                        return datum;
            return null;
        }
    }
}
