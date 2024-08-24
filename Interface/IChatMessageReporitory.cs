using ASP.NET_SignalR.Model;

namespace ASP.NET_SignalR.Interface;

public interface IChatMessageRepository
{
    Task<List<ChatMessage>?> GetChatMessagesByChatRoomId(Guid chatRoomId);
    Task<ChatMessage?> PostChatMessage(ChatMessage chatMessage);
}