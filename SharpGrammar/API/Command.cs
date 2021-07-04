using System;

namespace SharpGrammar.API
{
    public static class Command
    {
        /// <summary>
        /// Executes the provided <see cref="Action"/> when this <see cref="Processable"/> is processed.
        /// Produces no value.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        public static Processable Do(Action<IContext> action) => new ActionProcessable(action);

        /// <summary>
        /// Processes the provided <see cref="Processable"/> and transforms the produced result with
        /// <paramref name="transform"/>.
        /// </summary>
        /// <param name="value">The value to transform.</param>
        /// <param name="transform">The transformation to execute.</param>
        public static Processable Transform(Processable value, Func<string, IContext, string> transform) =>
            new TransformationProcessable(value, transform);
    }
}