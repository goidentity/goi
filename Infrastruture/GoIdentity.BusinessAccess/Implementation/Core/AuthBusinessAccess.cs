using GoIdentity.BusinessAccess.Contracts.Core;
using GoIdentity.BusinessAccess.Handlers;
using GoIdentity.Entities.Scores;
using GoIdentity.ResourceAccess.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoIdentity.BusinessAccess.Implementation.Core
{
    public class AuthBusinessAccess : IAuthBusinessAccess
    {
        private readonly IAuthDataAccess authDataAccess;
        private readonly HandlerContainer handlerContainer;

        public AuthBusinessAccess(IAuthDataAccess authDataAccess, HandlerContainer handlerContainer)
        {
            this.authDataAccess = authDataAccess;
            this.handlerContainer = handlerContainer;
        }

        public string AuthorizeUser(ConnectorType connectorType)
        {
            Influencer influencer = authDataAccess.GetInfluncerAuthInfo(connectorType);
            var handler = handlerContainer.GetHandler(connectorType);

            string authRequestUrl = handler.AuthorizeUser(influencer);
            return authRequestUrl;
        }

        public async Task<bool> StoreAuthToken(string authCode, ConnectorType connectorType, int LoggedInUserId)
        {
            Influencer influencer = authDataAccess.GetInfluncerAuthInfo(connectorType);
            var handler = handlerContainer.GetHandler(connectorType);

            var authTokenDetails = await handler.GetAuthToken(influencer,authCode);
            if (!string.IsNullOrEmpty(authTokenDetails.authToken))
            {
                UserInfluencerAuth userInfluencer = new UserInfluencerAuth()
                {
                    UserId = LoggedInUserId,
                    InfluencerId = connectorType,
                    Secret = authTokenDetails.authToken,
                    Other1 = authTokenDetails.expiresIn.ToString()
                };
                bool isSuccess = authDataAccess.StoreAuthToken(userInfluencer);
                return isSuccess;
            }
            return false;
        }
    }
}
