using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GoIdentity.Entities.Scores;

namespace GoIdentity.CoreEngine
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
    }
}
