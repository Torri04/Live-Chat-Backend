using ASP.NET_SignalR.Model;

namespace ASP.NET_SignalR.Interface;

public interface IChatRoomRepository
{
    Task<ChatRoom?> PostChatRoom(ChatRoom chatRoom);
    Task<ChatRoom?> GetChatRoomByName(string roomName);
    Task<ChatRoom?> GetChatRoomById(Guid id);

}