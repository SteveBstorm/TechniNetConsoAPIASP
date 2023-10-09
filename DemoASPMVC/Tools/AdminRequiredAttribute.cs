using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DemoASPMVC.Tools
{
    public class AdminRequiredAttribute : TypeFilterAttribute
    {
        public AdminRequiredAttribute() : base(typeof(AdminRequiredFilter))
        {
        }
    }

    public class AdminRequiredFilter : IAuthorizationFilter
    {
        private readonly SessionManager _session;
        public AdminRequiredFilter(SessionManager session)
        {
            _session = session;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (_session.ConnectedUser is null || _session.ConnectedUser.RoleName != "Admin")
            {
                context.Result = new RedirectToRouteResult(new { action = "NotFound", Controller = "Home" });
            }
        }
    }
}
