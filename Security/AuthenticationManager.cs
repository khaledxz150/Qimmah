using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using Qimmah.Data.User;
using Qimmah.Models.Options;

namespace Qimmah.Security;

public static class AuthenticationManager
{
    public static async Task<ClaimsPrincipal> CreateUserPrincipalAsync(
     UserManager<Users> userManager,
     Users user,
     string lstPolicyIds = "")
    {
        // Base identity claims
        var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.Encrypt().ToString()),
        new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
        new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
        new Claim("LanguageID", user.LanguageID.ToString()),
    };

        // Add user roles
        var roles = await userManager.GetRolesAsync(user);
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        return new ClaimsPrincipal(identity);
    }

    public static ClaimsPrincipal GetClaimsPrincipalFromToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);
        var claims = jwtToken.Claims.ToList();
        claims.Insert(0, new Claim("BearerToken", token));
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        return new ClaimsPrincipal(identity);
    }
}
