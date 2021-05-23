using Newtonsoft.Json;

namespace LogicSolver
{
    public class Dwarf
    {
        [Generator(typeof(NameGenerator))]
        public string Name { get; private set; }
        
        [Generator(typeof(AgeGenerator))]
        public int Age { get; private set; }
        
        public override string ToString() => JsonConvert.SerializeObject(this);
    }

    public class House
    {
        
    }
}