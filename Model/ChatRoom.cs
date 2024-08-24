using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ASP.NET_SignalR.Model
{
    [Table("ChatRoom")]
    public class ChatRoom
    {
        [Key]
        public Guid ChatRoomId { get; set; } = Guid.NewGuid();
        public string RoomName { get; set; } = string.Empty;
        public List<ChatMessage>? ChatMessages { get; set; }
        public List<UserChatRoom>? UserChatRooms { get; set; }
    }
}