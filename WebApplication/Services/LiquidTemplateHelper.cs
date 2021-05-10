using System.IO;
using System.Threading.Tasks;
using Fluid;
using Microsoft.AspNetCore.Hosting;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class LiquidTemplateHelper
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly TemplateOptions _templateOptions;

        public LiquidTemplateHelper(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;

            _templateOptions = new TemplateOptions();
            _templateOptions.MemberAccessStrategy.Register<Message>();
        }

        public async Task<string> RenderTemplateForModel<K>(string liquidTemplatePath, K model)
        {
            //Put some caching mechanism here.
            var path = Path.Combine(_webHostEnvironment.ContentRootPath, "Pages", liquidTemplatePath);
            var template = new FluidParser().Parse(await File.ReadAllTextAsync(path));
            return await template.RenderAsync(new TemplateContext(model, _templateOptions).SetValue(typeof(K).Name, model));
        }
    }
}