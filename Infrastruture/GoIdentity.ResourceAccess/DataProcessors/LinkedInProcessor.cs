using GoIdentity.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoIdentity.ResourceAccess.DataProcessors 
{
    public class LinkedInProcessor : DataProcessor
    {
        
        public LinkedInProcessor(int userId) : base(userId)
        {
        }

        public override string Connect()
        {
           

            return string.Empty;
        }

        public string GetUrl()
        {
            return @"https://www.linkedin.com/oauth/v2/authorization?" +
                           "response_type=code&" +
                           "client_id=819u32abc5qgqk&" +
                           "redirect_uri="+$"{ConnectionStrings.REDIRECT_URL_DOMAIN}/api/oauth/linkedin/callback&" +
                           "state=987654321&" +
                           "scope=r_fullprofile";
        }
    }
}
