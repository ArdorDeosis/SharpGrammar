using System;
using System.Collections.Generic;

namespace SharpGrammar
{
    /// <summary>
    /// Marker interface for context modules.
    /// TODO: this might be obsolete and probably could be removed.
    /// </summary>
    public interface IContextModule
    {
    }

    public class MemoryModule<T> : IContextModule
    {
    }
}