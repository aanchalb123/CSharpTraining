var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//enble routing 
app.UseRouting();

//connect your endpoints(Resources)
app.UseEndpoints(endpoints =>
{
   //add your endpoints here
   endpoints.Map("files/{filename}.{extension}", async (context) =>
   {
      string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
      string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
      await context.Response.WriteAsync($" In file - {filename} - {extension}");
   });

   endpoints.Map("files/{filename}.{extension}", async (context) =>
   {
      string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
      string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
      await context.Response.WriteAsync($" In file - {filename} - {extension}");
   });

   endpoints.Map("employee/profile/{EmployeeName:length(4,7):alpha=Aanchal}", async (context) =>
   {
      string? employeename = Convert.ToString(context.Request.RouteValues["EmployeeName"]);
      await context.Response.WriteAsync($" In employee profile - {employeename} ");
   });

   endpoints.Map("products/details/{Id:int:range(1,100)?}", async (context) =>
   {
      if(context.Request.RouteValues.ContainsKey("Id"))
      {
         var id =Convert.ToInt32(context.Request.RouteValues["Id"]) ;
         await context.Response.WriteAsync($"product detail for {id}");

      }
      else
      {
         await context.Response.WriteAsync($"product detail - id is not supplied");
      }
     
   });

   //---------------OR----------------------
   //endpoints.MapGet("map1", async (context) =>
   //{
   //   await context.Response.WriteAsync("In map1");
   //});

   //endpoints.MapGet("map2", async (context) =>
   //{
   //   await context.Response.WriteAsync("In map2");
   //});

   //endpoints.MapGet("map3", async (context) =>
   //{
   //   await context.Response.WriteAsync("In map3");
   //});

});

app.Run(async (context) =>
{
   await context.Response.WriteAsync($"no record match at {context.Request.Path}");
});
app.Run();
