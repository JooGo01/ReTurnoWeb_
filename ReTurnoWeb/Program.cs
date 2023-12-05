using Microsoft.EntityFrameworkCore;
using ReTurnoWeb.Models;
using ReTurnoWeb.Servicios.Contrato;
using ReTurnoWeb.Servicios.Implementacion;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ReTurnoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSql"));
});

//permite usar este servicio en cualquier controlador
builder.Services.AddScoped<IUsuario, UsuarioService>();


//autenticacion por cookies configuracion
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opciones => {
    opciones.LoginPath = "/Inicio/IniciarSesion";
    opciones.ExpireTimeSpan = TimeSpan.FromMinutes(20);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


//habilita la autenticacion por cookies 
app.UseAuthentication();
//

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Inicio}/{action=IniciarSesion}/{id?}");

app.Run();
