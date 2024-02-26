using System.ComponentModel.DataAnnotations;

namespace RatingBooks.Data.Dtos.UsuarioDtos
{
    public class CreateUsuarioDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }

        [Required]
        public DateTime? DataNascimento { get; set; }

        public CreateUsuarioDto()
        {

        }
    }
}
