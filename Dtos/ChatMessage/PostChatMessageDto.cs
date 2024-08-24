using System.ComponentModel.DataAnnotations;

namespace ASP.NET_SignalR.Dtos;

public class PostChatMessageDto
{
    [Required(ErrorMessage = "{0} is required")]
    [MinLength(1, ErrorMessage = "{0} must be {1} characters")]
    [MaxLength(120, ErrorMessage = "{0} can not be over {1} characters")]
    public string Message { get; set; } = string.Empty;
    [Required]
    public Guid ChatRoomId { get; set; }
}