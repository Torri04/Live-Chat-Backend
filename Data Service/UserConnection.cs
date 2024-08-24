using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_SignalR.Data_Service
{
    public class UserConnection
    {
        public Guid UserConnectionId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string ConnectionId { get; set; } = string.Empty;
        public string ChatRoom { get; set; } = string.Empty;
    }
}