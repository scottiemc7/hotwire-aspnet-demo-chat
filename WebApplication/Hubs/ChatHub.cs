using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace WebApplication.Hubs
{
    public class ChatHub : Hub
    {
        public async Task ListenForMessages(string roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        }
    }
}