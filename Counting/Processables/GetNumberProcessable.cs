using System;

namespace SharpGrammar.Counting
{
    internal class GetNumberProcessable<T> : Processable<T>
    {
        private readonly string name;
        
        internal GetNumberProcessable(string name)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <inheritdoc />
        public override T Process(IContext<T> context)
        {
            var module = context.Get<INumberModule<T>>();
            return module.Convert(module.GetNumber(name));
        }
    }
}