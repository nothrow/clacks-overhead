using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace clacks.overhead
{
    /// <summary>
    ///     Man is not dead while his name is still spoken
    /// </summary>
    public class ClacksMiddleware
    {
        private const string ClacksOverheadHttpHeader = "X-Clacks-Overhead";
        private static readonly StringValues SirTerryPratchett = new StringValues("GNU Terry Pratchett");

        private readonly RequestDelegate _next;

        public ClacksMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        ///     Adds the X-Clacks-Overhead http parameter to the response
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public Task Invoke(HttpContext httpContext)
        {
            try
            {
                httpContext.Response.Headers.Add(ClacksOverheadHttpHeader, SirTerryPratchett);
            }
            catch (ArgumentException)
            {
                // Someone already added X-Clacks-Overhead. Deal with it gracefully
            }
            catch (NotSupportedException)
            {
                // We are not allowed to modify httpContext.
            }

            return _next.Invoke(httpContext);
        }
    }
}
