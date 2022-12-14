using Business.Contract;
using Business.Implement;
using DataAccess.Core.Contract;
using DataAccess.Core.Implements;
using DataAccess.Models;
using DataAccess.Models.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjection
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRepository(IServiceCollection services)
        {
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IVentaRepository, VentaRepository>();

            return services;
        }

        public static IServiceCollection AddServices(IServiceCollection services)
        {
            services.AddScoped<IProductoServices, ProductoServices>();
            services.AddScoped<IClienteServices, ClienteServices>();
            services.AddScoped<IVentaServices, VentaServices>();


            services.AddAutoMapper(typeof(ProductoProfileMap));
            services.AddAutoMapper(typeof(ClienteProfileMap));
            services.AddAutoMapper(typeof(VentaProfileMap));

            return services;
        }

        public static IServiceCollection AddDbContext(IServiceCollection services, string DefaultConnection)
        {            
            services.AddDbContext<DbCrudContext>(options => options.UseSqlServer(DefaultConnection));   
            return services;
        }
    }
}
