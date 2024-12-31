namespace BlazorService.Components.Service
{
    public class CounterState
    {
        private int _counterCount;
        public int CounterCount
        {
            get => _counterCount;
            set
            {
                if (_counterCount != value)
                {
                    _counterCount = value;
                    NotifyStateChanged();
                }
            }
        }

        public event Action OnChange;

        public Task InitializeAsync(Func<Task<int>> fetchCounter)
        {
            return Task.Run(async () =>
            {
                _counterCount = await fetchCounter.Invoke();
                NotifyStateChanged();
            });
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
