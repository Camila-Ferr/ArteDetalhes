using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ArteDetalhes.Data;
using ArteDetalhes.Repository;
using ArteDetalhes.Repository.Interfaces;

namespace ArteDetalhes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configurando o DbContext com SQLite
            builder.Services.AddDbContext<SystemDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DataBase")));
            

            // Registrando o repositório de produtos
            builder.Services.AddScoped<InterfaceProdutoRepository, ProdutoRepository>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}