using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ParkingLotApi.Exceptions;

namespace ParkingLotApi.Filters
{
    public class NotFoundExceptionFilter : IActionFilter, IOrderedFilter
    {
        int IOrderedFilter.Order => int.MaxValue - 8;

        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is NotFoundException notFoundException
                || context.Exception is InvalidPageIndexException invalidPageIndexException)
            {
                context.Result = new NotFoundResult();
                context.ExceptionHandled = true;
            }
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
        }

    }

}
