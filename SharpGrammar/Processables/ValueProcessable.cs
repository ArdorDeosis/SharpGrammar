using System;

namespace SharpGrammar
{
    internal class ValueProcessable : Processable
    {
        private readonly string value;
        internal ValueProcessable(string value)
        {
            this.value = value ?? throw new ArgumentNullException(nameof(value));;
        }

        /// <inheritdoc />
        public override string Process(IContext context) => value;

        /// <summary>
        /// Implicitly converts a <see cref="string"/> to a <see cref="ValueProcessable"/>.
        /// </summary>
        public static implicit operator ValueProcessable(string @string) => new(@string);
    }
}