using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class OperationClaimManeger : IOperationClaimService
    {
        private readonly IOperationClaimDal _operationClaimDal;

        public OperationClaimManeger(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        public void Add(OperationClaim claim)
        {
          _operationClaimDal.Add(claim);
        }

        public OperationClaim Get(OperationClaim claim)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OperationClaim> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(OperationClaim claim)
        {
            throw new NotImplementedException();
        }

        public void Update(OperationClaim claim)
        {
            throw new NotImplementedException();
        }
    }
}
