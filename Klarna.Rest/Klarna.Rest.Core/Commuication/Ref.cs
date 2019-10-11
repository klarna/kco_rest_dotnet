using System;

namespace Klarna.Rest.Core.Commuication
{
    /// <summary>
    /// Reference of generic type. Uses to collect data for "out" params.
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    [Obsolete("Use Communication namespace instead of Commuication")]
    public class Ref<T> : Communication.Ref<T>
    { }
}