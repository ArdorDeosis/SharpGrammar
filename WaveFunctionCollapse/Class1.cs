using System;
using System.Collections.Generic;

namespace WaveFunctionCollapse
{
    public abstract class Constraint
    {
        public abstract void Enforce(Model model);
    }
    
    public class CountConstraint : Constraint
    {
        public override void Enforce(Model model)
        {
            
        }
    }

    public class Model
    {
        private Dictionary<Type, List<object>> objects = new();

        private List<Constraint> constraints;
    }

    public class BoolModel : Collapsible<bool>
    {
    }
    
    public class Collapsible<T>
    {
        public (T, bool)[] options;
    }
}