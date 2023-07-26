using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Core.Models.Data
{
    public interface IResult
    {
        Status Status { get; set; }

        string Message { get; set; }

        string StatusCode { get; set; }
    }
}
