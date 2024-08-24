using Microsoft.AspNetCore.Identity;

namespace ASP.NET_SignalR.Model
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public List<UserChatRoom>? UserChatRooms { get; set; }
        public List<ChatMessage>? ChatMessages { get; set; }
    }
}