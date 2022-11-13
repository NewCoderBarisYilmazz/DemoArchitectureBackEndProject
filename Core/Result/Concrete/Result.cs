using Core.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Result.Concrete
{
    public class Result:IResult
    {
        public Result(bool succes,string message)
        {
           Success = succes;
           Message = message;
        }
        public Result(bool succes)
        {
            Success = succes;
        }
        public Result()
        {

        }
        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
