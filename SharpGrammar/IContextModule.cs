namespace SharpGrammar
{
    public interface IContextModule
    {
        IContext Context { get; }
    }

    public class CountingModule : IContextModule
    {
        public IContext Context { get; private init; }

        public CountingModule(IContext context)
        {
            Context = context;
        }
    }

    public class MemoryModule<T> : IContextModule
    {
        public IContext Context { get; private init; }

        public MemoryModule(IContext context)
        {
            Context = context;
        }
    }
}