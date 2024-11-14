using System.ComponentModel.DataAnnotations;

namespace JoyasNala.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; } // "Administrador" o "Cliente"

        [Required]
        public string PasswordHash { get; set; } // Almacenaremos la contraseña como hash
    }
}
