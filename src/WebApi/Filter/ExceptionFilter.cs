using Application.Exceptions;
using Application.Wrappers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace WebApi.Filter
{
    public class ExceptionFilter:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var ExceptionType = context.Exception.GetType();

            if (ExceptionType == typeof(NotFoundException))
            {
                var exception = (NotFoundException)context.Exception;
                context.Result = new NotFoundObjectResult(new CustomActionResult
                {
                    Success = false,
                    Message = exception.Message,

                });

                context.ExceptionHandled = true;
                
            }

            else if (ExceptionType == typeof(CustomValidationException))
            {
                var exception = (CustomValidationException)context.Exception;
                context.Result = new BadRequestObjectResult(new CustomActionResult
                {
                    Success = false,
                    Errors = exception.Errors,
                });

                context.ExceptionHandled = true;
            }

            else if (ExceptionType == typeof(CustomException))
            {
                var exception = (CustomException)context.Exception;
                context.Result = new BadRequestObjectResult(new CustomActionResult
                {
                      Success = false,
                      Message= exception.Message,
                });

                context.ExceptionHandled = true;
            }
            else
            {
                context.Result = new BadRequestObjectResult(new CustomActionResult
                {
                    Success = false,
                    Message = "unhandled error occured"
                });
            }



           


            base.OnException(context);
        }
    }
}
