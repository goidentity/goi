using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GoIdentity.Entities.Scores;
using Newtonsoft.Json;

namespace GoIdentity.BusinessAccess.Handlers
{
    public class FacebookHandler : Handler
    {
        public FacebookHandler() : base(ConnectorType.Facebook)
        {

        }

        public override string Handle(Influencer influencer, UserInfluencerAuth userInfluencerAuthKey)
        {
            var baseUrl = @"https://graph.facebook.com/";
            var accessToken = "EAAH7RGc2T5QBAKnGzM2XJGOWLcN3o9v4hCN5WZBZA0DjTCrrZBgHR0BgNozl0A1Vz8WJJrFh2NUFiTdpbuBxS4IDJT7GsYFxEeQ1RGUxoNUmhBKULQqpPa11jfWZA6sLwIneCVQwEO54JEnQeEYaCa1d7z4ZCVXtc1GUyhu8TB9QZAr18jHt7DzLZBlZBlkDzFgkBerX1XALPgZDZD";
            var url = $"{baseUrl}{influencer.Other2}/me?access_token={accessToken}";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                var response = client.GetAsync(url).Result;

                return response.Content.ReadAsStringAsync().Result;
            }
        }

        public override string AuthorizeUser(Influencer influencer)
        {
            string appId = influencer.ApiKey;
            string callBackUrl = @"https://localhost:44344/api/oauth/facebook/callback";

            return @"https://www.facebook.com/dialog/oauth?" +
                           "client_id=" + appId +
                           "&scope=public_profile,email" +
                           "&response_type=code" +
                           "&redirect_uri= " + callBackUrl;
        }

        public override async Task<string> GetAuthToken(Influencer influencer, string authCode)
        {
            string appId = "557746184671124",
                   appSecret = "236104e44d3f8b702102ec87ba67f4aa",
                   redirectUri = @"https://localhost:44344/api/oauth/facebook/callback";
            
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(@"https://graph.facebook.com/"),
            };
            httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string authRelUrl = $"oauth/access_token?client_id={appId}&redirect_uri={redirectUri}&client_secret={appSecret}&code={authCode}";
            var tokenresponse = await httpClient.GetAsync(authRelUrl);
            var token = await tokenresponse.Content.ReadAsStringAsync();
            var tokenJson = JsonConvert.DeserializeObject<dynamic>(token);

            //string endpoint = "me";
            //string args = "fields=id,name,email,first_name,last_name,age_range,birthday,gender,location";
            //var response = await httpClient.GetAsync($"{endpoint}?access_token={tokenJson.access_token}&{args}");
            //var result = await response.Content.ReadAsStringAsync();

            return tokenJson.access_token;            
        }
    }
}
