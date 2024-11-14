using JoyasNala.Data;
using JoyasNala.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios de Razor Pages y controladores
builder.Services.AddRazorPages();
builder.Services.AddControllers(); // Registrar controladores para que Swagger los detecte

// Configuración de la conexión a la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

// Configurar el servicio de hashing de contraseñas
builder.Services.AddScoped<IPasswordHasher<Usuario>, PasswordHasher<Usuario>>();

//login
builder.Services.AddIdentity<Usuario, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


// Configuración de Swagger para documentar la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();  // Configurar Swagger

// Construir la aplicación después de registrar todos los servicios
var app = builder.Build();

// Configurar el seeding de datos de ejemplo
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();

    // Llamar al método de seeding para cargar datos de ejemplo
    ApplicationDbInitializer.SeedData(context);
}

//login

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<Usuario>>();
    await ApplicationDbInitializer.SeedData(userManager);
}


// Configuración del pipeline de solicitud HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        c.RoutePrefix = string.Empty; // Hacer que Swagger esté en la raíz (http://localhost:<puerto>/)
    });
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers(); // Mapear los controladores para que Swagger pueda encontrarlos

app.Run();
app.UseAuthentication();
app.UseAuthorization();
