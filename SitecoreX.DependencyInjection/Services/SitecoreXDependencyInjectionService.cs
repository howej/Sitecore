using SitecoreX.DependencyInjection.Services.Abstractions;

namespace SitecoreX.DependencyInjection.Services
{
    public class SitecoreXDependencyInjectionService: ISitecoreXDependencyInjectionService
    {
        public string Version => typeof(SitecoreXDependencyInjectionService).Assembly.GetName().Version.ToString();
    }
}