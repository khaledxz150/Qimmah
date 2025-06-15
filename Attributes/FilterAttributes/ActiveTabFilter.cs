using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Qimmah.Attributes.FilterAttributes
{
    public class ActiveTabFilter : IActionFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string TabCookieName = "ActiveTab";

        public ActiveTabFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controllerActionDescriptor = context.ActionDescriptor as Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor;

            var attribute = controllerActionDescriptor.MethodInfo
             .GetCustomAttributes(typeof(ActiveTabAttribute), inherit: true)
             .OfType<ActiveTabAttribute>()
             .FirstOrDefault();


            if (attribute != null)
            {
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(1),
                    HttpOnly = false, // Set to false so JavaScript can read it
                    Secure = true,
                    SameSite = SameSiteMode.Lax
                };

                _httpContextAccessor.HttpContext?.Response.Cookies.Delete(TabCookieName);
                _httpContextAccessor.HttpContext?.Response.Cookies.Append(
                    TabCookieName,
                    attribute.Tab.ToString(),
                    cookieOptions
                );
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
