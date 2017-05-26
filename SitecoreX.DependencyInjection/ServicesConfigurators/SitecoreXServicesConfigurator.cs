using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using SitecoreX.DependencyInjection.Services;
using SitecoreX.DependencyInjection.Services.Abstractions;

namespace SitecoreX.DependencyInjection.ServicesConfigurators
{
    public class SitecoreXServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ISitecoreXDependencyInjectionService, SitecoreXDependencyInjectionService>();
        }
    }
}