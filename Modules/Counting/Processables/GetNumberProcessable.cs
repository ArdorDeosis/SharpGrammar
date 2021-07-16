using System;

namespace SharpGrammar.Counting
{
    internal record GetNumberProcessable<T> : Processable<T>
    {
        private readonly string name;
        
        internal GetNumberProcessable(string name)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <inheritdoc />
        public override T Process(IContext context)
        {
            var numberModule = context.Get<INumberModule<T>>();
            return numberModule.GetAndConvert(name);
        }
    }
}