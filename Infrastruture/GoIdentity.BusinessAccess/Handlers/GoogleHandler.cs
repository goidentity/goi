using GoIdentity.Entities.Scores;
using GoIdentity.Utilities.Constants;
using Google.Cloud.Language.V1;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GoIdentity.BusinessAccess.Handlers
{
    public class GoogleHandler : Handler
    {
        public GoogleHandler() : base(ConnectorType.Google)
        {

        }

        public override string RawHandle(string input)
        {
            var url = @"https://www.googleapis.com/customsearch/v1?key=AIzaSyBAUIgRfOlx8e4OcsZm0CojOTbLnwNyYRs&cx=010411868023207416729:pkel_dw1rf8&q=";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();

                var response = client.GetAsync(url + WebUtility.UrlEncode(input)).Result;

                return response.Content.ReadAsStringAsync().Result;
            }
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

        public override dynamic ProcessDetailed(string text)
        {
            var client = LanguageServiceClient.Create();

            var responseEntities = client.AnalyzeEntities(new Document()
            {
                Content = text,
                Type = Document.Types.Type.PlainText
            });

            var responseSentiment = client.AnalyzeEntitySentiment(new Document()
            {
                Content = text,
                Type = Document.Types.Type.PlainText
            });

            var responseSyntax = client.AnalyzeSyntax(new Document()
            {
                Content = text,
                Type = Document.Types.Type.PlainText
            });

            var responseClassify = client.ClassifyText(new Document()
            {
                Content = text,
                Type = Document.Types.Type.PlainText
            });

            return new
            {
                AnalyzeEntities = JsonConvert.SerializeObject(responseSentiment),
                AnalyzeEntitySentiment = JsonConvert.SerializeObject(responseSentiment),
                AnalyzeSyntax = JsonConvert.SerializeObject(responseSyntax),
                ClassifyText = JsonConvert.SerializeObject(responseClassify)
            };
        }

        public override string AuthorizeUser(Influencer influencer)
        {
            var clientId = "222479061363-cs7ogfj3409d79vh2tjic6dief3m8vve.apps.googleusercontent.com"; //influencer.ApiKey;
            string callBackUrl = $"{ConnectionStrings.REDIRECT_URL_DOMAIN}/api/oauth/googleplus/callback";

            return @"https://accounts.google.com/o/oauth2/v2/auth?" +
                    "scope=" + @"https://www.googleapis.com/auth/plus.login" + //profile&" +
                    "&access_type=offline" +
                    "&include_granted_scopes=true" +
                    //"state=state_parameter_passthrough_value&" +
                    "&redirect_uri=" + callBackUrl +
                    "&response_type=code" +
                    "&client_id=" + clientId;
        }

        public override async Task<(string authToken, int expiresIn)> GetAuthToken(Influencer influencer, string authCode)
        {
            var clientId = influencer.ApiKey;
            var clientSecret = influencer.Other1;
            string callBackUrl = $"{ConnectionStrings.REDIRECT_URL_DOMAIN}/api/oauth/googleplus/callback";

            //get access token            
            using (var httpClient = new HttpClient() { BaseAddress = new Uri(@"https://www.googleapis.com/") })
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var authRelUrl = $"oauth2/v4/token";
                var body = JsonConvert.SerializeObject(new
                {
                    code = authCode,
                    client_id = clientId,
                    client_secret = clientSecret,
                    redirect_uri = callBackUrl,
                    grant_type = "authorization_code"
                });
                var tokenresponse = await httpClient.PostAsync(authRelUrl, new StringContent(body, Encoding.UTF8, "application/json"));
                if (tokenresponse?.IsSuccessStatusCode ?? false)
                {
                    var token = await tokenresponse.Content.ReadAsStringAsync();
                    var tokenJson = JsonConvert.DeserializeObject<dynamic>(token);

                    return (tokenJson.access_token, tokenJson.expires_in);
                }
                return (string.Empty, 0);
            }
        }
    }
}
