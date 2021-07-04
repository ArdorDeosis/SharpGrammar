using System;

namespace SharpGrammar
{
    internal class GetValueProcessable : Processable
    {
        private readonly string name;
        internal GetValueProcessable(string name)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <inheritdoc />
        public override string Process(IContext context)
        {
            if (!context.Get<IMemoryModule>().TryGetValue(name, out Processable? processable))
                throw new GrammarProcessingException(nameof(GetValueProcessable),
                    $"Value '{name}' does not exist in the current context.");
            return processable!.Process(context);
        }
    }
}