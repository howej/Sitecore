using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;

namespace SitecoreX.WebApi.Security
{
    public class AuthoriseAttribute : System.Web.Http.AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var principal = actionContext.ControllerContext.RequestContext.Principal;

            if (principal != null && principal.Identity != null && (Users.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Contains(principal.Identity.Name) || Roles.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Any(role => principal.IsInRole(role))))
            {
                return;
            }

            HandleUnauthorizedRequest(actionContext);

            actionContext.Response = actionContext.ControllerContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorised request.");
        }
    }
}