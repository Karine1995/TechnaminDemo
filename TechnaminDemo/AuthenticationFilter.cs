using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace TechnaminDemo
{
    public class AuthenticationFilter : Attribute, IFilterMetadata, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                string input = context.HttpContext.Request.Headers["Authorization"];
                if(input != null)
                {
                    AuthenticationHeaderValue authenticationHeaderValue = AuthenticationHeaderValue.Parse(input);
                    if (authenticationHeaderValue.Scheme.Equals(AuthenticationSchemes.Basic.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        string[] headerValue = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationHeaderValue.Parameter ?? string.Empty)).Split(':', 2);
                        if (!Authorized(headerValue[0], headerValue[1]))
                        {
                            Unauthorized(context);
                        }
                    }
                }
            }
            catch
            {
                Unauthorized(context);
            }
        }

        private bool Authorized(string username, string password)
        {
            return (username == User.Username && password == User.Password);
        }

        private void Unauthorized(AuthorizationFilterContext context)
        {
            context.Result = new UnauthorizedResult();
        }
    }
}
