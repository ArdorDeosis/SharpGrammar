using SharpGrammar;

namespace DwarfNameGenerator
{
    public class StringHandler : ITypeHandler<string>
    {
        public string NullValue => "";

        public string Concatenate(string lhs, string rhs) => lhs + rhs;
    }
    
    public class UnitSpecializationHandler : ITypeHandler<UnitType>
    {
        public UnitType NullValue => UnitType.Melee;
        public UnitType Concatenate(UnitType lhs, UnitType rhs) => lhs;
    }
}