using Common.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnaminDemo.Filters
{
    /// <summary>
    /// Model Validation action filter for take all requested action context 
    /// </summary>
    internal class ModelValidationFilter : IAsyncActionFilter
    {
        /// <summary>
        /// Called asynchronously before the action, after model binding is complete.
        /// </summary>
        /// <param name="context">The Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext.</param>
        /// <param name="next">The Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate. Invoked to execute the next action filter or the action itself.</param>
        /// <returns>A System.Threading.Tasks.Task that on completion indicates the filter has executed.</returns>       
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ModelStateDictionary modelState = context.ModelState;

            if (!modelState.IsValid)
            {
                var (message, errors) = BindErrorResponse(context.ModelState);
                await context.HttpContext.Response.WriteErrorResponseAsync(message, errors, StatusCodes.Status400BadRequest);
                return;
            }

            await next();
        }

        private static (string Message, Dictionary<string, string[]> Errors) BindErrorResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(k => k.Key, v => v.Value.Errors.Select(e => e.ErrorMessage).ToArray());

            return new()
            {
                Message = "Bad request",
                Errors = errors
            };
        }
    }
}
