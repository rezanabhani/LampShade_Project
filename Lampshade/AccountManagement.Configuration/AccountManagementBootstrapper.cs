﻿using _0_Framework.Infrastructure;
using _01_LampshadeReport.Contracts.Account;
using _01_LampshadeReport.Query;
using AccountManagement.Application;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.AccountAddress;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Configuration.Permissions;
using AccountManagement.Domain.AccountAddressAgg;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.Infrastructure.EFCore;
using AccountManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManagement.Configuration
{
    public class AccountManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IAccountApplication, AccountApplication>();
            services.AddTransient<IAccountRepository, AccountRepository>();

            services.AddTransient<IRoleApplication, RoleApplication>();
            services.AddTransient<IRoleRepository, RoleRepository>();

            services.AddTransient<IAccountAddressApplication, AccountAddressApplication>();
            services.AddTransient<IAccountAddressRepository, AccountAddressRepository>();

            services.AddTransient<IAccountReport, AccountReport>();

            services.AddTransient<IPermissionsExposer, AccountPermissionExposer>();

            services.AddDbContext<AccountContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
