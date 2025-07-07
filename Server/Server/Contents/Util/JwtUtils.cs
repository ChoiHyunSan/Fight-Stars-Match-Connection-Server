using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Server.Contents
{
    public class JwtUtils
    {
        private static readonly string _secret = Config.JwtSecret; 
        private static readonly TokenValidationParameters _validationParams = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret)),
            ClockSkew = TimeSpan.Zero
        };

        public static ClaimsPrincipal? ValidateToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            try
            {
                var principal = handler.ValidateToken(token, _validationParams, out _);
                return principal;
            }
            catch
            {
                return null;
            }
        }

        public static long GetUserId(ClaimsPrincipal principal)
        {
            return long.TryParse(principal.FindFirstValue(ClaimTypes.NameIdentifier), out var userId) ? userId : 0;
        }
    }
}
