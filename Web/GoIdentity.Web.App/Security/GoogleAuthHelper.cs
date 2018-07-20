using GoIdentity.Utilities.Constants;

namespace GoIdentity.Web.Security
{
    public class GoogleAuthHelper
    {
        public static GoogleAuhSetupCode GenerateSetupCode(string clientName, string userName)
        {
            return new GoogleAuthenticator().GenerateSetupCode(clientName, userName, clientName + ":" + ConnectionStrings.GOOGLE_AUTH_SECRET_KEY, 300, 300);
        }

        public static bool ValidateCode(string clientName, string authCode)
        {
            return new GoogleAuthenticator().ValidateTwoFactorPIN(clientName + ":" + ConnectionStrings.GOOGLE_AUTH_SECRET_KEY, authCode);
        }

    }
}
