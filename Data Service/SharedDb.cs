using System.Collections.Concurrent;
using ASP.NET_SignalR.Model;


namespace ASP.NET_SignalR.Data_Service
{
    public class SharedDb
    {
        private readonly ConcurrentDictionary<string, UserConnection> _connections = new ConcurrentDictionary<string, UserConnection>();
        public ConcurrentDictionary<string, UserConnection> connections => _connections;
    }
}