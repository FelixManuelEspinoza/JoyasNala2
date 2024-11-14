using Microsoft.AspNetCore.Identity;
using JoyasNala.Models;
using JoyasNala.Data;
using Microsoft.EntityFrameworkCore;

public class UsuarioService
{
    private readonly ApplicationDbContext _context;
    private readonly IPasswordHasher<Usuario> _passwordHasher;

    public UsuarioService(ApplicationDbContext context, IPasswordHasher<Usuario> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    public async Task CrearUsuarioAsync(string nombre, string email, string rol, string password)
    {
        var usuario = new Usuario
        {
            Nombre = nombre,
            Email = email,
            Rol = rol
        };

        // Generar el hash de la contraseña
        usuario.PasswordHash = _passwordHasher.HashPassword(usuario, password);

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task<Usuario> ValidarUsuarioAsync(string email, string password)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        if (usuario != null)
        {
            var result = _passwordHasher.VerifyHashedPassword(usuario, usuario.PasswordHash, password);
            if (result == PasswordVerificationResult.Success)
            {
                return usuario; // Autenticación exitosa
            }
        }
        return null; // Autenticación fallida
    }
}
