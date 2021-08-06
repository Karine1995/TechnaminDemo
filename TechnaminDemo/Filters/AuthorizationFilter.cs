using System;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TechnaminDemo.Infrastructure;

namespace TechnaminDemo.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AuthorizationFilter : Attribute, IFilterMetadata, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                string input = context.HttpContext.Request.Headers["Authorization"];
                if (input != null)
                {
                    AuthenticationHeaderValue authenticationHeaderValue = AuthenticationHeaderValue.Parse(input);
                    if (authenticationHeaderValue.Scheme.Equals(AuthenticationSchemes.Basic.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        string[] headerValue = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationHeaderValue.Parameter ?? string.Empty)).Split(':', 2);

                        if (IsAuthorized(headerValue[0], headerValue[1]))
                            return;
                    }
                }

                Unauthorized(context);
            }
            catch
            {
                Unauthorized(context);
            }
        }

        private static bool IsAuthorized(string username, string password) => username == User.Username && password == User.Password;

        private static void Unauthorized(AuthorizationFilterContext context) => context.Result = new UnauthorizedResult();
    }

    public class AutorizationAttribute : TypeFilterAttribute
    {
        public AutorizationAttribute()
            : base(typeof(AuthorizationFilter))
        {

        }
    }
}
