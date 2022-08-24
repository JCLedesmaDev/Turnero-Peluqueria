
#region Usings globales para todo le proyecto Server 

global using Microsoft.EntityFrameworkCore;
global using Turnero.Helper;
global using Turnero.Shared.Comun;
global using Turnero.Shared.DTO_Back.Peluquero;

#endregion Usings globales para todo le proyecto Server */

using Microsoft.OpenApi.Models;
using Turnero.BaseDatos.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

#region Conexion a Base Datos y Config de Swagger

builder.Services.AddDbContext<BDContext>(options =>
    options.UseSqlServer(builder.Configuration
     .GetConnectionString("DefaultConnection"))
);


builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Turnero",
        Version = "v1",
    });
});

#endregion Juan: Conexion a Base Datos y Config de Swagger


#region Desactivamos la validacion automatica del modelState

builder.Services.Configure<Microsoft.AspNetCore.Mvc.ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

#endregion


var app = builder.Build();

#region Inforcoparacion de Swagger al Server 

app.UseSwagger();
app.UseSwaggerUI(config =>
{
    config.SwaggerEndpoint(
        "/swagger/v1/swagger.json",
        "Locacion v1"
    );
});

#endregion Juan: Inforcoparacion de Swagger al Server 


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
