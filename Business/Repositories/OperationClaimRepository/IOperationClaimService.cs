using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.OperationClaimRepository
{
    public interface IOperationClaimService
    {
        void Add(OperationClaim claim);

        void Remove(OperationClaim claim);

        void Update(OperationClaim claim);

        OperationClaim Get(OperationClaim claim);

        IEnumerable<OperationClaim> GetAll();

    }
}
