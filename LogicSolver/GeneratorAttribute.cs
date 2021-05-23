using System;

namespace LogicSolver
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class GeneratorAttribute : Attribute
    {
        public IGenerator Generator { get; }

        public GeneratorAttribute(Type generatorType)
        {
            Generator = generatorType.GetConstructor(Array.Empty<Type>())
                            ?.Invoke(Array.Empty<object>()) as IGenerator
                        ?? throw new Exception("Unable to instantiate Generator");
        }
    }
}