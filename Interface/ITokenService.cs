
using ASP.NET_SignalR.Model;

namespace ASP.NET_API.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(AppUser user);
    }
}