using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASP.NET_SignalR.Extension
{
    public static class ClaimExtension
    {
        public static string? GetUserId(this ClaimsPrincipal user)
        {

            return user.Claims.SingleOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value;
        }

        public static string? GetUserEmail(this ClaimsPrincipal user)
        {
            return user.Claims.SingleOrDefault(c => c.Type.Equals(ClaimTypes.Email))?.Value;
        }
    }
}