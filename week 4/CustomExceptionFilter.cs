
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class CustomExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        File.WriteAllText("ExceptionLog.txt", $"Exception: {context.Exception.Message}\nStackTrace:\n{context.Exception.StackTrace}");

        context.Result = new ObjectResult("Internal server error occurred")
        {
            StatusCode = 500
        };
    }
}
