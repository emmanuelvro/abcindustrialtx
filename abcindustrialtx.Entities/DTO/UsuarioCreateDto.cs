using System.ComponentModel.DataAnnotations;

namespace abcindustrialtx.Entities.DTO
{
    public class UsuarioCreateDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string CorreoElectronico { get; set; }
    }
}
