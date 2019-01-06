using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.DataAccessors;

namespace BusinessAccessLayer.Services.Tests
{
    public class TestDataAccessService<TData> : IDataAccessor<TData> {

        public List<TData> Data { get; internal set; }
        public ISerializer<List<TData>> Serializer => throw new NotImplementedException();

        public TestDataAccessService() {
            Data = new List<TData>();
        }

        public TestDataAccessService(List<TData> data) {
            Data = data;
        }

        public void Clear() {
            throw new NotImplementedException();
        }

        public void Read() {
            throw new NotImplementedException();
        }

        public bool Write() {
            throw new NotImplementedException();
        }
    }
}
