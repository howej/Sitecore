using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.Services.Core.Configuration;
using Sitecore.Services.Core.Diagnostics;
using Sitecore.Services.Infrastructure.Sitecore.Security;
using Sitecore.Services.Infrastructure.Web.Http.Security;

namespace SitecoreX.WebApi.DependencyInjection
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITokenProvider>(provider => new ConfiguredOrNullTokenProvider(provider.GetService<ConfigurationSettings>(), provider.GetService<ILogger>(), new SigningTokenProvider()));
        }
    }
}