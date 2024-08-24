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
    public class UserChatRoomRepository : IUserChatRoomRepository
    {
        private readonly MyDbContext _context;
        public UserChatRoomRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserChatRoom>> GetAllChatRooms(string id)
        {
            return await _context.UserChatRooms.Include(x => x.ChatRoom).Where(x => x.UserId == id).ToListAsync();
        }
        public async Task<UserChatRoom?> PostUserChatRoom(UserChatRoom userChatRoom)
        {
            await _context.AddAsync(userChatRoom);
            await _context.SaveChangesAsync();

            var userChatRoomAfter = await _context.UserChatRooms.Include(p => p.ChatRoom).FirstOrDefaultAsync(p => p.ChatRoomId == userChatRoom.ChatRoomId && p.UserId == userChatRoom.UserId);
            return userChatRoomAfter;
        }
    }
}