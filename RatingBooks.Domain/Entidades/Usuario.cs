using Microsoft.AspNetCore.Identity;

namespace RatingBooks.Domain.Entidades
{
    public class Usuario : IdentityUser
    {
        public DateTime DataNascimento { get; set; }
        public Usuario() : base()
        {

        }
    }
}
