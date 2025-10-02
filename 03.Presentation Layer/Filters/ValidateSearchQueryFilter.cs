using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using The_Book_Circle.DTOs;

namespace The_Book_Circle._03.Presentation_Layer.Filters
{
    public class ValidateSearchQueryFilter : IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            string query = context.HttpContext.Request.Query["query"];
            if (string.IsNullOrWhiteSpace(query))
            {

                var response = new ApiResponse<object>
                {
                    IsSuccess = false,
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Query parameter cannot be null or empty"
                };
                context.Result = new BadRequestObjectResult(response);
            }
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
