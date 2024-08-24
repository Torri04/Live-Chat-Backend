using System.ComponentModel.DataAnnotations;

namespace ASP.NET_SignalR.Dtos;

public class GetChatMessageDto
{
    public Guid ChatMessageId { get; set; }
    public string Message { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
    public Guid ChatRoomId { get; set; }
    public GetAppUserDto? User { get; set; }
}