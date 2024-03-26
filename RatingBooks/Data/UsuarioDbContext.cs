using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RatingBooks.Models;

namespace RatingBooks.Data
{
    public class UsuarioDbContext : IdentityDbContext<Usuario>
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> opts) : base(opts)
        {
                
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
    }
}