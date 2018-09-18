namespace Wil.Reactive.Interfaces
{
    public struct Stale<T>
    {
        public Stale(T value)
        {
            Value = value;
            IsFresh = true;
        }

        public T Value { get; }
        public bool IsFresh { get; }
        public static Stale<T> Empty { get; } = new Stale<T>();

        public override string ToString() => $"Stale<{typeof(T).Name}>{(IsFresh ? $": {Value}" : "")}";
    }
}
