using Microsoft.EntityFrameworkCore;
using ShopProjectInfrastructure.DB;
using ShopProjectInfrastructure.Interfaces;
using ShopProjectInfrastructure.Mappers;
using ShopProjectInfrastructure.Repository;

namespace ShopProjectOrderAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IGamesRepository, GamesRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<GameMapper>();
            builder.Services.AddScoped<OrderMapper>();
            builder.Services.AddDbContext<ShopprojectContext>(x =>
            {
                x.UseMySql(builder.Configuration.GetValue<string>("ConnectionString"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.2.0-mysql"));
            });
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
