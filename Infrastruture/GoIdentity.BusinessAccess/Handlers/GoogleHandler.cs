using GoIdentity.Entities.Scores;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoIdentity.BusinessAccess.Handlers
{
    public class GoogleHandler : Handler
    {
        public GoogleHandler() : base(ConnectorType.Google)
        {

        }

        public override string Handle(Influencer influencer, UserInfluencerAuth userInfluencerAuthKey)
        {
            var url = @"https://www.googleapis.com/customsearch/v1?key=AIzaSyBAUIgRfOlx8e4OcsZm0CojOTbLnwNyYRs&cx=010411868023207416729:pkel_dw1rf8&q=";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();

                var response = client.GetAsync(url + WebUtility.UrlEncode(userInfluencerAuthKey.User.FirstName + " " + userInfluencerAuthKey.User.LastName)).Result;
                
                return response.Content.ReadAsStringAsync().Result;
            }            
        }

        public override string AuthorizeUser(Influencer influencer)
        {
            //Google login logic
            return string.Empty;
        }

        public override Task<string> GetAuthToken(Influencer influencer, string authCode)
        {
            //logic for google Auth token get
            return Task.FromResult(string.Empty);
        }
    }
}
