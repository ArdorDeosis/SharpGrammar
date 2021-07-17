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
            var pointer = context.GetRandomInt(outcomes.Sum(outcome => outcome.Weight));
            var counter = 0;
            foreach (var outcome in outcomes)
            {
                counter += outcome.Weight;
                if (counter > pointer)
                    return outcome.Processable.Process(context);
            }

            throw new GrammarProcessingException(nameof(OneOfProcessable<T>),
                "Pointer has not been reached. Are there some weights <= 0?");
        }
    }
}