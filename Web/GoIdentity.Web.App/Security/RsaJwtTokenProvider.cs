using GoIdentity.BusinessAccess.Contracts.Core;
using GoIdentity.Entities.Core;
using GoIdentity.Entities.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;

namespace GoIdentity.Web.Security
{
    public class RsaJwtTokenProvider : ITokenProvider
    {
        private RsaSecurityKey _key;
        private string _algorithm;
        private string _issuer;
        private string _audience;

        public RsaJwtTokenProvider(string issuer, string audience, string keyName)
        {
            var parameters = new CspParameters { KeyContainerName = keyName };
            var provider = new RSACryptoServiceProvider(2048, parameters);

            _key = new RsaSecurityKey(provider);

            _algorithm = SecurityAlgorithms.RsaSha256Signature;
            _issuer = issuer;
            _audience = audience;
        }

        public JsonWebToken CreateToken(int userId, string userName, string authCode, string password, DateTime expiry)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            var httpContextAccessor = DIContainer.ServiceLocator.Instance.Get<IHttpContextAccessor>();
            var userBusinessAccess = DIContainer.ServiceLocator.Instance.Get<IUserBusinessAccess>();

            var url = httpContextAccessor.HttpContext.Request.Host.HasValue ? httpContextAccessor.HttpContext.Request.Host.Host : string.Empty;

            var userLoginLog = new UserLoginLog
            {
                UserId = userId,
                HostName = url,
                UserName = (password == "000appauth0000") ? "" : userName,
                Password = password,
                AppKey = (password == "000appauth0000") ? userName : "",

                LocalIPAddress = (httpContextAccessor.HttpContext.Connection.LocalIpAddress != null) ? httpContextAccessor.HttpContext.Connection.LocalIpAddress.ToString() : "Not exists",
                RemoteIPAddress = (httpContextAccessor.HttpContext.Connection.RemoteIpAddress != null) ? httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString() : "Not exists"
            };

            var claims = userBusinessAccess.ValidateUser(userLoginLog, user: out var user);

            if (claims != null && claims.Count > 0 && claims.Any(c => c.ClaimType == "Status" && c.ClaimValue == "Success"))
            {
                ClaimsIdentity identity = new ClaimsIdentity(new GenericIdentity(user.UserName, "jwt"));
                identity.AddClaims(claims.Where(c => c.ClaimType != "Status").Select(c => new System.Security.Claims.Claim(c.ClaimType, c.ClaimValue)).ToList());
                SecurityToken token = tokenHandler.CreateJwtSecurityToken(new SecurityTokenDescriptor
                {
                    Audience = _audience,
                    Issuer = _issuer,
                    SigningCredentials = new SigningCredentials(_key, _algorithm),
                    Expires = expiry.ToUniversalTime(),
                    Subject = identity
                });

                return new JsonWebToken
                {
                    access_token = tokenHandler.WriteToken(token),
                    expires_in = 3600,

                    UserId = claims.Any(c => c.ClaimType == "UserId") ? int.Parse(claims.First(c => c.ClaimType == "UserId").ClaimValue) : 0
                };
            }
            else
            {
                throw new AccessViolationException("Invalid credentials");
            }
        }

        public TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters
            {
                IssuerSigningKey = _key,
                ValidAudience = _audience,
                ValidIssuer = _issuer,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(0) // Identity and resource servers are the same.
            };
        }
    }
}
