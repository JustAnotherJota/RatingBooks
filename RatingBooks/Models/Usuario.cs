using Microsoft.AspNetCore.Identity;

namespace RatingBooks.Models
{
    public class Usuario : IdentityUser
    {
        public DateTime DataNascimento { get; set; }
        public Usuario() : base ()
        {
            
        }
    }
}
