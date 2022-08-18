using ApiDemoApp.Services;
using Microsoft.EntityFrameworkCore;

//Via code mention the environment details
// var builder = WebApplication.CreateBuilder(new WebApplicationOptions{
//     EnvironmentName = Environments.Production,
// });

var builder = WebApplication.CreateBuilder();


//Content 
// Add services to the container.
builder.Services.AddControllers(options =>{
    //Obey requesr Headers
    options.RespectBrowserAcceptHeader = true;
    options.ReturnHttpNotAcceptable = true;        
}).AddXmlSerializerFormatters();


builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase(databaseName:"TodoList"));
//Register db context services

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDateTime, SystemDateTime>();
builder.Services.AddScoped<IHomeServices, HomeServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseSwagger();
    app.UseSwaggerUI();

    // //Serve app to the app route    
    // app.UseSwaggerUI(options => {
    //        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    //       options.RoutePrefix = string.Empty;
    // });
}

app.UseStatusCodePages();

app.UseHttpsRedirection();

app.UseAuthorization();

//Middlewares 

// app.Use(async (context, next) =>
// {
//     // Do work that can write to the Response.
//     await context.Response.WriteAsync("Hello from 2nd delegate.");
//     await next.Invoke();
//     // Do logging or other work that doesn't write to the Response.
// });

// app.Run(async context =>
// {
//     await context.Response.WriteAsync("Hello world!");
// });

//Attribute Routing
app.MapControllers();

// app.MapDefaultControllerRoute();

//conventional Routings
// app.MapControllerRoute(
//     name: "people",
//     pattern: "people/{ssn}",
//     constraints: new { ssn = "^\\d{3}-\\d{2}-\\d{4}$", },
//     defaults: new { controller = "People", action = "List" });
    
// app.UseRouting();

// app.UseEndpoints(endpoints =>
//     {
//         endpoints.MapControllerRoute(
//             name: "default",
//             pattern: "{controller=Home}/{action=Index}/{id?}");
//     });


// app.MapHealthChecks("/healthz").RequireAuthorization();
app.MapGet("/{name:alpha}",(string name) => $"Hello {name}" );

app.Run();
