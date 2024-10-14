using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Data.Models;

namespace Test.Console._8.Services;

public class DbTester : IDbTester
{
	private IDbContextFactory<TestDataContext> _dbContextFactory;
	private readonly CancellationTokenSource _eventSendCancellationTokenSource;

	public DbTester(IDbContextFactory<TestDataContext> dbContextFactory)
	{
		_dbContextFactory = dbContextFactory;
		_eventSendCancellationTokenSource = new CancellationTokenSource();
	}

    public void TestDb()
    {
        _ = Task.Factory.StartNew(
            async () => await TesterLoop(),
            _eventSendCancellationTokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Current);
    }


    private async Task TesterLoop()
    {
        while (true)
            await GetTestDataMessages(new CancellationToken());
    }

    private async Task<List<TestData>> GetTestDataMessages(CancellationToken token = default)
    {
        try
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync(token);

            List<TestData> returnResult = await dbContext.TestData.AsNoTracking()
                .ToListAsync(token);

            await dbContext.DisposeAsync().ConfigureAwait(false);

            return returnResult;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Something went wrong: {exception}", ex.Message);
            return null;
        }
    }
}