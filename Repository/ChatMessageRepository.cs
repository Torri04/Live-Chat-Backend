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
    public class ChatMessageRepository : IChatMessageRepository
    {
        private readonly MyDbContext _context;
        public ChatMessageRepository(MyDbContext context)
        {
            _context = context;
        }
        public async Task<List<ChatMessage>?> GetChatMessagesByChatRoomId(Guid chatRoomId)
        {
            return
            await _context.ChatMessages
            .Include(p => p.User)
            .Where(p => p.ChatRoomId == chatRoomId)
            .OrderBy(p => p.Timestamp)
            .ToListAsync();
        }
        public async Task<ChatMessage?> PostChatMessage(ChatMessage chatMessage)
        {
            await _context.AddAsync(chatMessage);
            await _context.SaveChangesAsync();

            var chatMessages = await _context.ChatMessages.Include(p => p.User).FirstOrDefaultAsync(p => p.ChatMessageId == chatMessage.ChatMessageId);
            return chatMessages;
        }
    }
}