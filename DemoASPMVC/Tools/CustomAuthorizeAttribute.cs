using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DemoASPMVC.Tools
{
    public class CustomAuthorizeAttribute : TypeFilterAttribute
    {
        public CustomAuthorizeAttribute() : base(typeof(AuthRequiredFilter))
        {
        }
    }

    public class AuthRequiredFilter : IAuthorizationFilter
    {
        private readonly SessionManager _session;
        public AuthRequiredFilter(SessionManager session)
        {
            _session = session;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(_session.ConnectedUser is null)
            {
                context.Result = new RedirectToRouteResult(new { action = "NotFound", Controller = "Home" });
            }
        }
    }
}
