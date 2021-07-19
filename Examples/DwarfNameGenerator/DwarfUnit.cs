using SharpGrammar;
using SharpGrammar.Memory;

namespace DwarfNameGenerator
{
    public static class DwarfUnit
    {
        private const string Specialization = nameof(Specialization);
        
        public static readonly Processable<string> Unit = Take.OneOf();
        
        public static readonly Processable<string> SetSpecialization = 
            Memory.Set(Specialization, Take.OneOf<UnitSpecialization>());
    }

    public enum UnitSpecialization
    {
        Ranged,
        Melee,
        Siege,
        Scout
    }
}