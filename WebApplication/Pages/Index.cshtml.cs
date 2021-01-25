using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ChatContext _chatContext;

        public IndexModel(ChatContext chatContext)
        {
            _chatContext = chatContext;
        }
        
        public IList<Room> Rooms { get; set; }
        
        public async Task OnGetAsync()
        {
            Rooms = await _chatContext.Rooms.ToListAsync();
        }

        public async Task<IActionResult> OnPost(string name)
        {
            await _chatContext.Rooms.AddAsync(new Room() {Name = name});
            await _chatContext.SaveChangesAsync();
            return ViewComponent("Rooms");
        }

        public async Task<IActionResult> OnDelete(int id)
        {
            var room = await _chatContext.Rooms.FirstAsync(r => r.Id == id);
            _chatContext.Rooms.Remove(room);
            await _chatContext.SaveChangesAsync();
            return ViewComponent("Rooms");
        }
    }
}