using System.Security.Authentication;
using System.Security.Claims;
using System.Web.Http;
using Sitecore;
using Sitecore.Configuration;
using Sitecore.Security.Authentication;
using Sitecore.Services.Core.Configuration;
using Sitecore.Services.Core.Security;
using Sitecore.Services.Infrastructure.Web.Http;
using Sitecore.Services.Infrastructure.Web.Http.Security;

namespace SitecoreX.Controllers
{
    [RoutePrefix("api/v1")]
    public class SitecoreXController : ServicesApiController
    {
        //private readonly IUserService _userService;
        //private readonly ITokenProvider _tokenProvider;
        //private readonly ConfigurationSettings _configurationSettings;

        //public SitecoreXController(IUserService userService, ITokenProvider tokenProvider, Sitecore.Services.Core.Configuration.ConfigurationSettings configurationSettings)
        //{
        //    _userService = userService;
        //    _tokenProvider = tokenProvider;
        //    _configurationSettings = configurationSettings;
        //}

        //[HttpPost]
        //public IHttpActionResult Login(string domain, string username, string password)
        //{
        //    try
        //    {
        //        if (_configurationSettings.SitecoreServices.ItemService.AllowAnonymousUser && _configurationSettings.SitecoreServices.ItemService.AnonymousUser == username)
        //        {
        //            if (!AuthenticationManager.Login(domain + "\\" + username, true))
        //            {
        //                throw new AuthenticationException("Invalid username or password");
        //            }
        //        }
        //        else
        //        {
        //            _userService.Login(domain, username, password);
        //        }

        //        var token = _tokenProvider.GenerateToken(new []
        //        {
        //            new Claim("User", Context.User.Name)
        //        });
        //    }
        //}

        [HttpGet]
        [Route("test")]
        [Authorize(Users = "sitecore\\admin")]
        public IHttpActionResult Test()
        {
            return Json(new
            {
                SitecoreVersion = About.Version,
                User = User.Identity.Name
            });
        }
    }
}