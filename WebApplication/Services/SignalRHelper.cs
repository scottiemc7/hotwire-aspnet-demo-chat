using System.IO;
using System.Threading.Tasks;
using Fluid;
using Microsoft.AspNetCore.SignalR;

namespace WebApplication.Services
{
    public class SignalRHelper
    {
        private readonly LiquidTemplateHelper _liquidTemplateHelper;

        public SignalRHelper(LiquidTemplateHelper liquidTemplateHelper)
        {
            _liquidTemplateHelper = liquidTemplateHelper;
        }
        
        public async Task SendLiquidTemplateAsync<K>(IClientProxy clientProxy, string method, string liquidTemplatePath, string action, string target, K model)
        {
            var renderedTemplate = await _liquidTemplateHelper.RenderTemplateForModel(liquidTemplatePath, model);
            var wrappedContent =
                $"<turbo-stream action=\"{action}\" target=\"{target}\"><template>{renderedTemplate}</template></turbo-stream>";
            
            await clientProxy.SendAsync(method, wrappedContent);
        }
    }
}