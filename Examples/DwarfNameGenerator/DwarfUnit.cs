using SharpGrammar;
using SharpGrammar.Counting;
using SharpGrammar.Memory;

namespace DwarfNameGenerator
{
    public static class DwarfUnit
    {
        private const string Specialization = nameof(Specialization);
        private const string UnitCount = nameof(UnitCount);
        private const string UnitSize = nameof(UnitSize);
        
        public static Processable<string> Unit => Initialize + UnitDescription;
        
        private static readonly Processable Initialize = 
            Memory.Set(Specialization, Take.OneOf<UnitSpecialization>()) +
            Number.Set(UnitCount, 0, false) +
            Number.Increment(UnitCount) +
            Number.Set(UnitSize, 12);

        private static readonly Processable<string> UnitDescription =
            Number.Get(UnitCount).ToOrdinal() + " Unit 1st Battalion\n" +
            Number.Get(UnitSize).Convert(n => n.ToString()) + " Dwarves, " +
            Memory.Get<UnitSpecialization>(Specialization).Convert(x => x.ToString()) + "\n" +
            ("   " + DwarfNameGrammar.Name + " " + DwarfNameGrammar.Name + "son\n").Repeat(Number.Get(UnitSize));
    }

    public enum UnitSpecialization
    {
        Ranged,
        Melee,
        Siege,
        Scout
    }
}