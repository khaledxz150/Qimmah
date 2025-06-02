using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using Qimmah.Models.Options;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Qimmah.Managers
{
    public class JWTManager
    {
        public class JwtTokenValidator : ISecurityTokenValidator
        {
            private readonly IOptions<JWTOptions> jWTOptions;

            public JwtTokenValidator(IOptions<JWTOptions> jWTOptions)
            {
                this.jWTOptions = jWTOptions;
            }

            public bool CanReadToken(string securityToken) => true;

            public ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
            {
                var handler = new JwtSecurityTokenHandler();
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jWTOptions.Value.Issuer,
                    ValidAudience = jWTOptions.Value.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jWTOptions.Value.Key))
                };

                try
                {
                    var claimsPrincipal = handler.ValidateToken(securityToken, tokenValidationParameters, out validatedToken);
                    return claimsPrincipal;
                }
                catch (Exception ex)
                {
                    validatedToken = null;
                    return null;
                    // Log exception or handle as necessary
                    //throw new SecurityTokenInvalidSignatureException("Token validation failed", ex);
                }
            }
            public bool CanValidateToken { get; } = true;
            public int MaximumTokenSizeInBytes { get; set; } = int.MaxValue;
        }
    }
}
