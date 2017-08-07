using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sitecore.Services.Core.Security;
using Sitecore.Services.Infrastructure.Web.Http.Security;

namespace SitecoreX.WebApi.DelegatingHandlers
{
    public class TokenDelegatingHandler : DelegatingHandler
    {
        private readonly ITokenProvider _tokenProvider;
        private readonly IUserService _userService;

        public TokenDelegatingHandler(ITokenProvider tokenProvider, IUserService userService)
        {
            _tokenProvider = tokenProvider;
            _userService = userService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            AttemptLoginWithToken(request);
            return await base.SendAsync(request, cancellationToken);
        }

        private void AttemptLoginWithToken(HttpRequestMessage request)
        {
            if (request.Headers.Contains("token"))
            {
                var validationResult = _tokenProvider.ValidateToken(request.Headers.GetValues("token").FirstOrDefault());

                if (validationResult != null && validationResult.IsValid && validationResult.Claims.Count(c => c.Type == "User") == 1)
                {
                    _userService.SwitchToUser(validationResult.Claims.First(c => c.Type == "User").Value);

                    return;
                }
            }

            if (!_userService.IsAnonymousUser)
            {
                _userService.Logout();
            }
        }
    }
}