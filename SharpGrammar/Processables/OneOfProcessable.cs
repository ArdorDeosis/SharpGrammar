using System.Linq;

namespace SharpGrammar
{
    internal record OneOfProcessable<T> : Processable<T>
    {
        private readonly WeightedOutcome<T>[] outcomes;
        
        internal OneOfProcessable(params WeightedOutcome<T>[] outcomes) => this.outcomes = outcomes;

        /// <inheritdoc />
        public override T Process(IContext context)
        {
            var randomWeightPointer = context.GetRandomInt(outcomes.Sum(outcome => outcome.Weight));
            var weightCounter = 0;
            foreach (var outcome in outcomes)
            {
                weightCounter += outcome.Weight;
                if (weightCounter > randomWeightPointer)
                    return outcome.Processable.Process(context);
            }

            throw new GrammarProcessingException(nameof(OneOfProcessable<T>), 
                "Reaching this code is mathematically impossible, yet an Exception is thrown, to satisfy the compiler");
        }
    }
}