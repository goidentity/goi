﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GoIdentity.Entities.Scores;

namespace GoIdentity.CoreEngine
{
    public class LinkedInHandler : Handler
    {
        public LinkedInHandler() : base(ConnectorType.LinkedIn)
        {

        }

        public override string Handle(Influencer influencer, UserInfluencerAuth userInfluencerAuthKey)
        {
            var url = @"https://api.linkedin.com/v1/people/~?format=json";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "AQVzHG58NWobxtag6lFfARM64TEUnxTzE4PW6uVaWQux9LAZB8bdYv2qnRCcWiW65fyaHr9V93DOVORxNeEwsLYp39n3svyiKJnK7u39ahduwnSCHBY5wQ2AipBfwedR1GwBX0U9ZeiKfwxQQBsA6L45KySoZB7keLPSrW45Rg1xqLwhtD9PPaXWkmpc2Hf8N-SohPSbkP2vU4ThZp_2oN5rCYOHBMCZyYQW-hg54mqYKYWgb7J9FlDfgspoKqwPhMb3W02RSMeNjxQfIomJIAxCwPG_jTmE-gsI7rydbflGAyV92nrMD1uWj1_RAya3AJ_7oR2J4lz8htpS85c-aMbeBoTzSw");
                var response = client.GetAsync(url).Result;

                return response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
