using Microsoft.AspNetCore.Identity;
using RatingBooks.Application.Configuration;
using RatingBooks.Persistance.Configuration;
using RatingBooks.Domain.Entidades;

var builder = WebApplication.CreateBuilder(args);

var service = builder.Services;

// Add services to the container.

//builder.Services.AddDbContext<UsuarioDbContext>(opts => { opts.UseSqlServer(_conn); });

//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

service.RegisterApplication(); //Injeção de Dependência está sendo realizada aqui

var _conn = builder.Configuration.GetConnectionString("BookUsersConnection");

service.RegisterPersistance(_conn);

service.AddIdentity<Usuario, IdentityRole>().AddEntityFrameworkStores<UsuarioDbContext>().AddDefaultTokenProviders();

service.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
service.AddEndpointsApiExplorer();
service.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
