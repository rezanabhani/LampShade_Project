using _0_Framework.Infrastructure;
using InventoryManagement.Application;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Application.Contract.ProductColor;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Domain.ProductColorAgg;
using InventoryManagement.Infrastructure.EfCore;
using InventoryManagement.Infrastructure.EfCore.Repository;
using InventoryManagement.InfrastructureConfiguration.Permissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.InfrastructureConfiguration
{
    public class InventoryManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<IInventoryApplication,InventoryApplication>();

            services.AddTransient<IProductColorRepository, ProductColorRepository>();
            services.AddTransient<IProductColorApplication, ProductColorApplication>();

            services.AddTransient<IPermissionsExposer, InventoryPermissionExposer>();

            services.AddDbContext<InventoryContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
