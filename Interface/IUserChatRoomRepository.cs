using ASP.NET_SignalR.Model;

namespace ASP.NET_SignalR.Interface;

public interface IUserChatRoomRepository
{
    Task<List<UserChatRoom>> GetAllChatRooms(string id);
    Task<UserChatRoom?> PostUserChatRoom(UserChatRoom userChatRoom);
}