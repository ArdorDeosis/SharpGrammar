using SharpGrammar;

namespace DwarfNameGenerator
{
    public static class SiegeWeapon
    {
        
    }

    public static class Material
    {
        public static readonly Processable<string> Metal = Take.OneOf<string>(
            (5, "Iron"), (5, "Steel"),
            (3, "Copper"), (3, "Bronze"), (3, "Brass"),
            "Orichalcum", "Mithril", "Darkiron");

        public static readonly Processable<string> Wood = "Wood";
    }
}