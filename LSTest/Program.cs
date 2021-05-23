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
            Dwarf dwarf = new ();
            
            Console.WriteLine($"fresh instance:   {dwarf}");

            var bindings = GetBindings(dwarf);

            // generate data
            foreach (var info in bindings.Keys)
            {
                Console.WriteLine($"handling {info.Name}");
                // do
                // {
                    SetValue(dwarf, info, bindings[info].Generate());
                // } while (dwarf.Name.Length < 15);
            }


            Console.WriteLine($"after generation: {dwarf}");
        }

        private static void SetValue(object data, MemberInfo info, object value)
        {
            switch (info)
            {
                case PropertyInfo propertyInfo:
                    propertyInfo.SetValue(data, value);
                    break;
                case FieldInfo fieldInfo:
                    fieldInfo.SetValue(data, value);
                    break;
            }
        }

        private static Dictionary<MemberInfo, IGenerator<object>> GetBindings(object data)
        {
            Dictionary<MemberInfo, IGenerator<object>> bindings = new();
            const BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
            foreach (var memberInfo in data.GetType().GetMembers(flags).Where(info => info is PropertyInfo or FieldInfo))
            {
                Console.WriteLine($"found {memberInfo.Name}");
                var memberType = memberInfo switch
                {
                    FieldInfo fieldInfo => fieldInfo.FieldType,
                    PropertyInfo propertyInfo => propertyInfo.PropertyType,
                    _ => throw new Exception("Neither a Field nor Property")
                };

                var generatorType = typeof(IGenerator).MakeGenericType(memberType);
                
                if (Attribute.GetCustomAttribute(memberInfo, typeof(GeneratorAttribute)) is GeneratorAttribute attribute)
                {
                    Convert.ChangeType(attribute.Generator, generatorType);
                    Console.WriteLine($"added {memberInfo.Name}");
                    bindings.Add(memberInfo, Convert.ChangeType(attribute.Generator, generatorType));
                }
            }
            return bindings;
        }
    }
}