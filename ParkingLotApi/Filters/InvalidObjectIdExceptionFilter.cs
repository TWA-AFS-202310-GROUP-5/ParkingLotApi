using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ParkingLotApi.Exceptions;

namespace ParkingLotApi.Filters
{
    public class InvalidObjectIdExceptionFilter : IActionFilter, IOrderedFilter
    {
        int IOrderedFilter.Order => int.MaxValue - 9;

        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Exception is InvalidObjectIdException inValidObjectIdException)
            {
                //context.Result = new NotFoundResult();
                context.Result = new NotFoundObjectResult(context.Exception.Message);
                context.ExceptionHandled = true;
            }
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
        }

    }
    
}
