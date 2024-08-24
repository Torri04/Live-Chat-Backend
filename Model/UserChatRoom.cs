using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_SignalR.Model
{
    [Table("UserConnection")]
    public class UserChatRoom
    {
        public string UserId { get; set; } = string.Empty;

        [ForeignKey("UserId")]
        public AppUser? User { get; set; }

        public Guid ChatRoomId { get; set; }
        [ForeignKey("ChatRoomId")]
        public ChatRoom? ChatRoom { get; set; }

        public DateTime JoinedAt { get; set; } = DateTime.Now;
        public string ConnectionId { get; set; } = string.Empty;
    }
}