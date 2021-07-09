
using SharpGrammar;
using SharpGrammar.Iteration;

namespace AztecPantheon
{
    public static class AztecPantheonGrammar
    {
        public static Processable<string> Name = "NAME";

        public static Processable<string> Domain = Iterate.Over<string>(IteratorRandomization.EveryCycle,
            "fertility", "war", "art", "food", "farming", "hunting", "family", "health");
        
        
    }

    internal enum Gender
    {
        Male,
        Female
    }
}