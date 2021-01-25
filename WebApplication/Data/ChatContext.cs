using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Data
{
    public class ChatContext : DbContext
    {
        public ChatContext (DbContextOptions<ChatContext> options, IWebHostEnvironment webHostEnvironment)
            : base(options)
        {
            //Define the 'DataDirectory' or else ef core and ef core tools won't know where to find it.
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(webHostEnvironment.ContentRootPath, "App_Data"));
        }
        
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}