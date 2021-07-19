using SharpGrammar;

namespace DwarfNameGenerator
{
    public class StringHandler : ITypeHandler<string>
    {
        public string NullValue => "";

        public string Concatenate(string lhs, string rhs) => lhs + rhs;
    }
    
    public class UnitSpecializationHandler : ITypeHandler<UnitSpecialization>
    {
        public UnitSpecialization NullValue => UnitSpecialization.Melee;
        public UnitSpecialization Concatenate(UnitSpecialization lhs, UnitSpecialization rhs) => lhs;
    }
}