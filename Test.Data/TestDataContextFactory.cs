using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace Test.Data
{
    public class TestDataContextFactory : IDesignTimeDbContextFactory<TestDataContext>
    {
        public TestDataContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TestDataContext>();
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "TestData.db");

            builder.UseSqlite($"Data Source={dbPath}");

            return new TestDataContext(builder.Options);
        }
    }
}
