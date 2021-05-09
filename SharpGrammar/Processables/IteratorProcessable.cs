namespace SharpGrammar
{
    /// <summary>
    /// <list type="table">
    /// <item>
    /// <term><see cref="None"/></term>
    /// <description>No randomization; outcomes are processed in the order they are provided in.</description>
    /// </item>
    /// <item>
    /// <term><see cref="Once"/></term>
    /// <description>The order of outcomes is randomized once when the <see cref="Processable"/> is processed the first time.</description>
    /// </item>
    /// <item>
    /// <term><see cref="EveryCycle"/></term>
    /// <description>The order of outcomes is randomized once when the <see cref="Processable"/> is processed the first time and every time all outcomes have been processed once.</description>
    /// </item>
    /// </list>
    /// </summary>
    public enum IteratorRandomization
    {
        None,
        Once,
        EveryCycle
    }
    
    internal class IteratorProcessable : Processable
    {
        private readonly Processable[] outcomes;
        private readonly IteratorRandomization randomization;
        private bool isInitialized = false;
        private int pointer = 0;

        internal IteratorProcessable(Processable[] outcomes,
            IteratorRandomization randomization = IteratorRandomization.None)
        {
            this.outcomes = outcomes;
            this.randomization = randomization;
        }

        /// <inheritdoc />
        public override string Process(IContext context)
        {
            if (!isInitialized)
                Initialize(context);
            if (pointer >= outcomes.Length)
            {
                pointer = 0;
                if (randomization == IteratorRandomization.EveryCycle)
                    outcomes.Shuffle(context);
            }

            return outcomes[pointer++].Process(context);
        }

        private void Initialize(IContext context)
        {
            if (randomization == IteratorRandomization.Once)
                outcomes.Shuffle(context);
            isInitialized = true;
        }
    }
}