using JoyasNala.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JoyasNala.Data
{
    public class ApplicationDbInitializer
    {
        public static void SeedData(ApplicationDbContext context)
        {
            // Asegúrate de que se han aplicado todas las migraciones
            context.Database.Migrate();

            // Verificar si ya existen datos en la tabla Producto
            if (!context.Productos.Any())
            {
                context.Productos.AddRange(
                    new Producto { Nombre = "Anillo de Oro", Precio = 1500.00M, Descripcion = "Anillo de oro de 14k", ImagenUrl = "wwwroot/Images/anillo.jpg" },
                    new Producto { Nombre = "Collar de Plata", Precio = 800.00M, Descripcion = "Collar de plata esterlina", ImagenUrl = "wwwroot/Images/Collar.jpg" },
                    new Producto { Nombre = "Pulsera de Diamantes", Precio = 3000.00M, Descripcion = "Pulsera con incrustaciones de diamantes", ImagenUrl = "wwwroot/Images/pulsera.jpg" }
                );

                // Guarda los cambios
                context.SaveChanges();
            }



        }


        public static void SeedData(ApplicationDbContext context, UserManager<Usuario> userManager)
        {
            context.Database.Migrate();

            if (!userManager.Users.Any(u => u.Nombre == "nala"))
            {
                var adminUser = new Usuario
                {
                    
                    Nombre = "nala",
                    Email = "nala@ejemplo.com",
                    Rol = "Administrador"
                };
                userManager.CreateAsync(adminUser, "ContraseñaSegura123!").Wait();
            }
        }

    }
}