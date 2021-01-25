using System.IO;
using System.Threading.Tasks;
using Fluid;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication.Services
{
    public class LiquidTemplateHelper
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LiquidTemplateHelper(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> RenderTemplateForModel<K>(string liquidTemplatePath, K model)
        {
            //Put some caching mechanism here.
            var path = Path.Combine(_webHostEnvironment.ContentRootPath, "Pages", liquidTemplatePath);
            var template = FluidTemplate.Parse(await File.ReadAllTextAsync(path));
            return await template.RenderAsync(new TemplateContext(model).SetValue(typeof(K).Name, model));
        }
    }
}