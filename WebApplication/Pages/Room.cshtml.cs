using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Hubs;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Pages
{
    public class RoomModel : PageModel
    {
        private readonly ChatContext _chatContext;
        private readonly IHubContext<ChatHub> _chatHubContext;
        private readonly SignalRHelper _signalRHelper;

        public RoomModel(ChatContext chatContext, IHubContext<ChatHub> chatHubContext, SignalRHelper signalRHelper)
        {
            _chatContext = chatContext;
            _chatHubContext = chatHubContext;
            _signalRHelper = signalRHelper;
        }
        
        public Room Room { get; private set; }

        public async Task OnGet(int id)
        {
            Room = await _chatContext.Rooms.Include(r => r.Messages).FirstAsync(r => r.Id == id);
        }

        public async Task<IActionResult> OnPostMessage(int id, string message)
        {
            var msg = await _chatContext.Messages.AddAsync(new Message {RoomId = id, Content = message});
            await _chatContext.SaveChangesAsync();

            await _signalRHelper.SendLiquidTemplateAsync(_chatHubContext.Clients.Group(id.ToString()), "MessageReceived",
                "Shared/Templates/Message.liquid",
                "append",
                "messages",
                new Message {Id = msg.Entity.Id, RoomId = id, Content = message});
            
            return new EmptyResult();
        }
    }
}