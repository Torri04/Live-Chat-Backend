using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASP.NET_SignalR.Model;
using Microsoft.AspNetCore.Identity;

namespace ASP.NET_SignalR.Dtos
{
    public class GetUserChatRoomDto
    {
        public string UserId { get; set; } = string.Empty;
        public GetChatRoomDto? ChatRoom { get; set; }
        public DateTime JoinedAt { get; set; }
        public string ConnectionId { get; set; } = string.Empty;
    }
}