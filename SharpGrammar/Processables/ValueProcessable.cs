using System;

namespace SharpGrammar
{
    internal record ValueProcessable<T> : Processable<T>
    {
        private readonly T value;
        
        internal ValueProcessable(T value)
        {
            this.value = value ?? throw new ArgumentNullException(nameof(value));;
        }

        /// <inheritdoc />
        public override T Process(IContext context) => value;

        /// <summary>
        /// Implicitly converts a <see cref="string"/> to a <see cref="ValueProcessable{T}"/>.
        /// </summary>
        public static implicit operator ValueProcessable<T>(T value) => new(value);
    }
}