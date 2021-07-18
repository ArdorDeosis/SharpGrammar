using System;

namespace SharpGrammar
{
    /// <summary>
    /// Information about a binding to the <see cref="IContext"/>. 
    /// </summary>
    public readonly struct BindingInformation
    {
        public readonly object BoundInstance;
        public readonly Type BoundType;
        public readonly string StackTrace;
        
        public BindingInformation(object boundInstance, Type boundType, string stackTrace)
        {
            BoundInstance = boundInstance;
            BoundType = boundType;
            StackTrace = stackTrace;
        }
    }
}