using GoIdentity.Entities.Scores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoIdentity.BusinessAccess.Contracts.Core
{
    public interface IAuthBusinessAccess
    {
        string AuthorizeUser(ConnectorType connectorType);
        Task<bool> StoreAuthToken(string authCode, ConnectorType connectorType, int loggedInUserId);
    }
}
