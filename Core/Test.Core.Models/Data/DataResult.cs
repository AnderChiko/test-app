using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Test.Core.Models.Data
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult( T entry)
        {
            Entry = entry;
        }
        public T Entry { get; set; }
        public Status Status { get; set; } = Status.Success;
        public string Message { get; set; }
        public string StatusCode { get; set; }
    }
}