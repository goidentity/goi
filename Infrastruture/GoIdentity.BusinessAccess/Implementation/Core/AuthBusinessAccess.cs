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
    public class AuthBusinessAccess :IAuthBusinessAccess
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

        public async Task<bool> StoreAuthToken(string authCode, ConnectorType connectorType)
        {
            Influencer influencer = authDataAccess.GetInfluncerAuthInfo(connectorType);
            var handler = handlerContainer.GetHandler(connectorType);

            string authToken = await handler.GetAuthToken(influencer,authCode);
            UserInfluencerAuth userInfluencer = new UserInfluencerAuth()
            {
                UserId = 100,
                InfluencerId = connectorType,
                Secret = authToken
            };
            bool isSuccess = authDataAccess.StoreAuthToken(userInfluencer);
            return isSuccess;
        }
    }
}
