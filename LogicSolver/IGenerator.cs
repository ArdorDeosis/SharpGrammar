using DwarfNameGenerator;
using SharpGrammar;
using SharpGrammar.API;

namespace LogicSolver
{
    public interface IGenerator<out T>
    {
        T Generate();
    }

    public class TestName : IGenerator<string>
    {
        private Processable grammar = DwarfNameGrammar.DwarfName;
        public string Generate() => grammar.Process();
    }

    public class Constraint
    {
        
    }
}