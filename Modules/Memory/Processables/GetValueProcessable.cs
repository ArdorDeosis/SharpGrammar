using System;

namespace SharpGrammar.Memory
{
    internal record GetValueProcessable<T> : Processable<T>
    {
        private readonly string name;
        internal GetValueProcessable(string name)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <inheritdoc />
        public override T Process(IContext context)
        {
            if (!context.Get<IMemoryModule>().TryGetValue(name, out Processable<T>? processable))
                throw new GrammarProcessingException(nameof(GetValueProcessable<T>),
                    $"Value '{name}' does not exist in the current context.");
            return processable!.Process(context);
        }
    }
}