using System;
using DwarfNameGenerator;
using SharpGrammar;
using SharpGrammar.API;

namespace LogicSolver
{
    public interface IGenerator
    {
    }
    public interface IGenerator<out T> : IGenerator
    {
        T Generate();
    }

    public class NameGenerator : IGenerator<string>
    {
        private Processable grammar = DwarfNameGrammar.DwarfName;
        public string Generate() => grammar.Process();
    }

    public class AgeGenerator : IGenerator<int>
    {
        private Random rnd = new();

        public int Generate() => rnd.Next(40, 350);
    }
}