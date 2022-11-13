using Core.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Result.Concrete
{
    public class DataResult<T> : Result,IDataResult<T>
    {
        public DataResult(bool succes, string message,T data) : base(succes, message)
        {
            Data = data;
        }

        public DataResult(T data):base()
        {
            Data=data;
        }
        public T Data { get ; set; }
    }
}
