using MiddleWare;

var builder = WebApplication.CreateBuilder(args);

//This is depecdency injection
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");     //default

//--------------OR------------------

//only "Hello from first Middleware" will be shown
//app.Run(async (HttpContext context) =>
//{
//   await context.Response.WriteAsync("Hello from first Middleware");
//});

//app.Run(async (HttpContext context) =>
//{
//   await context.Response.WriteAsync("Hello from 2nd Middleware");
//});

//app.Run(async (HttpContext context) =>
//{
//   await context.Response.WriteAsync("Hello from 3rd Middleware");
//});

//app.Run(async (HttpContext context) =>
//{
//   await context.Response.WriteAsync("Hello from 4th Middleware");
//});

//--------------OR------------------

//All Middleware will be shown
//---------Middleware1------------
app.Use(async (context, next) =>
{
   //authorization
   await context.Response.WriteAsync("from Middleware one \n");
   await next();
});

//---------Middleware2------------
app.Use(async (context, next) =>
{
   //authorization
   await context.Response.WriteAsync("from Middleware two \n");
   await next();
});

//use Custom Middleware pipeline
//app.UseMiddleware<MyCustomMiddleware>();
app.useMyCustomMiddleware();

//---------Middleware3------------
app.Run(async (context) =>
{
   //redirection
   await context.Response.WriteAsync("from Middleware Three \n");
});

app.Run();
