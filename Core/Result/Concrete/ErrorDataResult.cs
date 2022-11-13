using Core.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Result.Concrete
{
    public class ErrorDataResult<T> : DataResult<T>
    {

        public ErrorDataResult( string message, T data) : base(false, message, data)
        {
        }
    }
}
