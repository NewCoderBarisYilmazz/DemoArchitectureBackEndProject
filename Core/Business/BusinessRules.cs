using Core.Result.Abstract;
using Core.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public class BusinessRules
    {

        public static IResult IsValidBusiness(params IResult[] rules)
        {
            foreach (var rule in rules)
            {
                if (!rule.Success)
                    return new ErrorResult(rule.Message);
            }
            return new SuccesResult();
        }

    }
}
