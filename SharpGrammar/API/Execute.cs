using System;

namespace SharpGrammar
{
    /// <summary>
    /// Provides creation methods for <see cref="Processable{T}"/>s executing logic while being processed. 
    /// </summary>
    public static class Execute
    {
        /// <summary>
        /// Executes the provided <see cref="System.Action"/> when this <see cref="Processable{T}"/> is processed.
        /// Produces no value.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        public static Processable Action(Action<IContext> action) => new ActionProcessable(action);
    }
}