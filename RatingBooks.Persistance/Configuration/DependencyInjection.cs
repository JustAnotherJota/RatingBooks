using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace RatingBooks.Persistance.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterPersistance(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<UsuarioDbContext>(opts => { opts.UseSqlServer(connectionString); });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
 
            return services;
        }

        //public static IServiceCollection RegisterIdentityRole(this IServiceCollection services)
        //=> services.AddIdentity<Usuario, IdentityRole>().AddEntityFrameworkStores<UsuarioDbContext>().AddDefaultTokenProviders(); 
    }
}
