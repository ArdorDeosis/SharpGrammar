using System;
using Newtonsoft.Json;

namespace LogicSolver
{
    public class DataClass
    {
        [Generator(typeof(TestName))]
        [JsonProperty]
        public string Public { get; set; }
        
        [Generator(typeof(TestName))]
        [JsonProperty]
        protected string Protected { get; set; }
        
        [Generator(typeof(TestName))]
        [JsonProperty]
        private string Private { get; set; }
        
        [Generator(typeof(TestName))]
        [JsonProperty]
        public string PublicPrivateSet { get; private set; }
        
        [Generator(typeof(TestName))]
        [JsonProperty]
        protected string ProtectedPrivateSet { get; private set; }
        
        [Generator(typeof(TestName))]
        [JsonProperty]
        public string PublicDefault { get; set; } = "Default";
        
        [Generator(typeof(TestName))]
        [JsonProperty]
        protected string ProtectedDefault { get; set; } = "Default";
        
        [Generator(typeof(TestName))]
        [JsonProperty]
        private string PrivateDefault { get; set; } = "Default";

        public override string ToString() => JsonConvert.SerializeObject(this);
    }

    [AttributeUsage(System.AttributeTargets.Property)]
    public class GeneratorAttribute : Attribute
    {
        public IGenerator<string> Generator { get; }

        public GeneratorAttribute(Type generatorType)
        {
            Generator = generatorType.GetConstructor(Array.Empty<Type>())
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