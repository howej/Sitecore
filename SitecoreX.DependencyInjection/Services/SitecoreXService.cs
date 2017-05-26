using SitecoreX.DependencyInjection.Services.Abstractions;

namespace SitecoreX.DependencyInjection.Services
{
    public class SitecoreXService : ISitecoreXService
    {
        public string Version => typeof(SitecoreXService).Assembly.GetName().Version.ToString();
    }
}