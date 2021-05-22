using SharpGrammar;
using SharpGrammar.API;

namespace AztecPantheon
{
    public static class AztecPantheonGrammar
    {
        public static Processable Name = "NAME";

        public static Processable Domain = Rule.Iterate(IteratorRandomization.EveryCycle,
            "fertility", "war", "art", "food", "farming", "hunting", "family", "health");
        
        
    }

    internal enum Gender
    {
        Male,
        Female
    }
}