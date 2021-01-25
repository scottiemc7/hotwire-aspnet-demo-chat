using System.IO;
using System.Threading.Tasks;
using Fluid;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.TagHelpers
{
    public class MessageTagHelper: LiquidTemplateTagHelperBase<Message>
    {
        public MessageTagHelper(IWebHostEnvironment webHostEnvironment, LiquidTemplateHelper liquidTemplateHelper) :
            base(webHostEnvironment, liquidTemplateHelper)
        {
        }
    }
}