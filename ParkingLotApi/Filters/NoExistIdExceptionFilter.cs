﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ParkingLotApi.Exceptions;

namespace ParkingLotApi.Filters
{
    public class NoExistIdExceptionFilter : IActionFilter, IOrderedFilter
    {
        int IOrderedFilter.Order => int.MaxValue - 10;

        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is not null)
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
