using FluentValidation;
using The_Book_Circle._02.Business_Logic_Layer.Exceptions;

namespace The_Book_Circle._03.Presentation_Layer.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);

            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        public async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // log
            int statusCode = exception switch
            {
                ValidationException => StatusCodes.Status400BadRequest,
                StatusCodeException ex => ex.StatusCode,
                _ => StatusCodes.Status500InternalServerError
            };
            var response = new
            {
                error = statusCode == StatusCodes.Status500InternalServerError ? "Server Error" : exception.Message,
                statusCode
            };



            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsJsonAsync(response);
        }

        
    }
}
