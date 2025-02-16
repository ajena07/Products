using Microsoft.EntityFrameworkCore;
using ProductsWebAPI.DataBase;
using ProductsWebAPI.DataBase.Repository;
using System;
using System.Runtime.CompilerServices;

namespace ProductsWebAPI
{
    public static class ServiceRegistration
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c => c.EnableAnnotations());
            // Add services to the container.
            services.AddScoped<IRepository, Repository>();
            services.AddDbContext<ProductContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
