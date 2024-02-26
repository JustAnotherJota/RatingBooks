using System.ComponentModel.DataAnnotations;

namespace RatingBooks.Data.Dtos.UsuarioDtos
{
    public class LoginUsuarioDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
