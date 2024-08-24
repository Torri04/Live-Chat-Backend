
using ASP.NET_SignalR.Data;
using ASP.NET_SignalR.Data_Service;
using ASP.NET_SignalR.Dtos;
using ASP.NET_SignalR.Interface;
using ASP.NET_SignalR.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace ASP.NET_SignalR.Service
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly SharedDb _shared;
        private readonly MyDbContext _context;
        private readonly IChatRoomRepository _chatRoomRepository;
        private readonly IUserChatRoomRepository _userChatRoomRepository;
        private readonly IMapper _mapper;
        private readonly IChatMessageRepository _chatMessageRepository;
        public ChatHub(SharedDb shared, MyDbContext context, IChatRoomRepository chatRoomRepository, IUserChatRoomRepository userChatRoomRepository, IMapper mapper, IChatMessageRepository chatMessageRepository)
        {
            _mapper = mapper;
            _shared = shared;
            _context = context;
            _chatRoomRepository = chatRoomRepository;
            _userChatRoomRepository = userChatRoomRepository;
            _chatMessageRepository = chatMessageRepository;
        }

        public async Task JoinChat(UserConnection conn)
        {
            await Clients.All.SendAsync("ReceiveMessage", "admin", $"{conn.UserName} has joined");
        }
        public override async Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;

            var userChatRooms = await _userChatRoomRepository.GetAllChatRooms(userId);

            foreach (var userChatRoom in userChatRooms)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, userChatRoom.ChatRoom.RoomName);
            }

            await base.OnConnectedAsync();
        }
        public async Task JoinSpecificChatRoom(UserConnection conn)
        {
            var chatRoom = await _chatRoomRepository.GetChatRoomByName(conn.ChatRoom);

            if (chatRoom == null)
            {
                chatRoom = await _chatRoomRepository.PostChatRoom(new ChatRoom { RoomName = conn.ChatRoom });
            }

            var userChatRoom = await _userChatRoomRepository.PostUserChatRoom(new UserChatRoom { UserId = Context.UserIdentifier, ChatRoomId = chatRoom.ChatRoomId, ConnectionId = Context.ConnectionId });

            var userChatRoomDto = _mapper.Map<GetUserChatRoomDto>(userChatRoom);

            await Groups.AddToGroupAsync(Context.ConnectionId, conn.ChatRoom);

            _shared.connections[Context.ConnectionId] = conn;

            await Clients.Group(conn.ChatRoom).SendAsync("ReceiveJoinChatRoom", userChatRoomDto);
        }

        public async Task SendMessage(string msg, string chatRoomId)
        {
            var chatRoom = await _chatRoomRepository.GetChatRoomById(new Guid(chatRoomId));

            var chatMessage = await _chatMessageRepository.PostChatMessage(new ChatMessage { Message = msg, UserId = Context.UserIdentifier, ChatRoomId = chatRoom.ChatRoomId });
            var chatMessageDto = _mapper.Map<GetChatMessageDto>(chatMessage);

            await Clients.Group(chatRoom.RoomName).SendAsync("ReceiveMessage", chatMessageDto);
        }
    }
}