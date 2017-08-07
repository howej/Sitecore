using System;
using System.Net.Http.Formatting;
using System.Security.Authentication;
using System.Security.Claims;
using System.Web.Http;
using Sitecore;
using Sitecore.Configuration;
using Sitecore.Services.Infrastructure.Web.Http;
using Sitecore.Services.Infrastructure.Web.Http.Security;
using SitecoreX.WebApi.Security;

namespace SitecoreX.WebApi.Controllers
{
    [RoutePrefix("api/v1")]
    public class SitecoreXController : ServicesApiController
    {
        private readonly ITokenProvider _tokenProvider;

        public SitecoreXController()
        {
        }

        public SitecoreXController(ITokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider ?? throw new ArgumentNullException("tokenProvider");
        }

        [HttpPost, Route("auth/token")]
        public IHttpActionResult Login([FromBody]FormDataCollection form)
        {
            try
            {
                var username = form["username"];
                var password = form["password"];
                var domain = form["domain"];

                if (Sitecore.Security.Authentication.AuthenticationManager.Login(domain + "\\" + username, password))
                {
                    var token = _tokenProvider.GenerateToken(new[] { new Claim("User", Context.User.Name) });

                    if (token != null)
                    {
                        return Json(new { token });
                    }
                }                

                return Ok();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (AuthenticationException)
            {
                return Unauthorized();
            }
        }

        [HttpGet, Route("ver")]
        [Authorise(Users = "sitecore\\admin")]
        public IHttpActionResult Versions()
        {
            return Json(new
            {
                Sitecore = About.Version,
                Api = GetType().Assembly.GetName().Version.ToString(),
                User = User.Identity.Name
            });
        }
    }
}