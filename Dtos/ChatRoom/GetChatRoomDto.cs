using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ASP.NET_SignalR.Dtos
{
    public class GetChatRoomDto
    {
        public Guid ChatRoomId { get; set; }
        public string RoomName { get; set; } = string.Empty;
    }
}