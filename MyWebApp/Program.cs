//Web Application Object
var builder = WebApplication.CreateBuilder(args);

//Web App Object is ready here
var app = builder.Build();

//get me a response with following text
//app.MapGet("/", () => "Hello World!");  
app.Run(async (HttpContext context) =>
{
   context.Response.Headers["Content-type"] = "text/html";
   if(context.Response.Headers.ContainsKey("AuthorizationKey"))
   {
      string auth = context.Request.Headers["AuthorizationKey"];
      await context.Response.WriteAsync($"<p>{auth}</p>");
   }
   else
   {
      context.Response.StatusCode = 400;
      await context.Response.WriteAsync($"<p>unauthorized</p>");
   }
});

//To start the web server (Kestral/IIS)
app.Run();
