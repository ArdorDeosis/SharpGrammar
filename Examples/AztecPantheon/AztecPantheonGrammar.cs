
using SharpGrammar;
using SharpGrammar.Iteration;

namespace AztecPantheon
{
    public static class AztecPantheonGrammar
    {
        public static Processable Name = "NAME";

        public static Processable Domain = Iterate.Over(IteratorRandomization.EveryCycle,
            "fertility", "war", "art", "food", "farming", "hunting", "family", "health");
        
        
    }

    internal enum Gender
    {
        Male,
        Female
    }
}