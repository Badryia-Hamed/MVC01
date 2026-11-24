using System.Diagnostics;

namespace MVC01.Middelwares
{
    public class RequestTimeMiddelware
    {
        private readonly RequestDelegate next;

        public RequestTimeMiddelware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync( HttpContext context) // Need Address Of the next middelware 
                                                            // Detect From Constractor 
        {
            var stop = Stopwatch.StartNew();
            await next.Invoke(context);
            stop.Stop();
            Console.WriteLine($"{context.Request.Path} --> {stop.ElapsedMilliseconds} ms");

        }
    }
}
