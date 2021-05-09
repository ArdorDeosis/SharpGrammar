using System.Collections.Generic;
using System.Linq;

namespace SharpGrammar
{
    internal class ProcessableList : Processable
    {
        private readonly List<Processable> items;

        internal ProcessableList(params Processable[] processables) => items = processables.ToList();

        /// <inheritdoc />
        public override string Process(IContext context) =>
            string.Join("", items.Select(rule => rule.Process(context)));

        /// <summary>
        /// Concatenates two <see cref="Processable"/>s.
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
}