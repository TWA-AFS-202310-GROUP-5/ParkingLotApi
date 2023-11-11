using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ParkingLotApi.Exceptions;

namespace ParkingLotApi.Filters
{
    public class ExceptionFilter : IActionFilter, IOrderedFilter
    {
        int IOrderedFilter.Order => 2;
        public int Order => throw new NotImplementedException();

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is InvalidCapacityException)
            {
                context.Result = new BadRequestObjectResult(context.Exception.Message);
                context.ExceptionHandled = true;
            }
            if (context.Exception is IDNotExistException)
            {
                context.Result = new NotFoundObjectResult(context.Exception.Message);
                context.ExceptionHandled = true;
                
            }
            if (context.Exception is NameAlreadyExistException)
            {
                context.Result = new BadRequestObjectResult(context.Exception.Message);
                context.ExceptionHandled = true;
            }
            if (context.Exception is PageIndexException)
            {
                context.Result = new BadRequestObjectResult(context.Exception.Message);
                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
