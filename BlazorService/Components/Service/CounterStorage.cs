public class CounterStorage
{
    private static int _persistentCounter;

    public Task<int> GetCounterAsync()
    {
        return Task.FromResult(_persistentCounter);
    }

    public Task SaveCounterAsync(int counter)
    {
        _persistentCounter = counter;
        return Task.CompletedTask;
    }
}
