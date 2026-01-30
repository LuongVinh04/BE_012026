namespace BE_012026.NetCoreApi.MiddleWare
{
    public class MyMiddleWare

    {
        private readonly RequestDelegate _next; 
        public MyMiddleWare(RequestDelegate next)
        { 
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers.Append("My-headers", "LuongVinh");
            //await context.Response.WriteAsync("Hello World!");

            await _next(context);
        }
    }
}
