using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Core.Models.Data;

namespace Test.Core.Interfaces.Web
{
    public interface ICrudController<T, TKey>
    {
        Task<ActionResult<DataResult<T>>> Get(TKey id);

        Task<ActionResult<DataResult<T>>> Post([FromBody] T entry);

        Task<ActionResult<DataResult<T>>> Put([FromBody] T entry);

        Task<ActionResult<Result>> Delete(TKey id);
    }
}
