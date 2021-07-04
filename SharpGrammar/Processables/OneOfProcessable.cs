using System.Linq;

namespace SharpGrammar
{
    internal class OneOfProcessable<T> : Processable<T>
    {
        private readonly WeightedOutcome<T>[] outcomes;
        
        internal OneOfProcessable(params WeightedOutcome<T>[] outcomes) => this.outcomes = outcomes;

        /// <inheritdoc />
        public override T Process(IContext<T> context)
        {
            var pointer = context.GetRandomNumber(outcomes.Sum(outcome => outcome.weight));
            var counter = 0;
            foreach (var outcome in outcomes)
            {
                counter += outcome.weight;
                if (counter > pointer)
                    return outcome.processable.Process(context);
            }

            throw new GrammarProcessingException(nameof(OneOfProcessable<T>),
                "Pointer has not been reached. Are there some weights <= 0?");
        }
    }
}