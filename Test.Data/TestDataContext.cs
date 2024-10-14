using Microsoft.EntityFrameworkCore;
using Test.Data.Models;

namespace Test.Data
{
    public class TestDataContext : DbContext
    {
        #region ctor

        public TestDataContext(DbContextOptions<TestDataContext> options) : base(options)
        {
        }

        #endregion

        #region Models

        public DbSet<TestData> TestData { get; set; } = null!;

        #endregion
    }
}
