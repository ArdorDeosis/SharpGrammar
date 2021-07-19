using System;

namespace SharpGrammar.Counting
{
    internal record UnsetNumberProcessable : Processable
    {
        private readonly string name;
        internal UnsetNumberProcessable(string name)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <inheritdoc />
        public override void Process(IContext context) => context.Get<INumberModule>().UnsetNumber(name);
    }
}