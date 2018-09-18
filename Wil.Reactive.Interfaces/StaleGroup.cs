namespace Wil.Reactive.Interfaces
{
    public struct StaleGroup<TKey, TValue>
    {
        public StaleGroup(TKey key)
        {
            Key = key;
            Value = default(TValue);
            IsFresh = false;
        }

        public StaleGroup(TKey key, TValue value)
        {
            Key = key;
            Value = value;
            IsFresh = true;
        }

        public TKey Key { get; }
        public TValue Value { get; }
        public bool IsFresh { get; }

        public override string ToString()
            => $"StaleGroup<{typeof(TKey).Name}, {typeof(TValue).Name}>: {Key}{(IsFresh ? $" - {Value}" : "")}";
    }
}
