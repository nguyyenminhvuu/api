using CartMay10.Entity;
using CartMay10.Repository;
using CartMay10.Service;
using Microsoft.EntityFrameworkCore;

namespace CartMay10
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
            builder.Services.AddDbContext<TestOneContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("MyDB")));
            builder.Services.AddScoped<IProduct, ProductRepository>();
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<Icart, ICartRepository>();
            builder.Services.AddScoped<CartService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}