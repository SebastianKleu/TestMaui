using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Test.Android._8.Services;
using Test.Data;
using Test.Data.Extensions;

namespace Test.Android._8
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

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
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
        }
    }
}