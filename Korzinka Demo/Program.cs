using Korzinka_Demo.DAL.DbContexts;
using Korzinka_Demo.DAL.IRepositories;
using Korzinka_Demo.DAL.Repositories;
using Korzinka_Demo.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Korzinka_Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<KorzinkaDbContext>(options
                => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IKorzinkaRepository<Product>, KorzinkaRepository<Product>>();

            builder.Services.AddSwaggerGen(options => 
                options.SwaggerDoc("v1",
                new OpenApiInfo()
                {
                    Version = "v1",
                    Title = "Korzinka",
                    Contact = new OpenApiContact()
                    {
                        Email = "zzrxmnv1002@gmail.com",
                        Name = "Aziz"
                    }
                }));

          

            builder.Services.AddControllers();

            var app = builder.Build();

            IWebHostEnvironment env = app.Environment;

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                

                //app.UseSwaggerUI(options =>
                //{
                //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Korzinka v1");
                //});
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();

           
           
            app.MapControllers();

            app.Run();
        }
    }
}
