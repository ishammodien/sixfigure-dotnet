using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CompanyEmployees.Presentation.ActionFilters
{
    // This class defines a custom action filter attribute for ASP.NET Core
    // that validates incoming model state and checks for null DTOs.
    public class ValidationFilterAttribute : IActionFilter
    {
        /// <summary> Constructor for the ValidationFilterAttribute class.
        /// The current implementation identifies DTOs by checking if their name contains "Dto". 
        /// This might not always be accurate, especially if naming conventions change.
        /// Consider logging or additional error handling to provide more detailed diagnostics.
        /// The filter assumes there's only one DTO, which may not hold true if an action accepts multiple DTOs or if a DTO does not include "Dto" in its name.
        /// </summary>
        public ValidationFilterAttribute()
        {
        }

        // This method is called before an action method executes.
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Retrieve the name of the action method being executed.
            var action = context.RouteData.Values["action"];

            // Retrieve the name of the controller containing the action method.
            var controller = context.RouteData.Values["controller"];

            // Attempt to find a parameter in the action's arguments whose name contains "Dto".
            // This assumes the action method is using a DTO (Data Transfer Object) as a parameter.
            var param = context.ActionArguments
                .SingleOrDefault(x => x.Value.ToString().Contains("Dto")).Value;

            // If no DTO parameter is found (i.e., it's null), set the result to a BadRequest
            // with an error message indicating that the object is null.
            if (param is null)
            {
                context.Result = new BadRequestObjectResult($"Object is null. Controller: {controller}, action: {action}");
                return;
            }

            /*
                ASP.NET Core automatically performs model validation when using data annotations. 
                This filter checks if the model state is valid and returns a response indicating validation errors if not.
             */
            // If the model state is not valid, set the result to an Unprocessable Entity
            // with the current model state, indicating validation errors.
            if (!context.ModelState.IsValid)
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
        }

        // This method is called after an action method executes.
        // It is not used in this filter, so it is empty.
        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
