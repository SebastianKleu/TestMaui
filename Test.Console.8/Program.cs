using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Test.Console._8.Services;
using Test.Data;
using Test.Data.Extensions;

namespace Test.Console._8
{
    internal class Program
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IDbTester, DbTester>();
            serviceCollection.AddEntityFramework();
            ServiceProvider = serviceCollection.BuildServiceProvider();
            //Create DB
            var _dbContextFactory = ServiceProvider.GetRequiredService<IDbContextFactory<TestDataContext>>();
            DbInitialiser.Initialise(_dbContextFactory.CreateDbContext());
            //Start test
            var dbTesterService = ServiceProvider.GetRequiredService<IDbTester>();
            dbTesterService.TestDb();
            // Prevent the app from exiting immediately
            System.Console.ReadLine();
        }
    }
}
