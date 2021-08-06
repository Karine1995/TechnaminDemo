using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class HttpResponseExtensions
    {
        public static async Task WriteErrorResponseAsync(this HttpResponse httpResponse, string message, Dictionary<string, string[]> errors, int statusCode)
        {
            var response = new { Message = message, Errors = errors };

            string responseJson = JsonConvert.SerializeObject(response, Formatting.Indented);
            httpResponse.StatusCode = statusCode;
            await httpResponse.WriteAsync(responseJson);
        }
    }
}
