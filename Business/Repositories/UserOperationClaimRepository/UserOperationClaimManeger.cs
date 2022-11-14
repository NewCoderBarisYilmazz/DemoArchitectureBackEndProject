using DataAccess.Abstract;
using Entities.Concreate;

namespace Business.Repositories.UserOperationClaimRepository
{
    public class UserOperationClaimManeger : IUserOperationClaimService
    {
        private readonly IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManeger(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public void Add(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Add(userOperationClaim);
        }
    }
}
