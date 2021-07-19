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
        
        private static Processable Initialize => 
            Memory.Set(Specialization, Take.OneOf<UnitType>()) +
            Number.Set(UnitCount, 0, false) +
            Number.Increment(UnitCount) +
            Number.Set(UnitSize, Take.OneOf(12.WithWeight(5), 11.WithWeight(2), 10));

        private static Processable<string> UnitDescription =>
            Number.Get(UnitCount).ToOrdinal() + " Unit 1st Battalion\n" +
            Number.Get(UnitSize).Convert(n => n.ToString()) + " Dwarves, " +
            Memory.Get<UnitType>(Specialization).Switch<UnitType, string>()
                .Case(UnitType.Ranged, "mad archers")
                .Case(UnitType.Melee, "fierce fighters")
                .Case(UnitType.Siege, "some trebuchets")
                .Case(UnitType.Scout, "sneaky scouts")+
            "\n" +
            (DwarfDescription + "\n").Repeat(Number.Get(UnitSize));

        private static Processable<string> DwarfDescription =>
            "   " + DwarfNameGrammar.Name + " " + DwarfNameGrammar.Name + "son; ";
    }

    public enum UnitType
    {
        Ranged,
        Melee,
        Siege,
        Scout
    }

    public enum ArmourType
    {
        Light,
        Heavy,
        Mixed
    }
}