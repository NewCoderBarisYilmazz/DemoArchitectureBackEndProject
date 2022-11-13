using Core.DataAccess.EntityFreamwork;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFreamwork.Context;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFreamwork
{
    public class EfOperationClaimDal :  EfEntityRepositoryBase<OperationClaim, SimpleContextDb>,IOperationClaimDal
    {
       
    }
}
