using Microsoft.Extensions.DependencyInjection;
using RatingBooks.Application.Services;
using RatingBooks.Domain.Entidades;
using RatingBooks.Persistance.Repositories;

namespace RatingBooks.Application.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddScoped<UsuarioService>();
            services.AddScoped<LivroService>();
            services.AddScoped<StatusLivro>();
            services.AddScoped<AgendamentoService>();
            services.AddScoped<LivroRepository>();
            services.AddScoped<AgendamentoRepository>();

            return services;
        }
    }
}
