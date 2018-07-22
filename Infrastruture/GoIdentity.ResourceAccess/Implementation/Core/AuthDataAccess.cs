using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoIdentity.Entities.Core;
using GoIdentity.ResourceAccess.Contracts.Core;
using GoIdentity.ResourceAccess.DataProcessors;

namespace GoIdentity.ResourceAccess.Implementation.Core
{
    public class AuthDataAccess : DataAccess, IAuthDataAccess
    {
        public AuthDataAccess(IUnitOfWork unitOfWork, UserContext userContext = null) : base(unitOfWork, userContext)
        {
        }
    }
}
