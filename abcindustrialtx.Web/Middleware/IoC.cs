using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using abcindustrialtx.Business.Implements;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.DAO.Implements;

namespace abcindustrialtx.Web.Middleware
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddTransient<IProductosDAO, ProductosDAOImp>();
            services.AddTransient<IProductosBsn, ProductosBsn>();

            return services;
        }
    }
}
