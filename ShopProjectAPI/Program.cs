using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using ShopProjectAPI.DB;
using ShopProjectAPI.Interfaces;
using ShopProjectAPI.Repository;

namespace ShopProjectAPPAPI
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

            builder.Services.AddDbContext<ShopprojectContext>(x =>
            {
                x.UseMySql(builder.Configuration.GetValue<string>("ConnectionString"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.2.0-mysql"));
            });
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseCors(policy =>
            //    policy.WithOrigins("http://localhost:7044", "https://localhost:7044")
            //    .AllowAnyMethod()
            //    .WithHeaders(HeaderNames.ContentType)
            //);

            app.UseCors(x =>
            {
                x.WithHeaders("Authorization");
                x.AllowAnyMethod();
                x.WithOrigins("https://localhost:44357");
            });

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}