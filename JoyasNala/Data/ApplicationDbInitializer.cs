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
                    new Producto { Nombre = "Anillo de Oro", Precio = 1500.00M, Descripcion = "Anillo de oro de 14k", ImagenUrl = "~/Images/anillo.jpg" },
                    new Producto { Nombre = "Collar de Plata", Precio = 800.00M, Descripcion = "Collar de plata esterlina", ImagenUrl = "~/Images/Collar.jpg" },
                    new Producto { Nombre = "Pulsera de Diamantes", Precio = 3000.00M, Descripcion = "Pulsera con incrustaciones de diamantes", ImagenUrl = "~/Images/pulsera.jpg" }
                );

                // Guarda los cambios
                context.SaveChanges();
            }



        }


        public static async Task SeedData(UserManager<Usuario> userManager)
        {
            if (await userManager.FindByEmailAsync("nala@example.com") == null)
            {
                var usuario = new Usuario
                {
                    Nombre = "nala@example.com",
                    Email = "nala@example.com",
                    Rol = "Administrador"
                };

                await userManager.CreateAsync(usuario, "ContraseñaSegura123!");
            }
        }

    }
}