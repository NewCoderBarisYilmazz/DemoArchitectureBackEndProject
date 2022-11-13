using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Result.Abstract
{
    internal interface IDataResult<T>:IResult
    {
        public T Data { get; set; }
    }
}
