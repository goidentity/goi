using Microsoft.IdentityModel.Tokens;
using System;

namespace GoIdentity.Web.Security
{
    public interface ITokenProvider
    {
        JsonWebToken CreateToken(int userId, string userName, string authCode, string password, DateTime expiry);

        TokenValidationParameters GetValidationParameters();
    }
}
