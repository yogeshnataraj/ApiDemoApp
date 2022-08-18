using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiDemoApp.Filters
{
    public class SampleActionFilter :  Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine(context.Result);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
           Console.WriteLine(context.Result);
        }
    }
}
