using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoIdentity.Entities.Scores;

namespace GoIdentity.BusinessAccess.Handlers
{
    public class TwitterHandler : Handler
    {
        public TwitterHandler() : base(ConnectorType.Twitter)
        {

        }

        public override string Handle(Influencer influencer, UserInfluencerAuth userInfluencerAuthKey)
        {
            var twitter = new Twitter(influencer.ApiKey, influencer.Other1, influencer.Other2, influencer.Other3);

            var response = twitter.GetTweets(userInfluencerAuthKey.UserName, 50);

            return response;
        }
        
        public override string AuthorizeUser(Influencer influencer)
        {
            //Twitter login logic
            return string.Empty;
        }

        public override Task<(string authToken, int expiresIn)> GetAuthToken(Influencer influencer, string authCode)
        {
            //logic for twitter Auth token get
            return Task.FromResult((string.Empty);
        }
    }
}
