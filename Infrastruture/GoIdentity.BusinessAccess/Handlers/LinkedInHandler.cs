using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GoIdentity.Entities.Scores;
using GoIdentity.Utilities.Constants;
using Newtonsoft.Json;

namespace GoIdentity.BusinessAccess.Handlers
{
    public class LinkedInHandler : Handler
    {
        public LinkedInHandler() : base(ConnectorType.LinkedIn)
        {

        }

        public override string Handle(Influencer influencer, UserInfluencerAuth userInfluencerAuthKey)
        {
            //var url = @"https://api.linkedin.com/v1/people/~?format=json";
            //var r = _handle(url, influencer, userInfluencerAuthKey);
            //return r;
            return GetProfile(influencer, userInfluencerAuthKey);
        }
        public string GetProfile(Influencer influencer, UserInfluencerAuth userInfluencerAuthKey)
        {
            var url = @"https://api.linkedin.com/v1/people/~:(id,first-name,last-name,maiden-name,formatted-name,phonetic-first-name,phonetic-last-name,formatted-phonetic-name,headline,location,industry,num-connections,num-connections-capped,summary,specialties,positions,picture-url,picture-urls::(original),site-standard-profile-request,api-standard-profile-request)?format=json";
            var r = _handle(url, influencer, userInfluencerAuthKey);
            return r;
        }
        private string _handle(string url, Influencer influencer, UserInfluencerAuth userInfluencerAuthKey)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userInfluencerAuthKey.Secret);
                var response = client.GetAsync(url).Result;

                return response.Content.ReadAsStringAsync().Result;
            }
        }

        public override string AuthorizeUser(Influencer influencer)
        {
            var clientId = influencer.ApiKey;
            string callBackUrl = $"{ConnectionStrings.REDIRECT_URL_DOMAIN}/api/oauth/linkedin/callback";

            return @"https://www.linkedin.com/oauth/v2/authorization?" +
                           "response_type=code" +
                           "&client_id=" + clientId +
                           "&redirect_uri="+ callBackUrl +
                           "&scope=r_basicprofile";            
        }

        public override async Task<(string authToken, int expiresIn)> GetAuthToken(Influencer influencer, string authCode)
        {
            var clientId = influencer.ApiKey;
            var clientSecret = influencer.Other1;
            string callBackUrl = $"{ConnectionStrings.REDIRECT_URL_DOMAIN}/api/oauth/linkedin/callback";

            //get access token            
            using (var httpClient = new HttpClient() { BaseAddress = new Uri(@"https://www.linkedin.com/") })
            {
                httpClient.DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var authRelUrl = $"/oauth/v2/accessToken?grant_type=authorization_code&code={authCode}" +
                                $"&redirect_uri={callBackUrl}&client_id={clientId}&client_secret={clientSecret}";

                var tokenresponse = await httpClient.GetAsync(authRelUrl);
                if (tokenresponse?.IsSuccessStatusCode ?? false)
                {
                    var token = await tokenresponse.Content.ReadAsStringAsync();
                    var tokenJson = JsonConvert.DeserializeObject<dynamic>(token);

                    return (tokenJson.access_token, tokenJson.expires_in);
                }
                return (string.Empty,0);
            }                
        }
    }
}
