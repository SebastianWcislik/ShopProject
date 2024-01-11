using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ShopProjectInfrastructure.DB;
using ShopProjectInfrastructure.Interfaces;
using ShopProjectInfrastructure.Repository;

namespace ShopProjectUserAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddDbContext<ShopprojectContext>(x =>
            {
                x.UseMySql(builder.Configuration.GetValue<string>("ConnectionString"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.2.0-mysql"));
            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Token", new OpenApiSecurityScheme()
                {
                    Description = "JWT Token",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Token"
                            }
                        },
                    new List<string>()
                    }
                });
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
