using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WebApplication.Services;

namespace WebApplication.TagHelpers
{
    public abstract class LiquidTemplateTagHelperBase<T> : TagHelper
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly LiquidTemplateHelper _liquidTemplateHelper;

        public string LiquidTemplatePath { get; set; }
        public T Model { get; set; }
        
        public LiquidTemplateTagHelperBase(IWebHostEnvironment webHostEnvironment, LiquidTemplateHelper liquidTemplateHelper)
        {
            _webHostEnvironment = webHostEnvironment;
            _liquidTemplateHelper = liquidTemplateHelper;
        }
        
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            var html = await _liquidTemplateHelper.RenderTemplateForModel(LiquidTemplatePath, Model);
            output.Content.SetHtmlContent(html);
        }
    }
}