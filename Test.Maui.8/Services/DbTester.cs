using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Data.Models;

namespace Test.Maui._8.Services;

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
			async () => await TesterLoop().ConfigureAwait(false),
			_eventSendCancellationTokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Current);
	}


	private async Task TesterLoop()
    {
        while (true)
        {
            var testDataMessages = await GetTestDataMessages(new CancellationToken());
        }
    }

    private async Task<List<TestData>> GetTestDataMessages(CancellationToken cancellationToken)
    {
		await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

        List<TestData> returnResult = await dbContext.TestData.AsNoTracking()
            .ToListAsync(cancellationToken);

        await dbContext.DisposeAsync().ConfigureAwait(false);

        return returnResult;
	}
}