namespace SharpGrammar.Counting
{
    internal record ToOrdinalProcessable : Processable<string>
    {
        private readonly Processable<int> number;

        public ToOrdinalProcessable(Processable<int> number)
        {
            this.number = number;
        }

        public override string Process(IContext context)
        {
            var n = number.Process(context);
            return (n % 10) switch
            {
                1 => n + "st",
                2 => n + "nd",
                3 => n + "rd",
                _ => n + "th"
            };
        }
    }
}