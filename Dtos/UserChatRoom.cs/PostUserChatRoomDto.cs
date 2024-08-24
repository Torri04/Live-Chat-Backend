using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ASP.NET_SignalR.Dtos
{
    public class PostUserChatRoomDto
    {
        public Guid ChatRoomId { get; set; }
        public string ConnectionId { get; set; } = string.Empty;
    }
}