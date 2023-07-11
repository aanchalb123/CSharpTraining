namespace MiddleWare
{
   public class MyCustomMiddleware : IMiddleware
   {
      public async Task InvokeAsync(HttpContext context, RequestDelegate next)
      {
         await context.Response.WriteAsync("My Custom Middleware starts here \n");
         await next(context);
         await context.Response.WriteAsync("My Custom Middleware ends here \n");
      }
   }

   public static class CustomMiddlewareExtension
   {
      public static IApplicationBuilder useMyCustomMiddleware(this IApplicationBuilder app)
      {
         return app.UseMiddleware<MyCustomMiddleware>();
      }
   }
}
