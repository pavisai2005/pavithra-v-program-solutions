
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class CustomAuthFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out var token))
        {
            context.Result = new BadRequestObjectResult("Invalid request\nNo Auth token");
            return;
        }

        if (!token.ToString().Contains("Bearer"))
        {
            context.Result = new BadRequestObjectResult("Invalid request\nToken present but Bearer unavailable");
        }
    }
}
