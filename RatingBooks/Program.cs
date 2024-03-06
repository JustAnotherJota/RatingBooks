using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RatingBooks.Data;
using RatingBooks.Models;
using RatingBooks.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var _conn = builder.Configuration.GetConnectionString("BookUsersConnection");

builder.Services.AddDbContext<UsuarioDbContext>(opts => { opts.UseSqlServer(_conn); });

builder.Services.AddIdentity<Usuario, IdentityRole>().AddEntityFrameworkStores<UsuarioDbContext>().AddDefaultTokenProviders();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<UsuarioService>(); //Instancia da classe
builder.Services.AddScoped<LivroService>();//Instancia da classe

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
