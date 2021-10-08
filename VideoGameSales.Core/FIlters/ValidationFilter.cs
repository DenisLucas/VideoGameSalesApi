using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using VideoGameSales.Domain.Errors;

namespace VideoGameSales.Core.FIlters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState
                .Where(x=> x.Value.Errors.Count > 0).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(y => y.ErrorMessage)).ToArray();
                var errorResponse = new ErrorResponse();
                foreach (var error in errorsInModelState)
                {
                    foreach (var subError in error.Value)
                    {
                        var errorModel = new ErrorModel
                        {
                            FieldName = error.Key,
                            ErrorMessage = subError
                        };
                        errorResponse.ErrorMessage.Add(errorModel);
                    
                    }
                }
                context.Result = new BadRequestObjectResult(errorResponse);
            }
            await next();
        }
    }
}
