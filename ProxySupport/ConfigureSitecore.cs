using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Sitecore.Framework.Runtime.Configuration;
using Sitecore.Framework.Runtime.Hosting;
using Sitecore.Framework.Runtime.Plugins;

namespace Sitecore.Identity.ProxySupport
{
    public class ConfigureSitecore
    {
        private readonly string _publicOrigin;

        public ConfigureSitecore(ISitecoreConfiguration scConfig, ISitecorePluginManager pluginManager)
        {
            _publicOrigin = scConfig.GetSection("Sitecore:ProxySupport:PublicOrigin").Value;
        }

        public void ConfigureStart(IApplicationBuilder app, ISitecoreHostingEnvironment scEnv)
        {
            if (!string.IsNullOrEmpty(_publicOrigin))
            {
                app.Use(async (context, next) =>
                {
                    var origin = new Uri(_publicOrigin);
                    
                    context.Request.Scheme = origin.Scheme;
                    context.Request.Host = new HostString(origin.Authority);
                    
                    await next();
                });
            }
        }
    }
}
