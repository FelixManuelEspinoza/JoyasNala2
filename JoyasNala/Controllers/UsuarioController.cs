using Microsoft.AspNetCore.Mvc;
using JoyasNala.Models;
using System.Threading.Tasks;

[Route("api/Usuario")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioService _usuarioService;

    public UsuarioController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("registrar")]
    public async Task<IActionResult> Registrar(string nombre, string email, string rol, string password)
    {
        await _usuarioService.CrearUsuarioAsync(nombre, email, rol, password);
        return Ok("Usuario registrado exitosamente");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var usuario = await _usuarioService.ValidarUsuarioAsync(email, password);
        if (usuario == null)
        {
            return Unauthorized("Email o contraseña incorrectos");
        }
        return Ok("Inicio de sesión exitoso");
    }
}
