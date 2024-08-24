using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ASP.NET_SignalR.Model
{
    [Table("ChatMessage")]
    public class ChatMessage
    {
        [Key]
        public Guid ChatMessageId { get; set; } = Guid.NewGuid();
        public string Message { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public string UserId { get; set; } = string.Empty;

        [ForeignKey("UserId")]
        public AppUser? User { get; set; }

        public Guid ChatRoomId { get; set; }
        [ForeignKey("ChatRoomId")]
        public ChatRoom? ChatRoom { get; set; }
    }

}
