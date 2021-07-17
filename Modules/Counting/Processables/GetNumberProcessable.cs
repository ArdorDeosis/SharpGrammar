using System;

namespace SharpGrammar.Counting
{
    internal record GetNumberProcessable : Processable<int>
    {
        private readonly string name;
        
        internal GetNumberProcessable(string name)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <inheritdoc />
        public override int Process(IContext context)
        {
            var numberModule = context.Get<INumberModule>();
            return numberModule.GetNumber(name);
        }
    }
}