
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text.Json;
using RecordShop.Services;
using RecordShop.Models;

namespace RecordShop
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
        
        var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<AlbumsService>();
            builder.Services.AddScoped<AlbumsModel>();


            //builder.Services.AddDbContext<RecordShopDbContext>(options => options.UseSqlServer(Connection.connectionString));
            builder.Services.AddDbContext<RecordShopDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            //

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
