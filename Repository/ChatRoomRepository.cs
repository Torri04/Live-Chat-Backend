using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_SignalR.Data;
using ASP.NET_SignalR.Interface;
using ASP.NET_SignalR.Model;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_SignalR.Repository
{
    public class ChatRoomRepository : IChatRoomRepository
    {
        private readonly MyDbContext _context;
        public ChatRoomRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<ChatRoom?> GetChatRoomById(Guid id)
        {
            return await _context.ChatRooms.FirstOrDefaultAsync(r => r.ChatRoomId == id);
        }

        public async Task<ChatRoom?> GetChatRoomByName(string roomName)
        {
            return await _context.ChatRooms.FirstOrDefaultAsync(r => r.RoomName == roomName);
        }

        public async Task<ChatRoom?> PostChatRoom(ChatRoom chatRoom)
        {
            await _context.AddAsync(chatRoom);
            await _context.SaveChangesAsync();

            var chatRoomAfter = await _context.ChatRooms.FirstOrDefaultAsync(p => p.ChatRoomId == chatRoom.ChatRoomId);
            return chatRoomAfter;
        }
    }
}