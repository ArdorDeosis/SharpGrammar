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

            Dictionary<PropertyInfo, GeneratorAttribute> workingRepresentation = new ();

            // collect data
            foreach (var propertyInfo in data.GetType().GetProperties())
            {
                if (Attribute.GetCustomAttribute(propertyInfo, typeof(GeneratorAttribute)) is GeneratorAttribute attribute)
                    workingRepresentation.Add(propertyInfo, attribute);
            }
            
            // generate data
            foreach (var info in workingRepresentation.Keys)
                info.SetValue(data, workingRepresentation[info].Generator.Generate());
            
            
            Console.WriteLine($"after generation: {data}");
        }
    }
}