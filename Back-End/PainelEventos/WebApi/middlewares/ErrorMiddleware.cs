using Domain.Shared.Exceptions;

namespace WebApi.middlewares
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                var problemDetails = new ResultErrorApi();

                if (exception is DomainInvalidException)
                {
                    problemDetails.Erros = (exception as DomainInvalidException).Errors;

                    context.Response.StatusCode =
                        StatusCodes.Status400BadRequest;
                }
                else if (exception is DirectoryNotFoundException)
                {
                    problemDetails.AddError(exception.Message);

                    context.Response.StatusCode =
                        StatusCodes.Status404NotFound;
                }
                else
                {
                    problemDetails.AddError(exception.Message);

                    context.Response.StatusCode =
                        StatusCodes.Status500InternalServerError;
                }

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }
    }
}
