using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LogicSolver;

namespace LSTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DataClass data = new ();
            
            Console.WriteLine($"fresh instance:   {data}");

            Dictionary<PropertyInfo, GeneratorAttribute> propertyBindings = new ();
            Dictionary<FieldInfo, GeneratorAttribute> fieldBindings = new ();

            // collect data
            var flags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
            foreach (var propertyInfo in data.GetType().GetProperties(flags))
            {
                if (Attribute.GetCustomAttribute(propertyInfo, typeof(GeneratorAttribute)) is GeneratorAttribute attribute)
                    propertyBindings.Add(propertyInfo, attribute);
            }
            foreach (var fieldInfo in data.GetType().GetFields(flags))
            {
                if (Attribute.GetCustomAttribute(fieldInfo, typeof(GeneratorAttribute)) is GeneratorAttribute attribute)
                    fieldBindings.Add(fieldInfo, attribute);
            }
            
            // generate data
            foreach (var info in propertyBindings.Keys)
                info.SetValue(data, propertyBindings[info].Generator.Generate());
            foreach (var info in fieldBindings.Keys)
                info.SetValue(data, fieldBindings[info].Generator.Generate());
            
            
            Console.WriteLine($"after generation: {data}");
        }
    }
}