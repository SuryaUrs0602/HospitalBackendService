
using System.Net;

namespace BackendService.Helpers
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }

            catch (DomainNotFoundException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                var errorResponse = new { error = ex.Message };
                await context.Response.WriteAsJsonAsync(errorResponse);
            }

            catch (DomainInternalServerError ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var errorResponse = new { error = ex.Message };
                await context.Response.WriteAsJsonAsync(errorResponse);
            }

            catch (DomainBadRequest ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var errorResponse = new { error = ex.Message };
                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
