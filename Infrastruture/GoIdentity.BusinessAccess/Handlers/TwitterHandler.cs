using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using GoIdentity.Entities.Scores;
using Newtonsoft.Json;

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

        public override async Task<(string authToken, int expiresIn)> GetAuthToken(Influencer influencer, string authCode)
        {
            string clientId = influencer.ApiKey;
            string clientSecret = influencer.Other1;

            string credentials = $"{HttpUtility.UrlEncode(clientId)}:{HttpUtility.UrlEncode(clientSecret)}";
            string base64EncodedCredintials = Convert.ToBase64String(new ASCIIEncoding().GetBytes(credentials));

            using (var httpClient = new HttpClient() { BaseAddress = new Uri(@"https://api.twitter.com/") })
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {base64EncodedCredintials}");
                string body = "grant_type=client_credentials";

                var tokenresponse = await httpClient.PostAsync("oauth2/token", 
                                        new StringContent(body, Encoding.UTF8, "application/x-www-form-urlencoded"));
                if (tokenresponse?.IsSuccessStatusCode ?? false)
                {
                    var token = await tokenresponse.Content.ReadAsStringAsync();
                    var tokenJson = JsonConvert.DeserializeObject<dynamic>(token);
                    //var tweets = await GetTweets(tokenJson.access_token.ToString(), "arrahman");
                    if (tokenJson.token_type == "bearer")
                        return (tokenJson.access_token, -1);
                }
            }
            return (string.Empty,0);
        }

        private async Task<string> GetTweets(string authToken, string screenName)
        {
            using (var httpClient = new HttpClient() { BaseAddress = new Uri(@"https://api.twitter.com/") })
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {authToken}");
                string requestUrl = $"/1.1/statuses/user_timeline.json?count=100&screen_name={screenName}";
                var response = await httpClient.GetAsync(requestUrl);
                if (response?.IsSuccessStatusCode ?? false)
                {
                    var tweets = await response.Content.ReadAsStringAsync();
                    var tweetsJson = JsonConvert.DeserializeObject<dynamic>(tweets);
                    return tweetsJson.ToString();
                }
            }
            return string.Empty;
        }
    }
}
