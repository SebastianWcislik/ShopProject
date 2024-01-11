using Microsoft.EntityFrameworkCore;
using ShopProjectInfrastructure.DB;

namespace ShopProjectOrderActionsAPI
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
            builder.Services.AddDbContext<ShopprojectContext>(x =>
            {
                x.UseMySql(builder.Configuration.GetValue<string>("ConnectionString"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.2.0-mysql"));
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.WithOrigins("https://localhost:44357");
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
