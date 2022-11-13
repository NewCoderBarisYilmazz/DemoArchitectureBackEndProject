using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Result.Concrete
{
    public class SuccesDataResult<T> : DataResult<T>
    {
        public SuccesDataResult( string message, T data) : base(true, message, data)
        {
        }
    }
}
