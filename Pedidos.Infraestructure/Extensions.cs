using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pedidos.Application;
using Pedidos.Domain.Repositories;
using Pedidos.Infraestructure.EF;
using Pedidos.Infraestructure.EF.Contexts;
using Pedidos.Infraestructure.EF.Repository;
using System;
using System.Reflection;

namespace Pedidos.Infraestructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddApplication();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            var connectionString = 
                configuration.GetConnectionString("PedidoDbConnectionString");

            //services.AddDbContext<ReadDbContext>(context => 
            //    context.UseSqlServer(connectionString));
            //services.AddDbContext<WriteDbContext>(context => 
            //    context.UseSqlServer(connectionString));
            services.AddDbContext<ReadDbContext>(context =>
               context.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),

                mySqlOptions =>
                {
                    mySqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);

                    mySqlOptions.MigrationsAssembly(typeof(ReadDbContext).Assembly.FullName);
                }));
            services.AddDbContext<WriteDbContext>(context =>
                context.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
                 mySqlOptions =>
                 {
                     mySqlOptions.EnableRetryOnFailure(
                         maxRetryCount: 10,
                         maxRetryDelay: TimeSpan.FromSeconds(30),
                         errorNumbersToAdd: null);

                     mySqlOptions.MigrationsAssembly(typeof(WriteDbContext).Assembly.FullName);
                 }));


            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }

    }
}
