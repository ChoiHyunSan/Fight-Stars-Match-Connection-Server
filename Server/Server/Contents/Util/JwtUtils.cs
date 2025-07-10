using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Server.Contents
{
    public static class JwtUtils
    {
        private static readonly string Secret = Config.JwtSecret; 
        private static readonly TokenValidationParameters ValidationParams = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret)),
            ClockSkew = TimeSpan.Zero
        };

        public static ClaimsPrincipal? ValidateToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            try
            {
                var principal = handler.ValidateToken(token, ValidationParams, out _);
                return principal;
            }
            catch
            {
                return null;
            }
        }

        public static long GetUserId(ClaimsPrincipal principal)
        {
            return long.TryParse(principal.FindFirstValue(ClaimTypes.NameIdentifier), out var userId) 
                ? userId 
                : 0;
        }
    }
}
