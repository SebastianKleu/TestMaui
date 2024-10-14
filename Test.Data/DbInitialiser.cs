using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Test.Data;

public static class DbInitialiser
{
    public static async Task Initialise(TestDataContext context)
    {
        await context.Database.MigrateAsync().ConfigureAwait(false);
        await context.SaveChangesAsync();
    }
}