using System;

namespace LogicSolver
{
    public class DataClass
    {
        [Generator(typeof(TestName))]
        public string Name { get; set; }
    }

    [AttributeUsage(System.AttributeTargets.Property)]
    public class GeneratorAttribute : Attribute
    {
        private IGenerator<string> generator;

        public GeneratorAttribute(Type generatorType)
        {
            generator = generatorType.GetConstructor(Array.Empty<Type>())
                ?.Invoke(Array.Empty<object>()) as IGenerator<string>
                        ?? throw new Exception("Unable to instantiate Generator");
        }
    }

    public interface IGenerator<out T>
    {
        T Generate();
    }

    public abstract class ValueGenerator<T> : IGenerator<T>
    {
        protected abstract T Value { get; }

        public T Generate() => Value;
    }

    public class TestName : ValueGenerator<string>
    {
        protected override string Value => "Ardor";
    }
}