using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;

namespace WebApplication.ViewComponents
{
    public class RoomsViewComponent : ViewComponent
    {
        private readonly ChatContext _chatContext;

        public RoomsViewComponent(ChatContext chatContext)
        {
            _chatContext = chatContext;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var rooms = await _chatContext.Rooms.ToListAsync();
            return View(rooms);
        }
    }
}