using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Test.Data.Extensions
{
    public static class DependentServiceInjector
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var migrationsAssembly = typeof(TestDataContext).GetTypeInfo().Assembly.GetName().Name;


            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "TestData.db");

            var connectionString = "Data Source=" + dbPath;

            services.AddDbContextFactory<TestDataContext>(builder =>
                builder.UseSqlite(connectionString, options =>
                    options.MigrationsAssembly(migrationsAssembly)));

            return services;
        }
    }
}
