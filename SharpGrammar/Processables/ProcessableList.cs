using System.Collections.Generic;
using System.Linq;

namespace SharpGrammar
{
    internal record ProcessableList : Processable
    {
        private readonly List<Processable> items;

        internal ProcessableList(params Processable[] processables) => items = processables.ToList();

        /// <inheritdoc />
        public override void Process(IContext context) =>
            items.ForEach(processable => processable.Process(context));

        /// <summary>
        /// Concatenates two <see cref="Processable{T}"/>s.
        /// </summary>
        internal static ProcessableList Combine(Processable first, Processable second)
        {
            List<Processable> combinedItems = new();
            
            if(first is ProcessableList firstAsList)
                combinedItems.AddRange(firstAsList.items);
            else
                combinedItems.Add(first);
            
            if(second is ProcessableList secondAsList)
                combinedItems.AddRange(secondAsList.items);
            else
                combinedItems.Add(second);
            
            return new ProcessableList(combinedItems.ToArray());
        }
    }
    
    internal record ProcessableList<T> : Processable<T>
    {
        private readonly List<Processable<T>> items;

        internal ProcessableList(params Processable<T>[] processables) => items = processables.ToList();

        /// <inheritdoc />
        public override T Process(IContext context) =>
            items
                .Select(rule => rule.Process(context))
                .Aggregate(context.Concatenate);

        /// <summary>
        /// Concatenates two <see cref="Processable{T}"/>s.
        /// </summary>
        internal static ProcessableList<T> Combine(Processable<T> first, Processable<T> second)
        {
            List<Processable<T>> combinedItems = new();
            
            if(first is ProcessableList<T> firstAsList)
                combinedItems.AddRange(firstAsList.items);
            else
                combinedItems.Add(first);
            
            if(second is ProcessableList<T> secondAsList)
                combinedItems.AddRange(secondAsList.items);
            else
                combinedItems.Add(second);
            
            return new ProcessableList<T>(combinedItems.ToArray());
        }
    }
}