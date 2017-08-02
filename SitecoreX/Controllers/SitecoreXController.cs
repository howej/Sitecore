using System.Web.Http;
using Sitecore.Configuration;
using Sitecore.Services.Infrastructure.Web.Http;

namespace SitecoreX.Controllers
{
    [RoutePrefix("api/v1")]
    public class SitecoreXController : ServicesApiController
    {
        [HttpGet]
        [Route("test")]
        public IHttpActionResult Test()
        {
            return Json(new
            {
                About.Version,
                Settings.LicenseFile,
                Settings.DataFolder
            });
        }
    }
}