using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ASP.NET_SignalR.Dtos
{
    public class PostChatRoomDto
    {
        [Required(ErrorMessage = "{0} is required")]
        [MinLength(1, ErrorMessage = "{0} must be {1} characters")]
        [MaxLength(120, ErrorMessage = "{0} can not be over {1} characters")]
        public string RoomName { get; set; } = string.Empty;
    }
}