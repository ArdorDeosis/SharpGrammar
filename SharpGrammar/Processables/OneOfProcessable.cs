using System.Linq;

namespace SharpGrammar
{
    internal class OneOfProcessable : Processable
    {
        private readonly WeightedOutcome[] outcomes;
        
        internal OneOfProcessable(params WeightedOutcome[] outcomes) => this.outcomes = outcomes;

        /// <inheritdoc />
        public override string Process(IContext context)
        {
            var pointer = context.GetRandomInt(outcomes.Sum(outcome => outcome.weight));
            var counter = 0;
            foreach (var outcome in outcomes)
            {
                counter += outcome.weight;
                if (counter > pointer)
                    return outcome.processable.Process(context);
            }

            throw new GrammarProcessingException(nameof(OneOfProcessable),
                "Pointer has not been reached. Are there some weights <= 0?");
        }
    }
}