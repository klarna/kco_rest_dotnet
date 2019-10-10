namespace Klarna.Rest.Core.Communication
{
    /// <summary>
    /// Reference of generic type. Uses to collect data for "out" params.
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    public class Ref<T>
    {
        /// <summary>
        /// Value of generic type
        /// </summary>
        public T Value;
    }
}