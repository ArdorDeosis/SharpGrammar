using System;

namespace SharpGrammar.NumberModule
{
    internal class GetNumberProcessable : Processable
    {
        private readonly string name;
        
        internal GetNumberProcessable(string name)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <inheritdoc />
        public override string Process(IContext context) => context.Get<INumberModule>().GetNumber(name).ToString();
    }
}