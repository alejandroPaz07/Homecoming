
using Homecoming.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<HomecomingContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ConexionSql")));

// Configuración de Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<HomecomingContext>()
    .AddDefaultTokenProviders();

// Configuración de las cookies de autenticación
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Auth/Login";
    options.AccessDeniedPath = "/Auth/Login";
});

var app = builder.Build();

// Crear automáticamente el administrador
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider
        .GetRequiredService<RoleManager<IdentityRole>>();

    var userManager = scope.ServiceProvider
        .GetRequiredService<UserManager<IdentityUser>>();

    const string rol = "Administrador";

    if (!await roleManager.RoleExistsAsync(rol))
    {
        await roleManager.CreateAsync(new IdentityRole(rol));
    }

    var usuario = builder.Configuration["AdminAccount:Username"];
    var contrasena = builder.Configuration["AdminAccount:Password"];

    if (string.IsNullOrWhiteSpace(usuario) ||
        string.IsNullOrWhiteSpace(contrasena))
    {
        throw new Exception(
            "No se configuraron las credenciales del administrador.");
    }

    var administrador = await userManager.FindByNameAsync(usuario);

    if (administrador == null)
    {
        administrador = new IdentityUser
        {
            UserName = usuario
        };

        var resultado = await userManager.CreateAsync(
            administrador, contrasena);

        if (!resultado.Succeeded)
        {
            throw new Exception(string.Join("; ",
                resultado.Errors.Select(e => e.Description)));
        }
    }

    if (!await userManager.IsInRoleAsync(administrador, rol))
    {
        await userManager.AddToRoleAsync(administrador, rol);
    }
}

// Configuración de la aplicación
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
