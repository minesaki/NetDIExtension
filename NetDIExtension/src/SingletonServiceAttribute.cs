using System;

namespace NetDIExtension
{
    /// <summary>
    /// <para>Represents the class must be registered as SingletonService to DI container.</para>
    /// </summary>
    public class SingletonServiceAttribute : ServiceAttribute
    {
        private const ServiceLifetime Singleton = ServiceLifetime.Singleton;

        /// <summary>
        /// Specifies the class to be registered as SingletonService to DI container.
        /// </summary>
        /// <param name="findService">Specifies whether to register interface with similar name to the class automatically.</param>
        public SingletonServiceAttribute(bool findService = true) : base(Singleton, findService) { }

        /// <summary>
        /// Specifies the class implements <c>serviceType</c> and to be registered as SingletonService to DI container.
        /// </summary>
        /// <param name="serviceType">Specifies the type to be registered as a service of the class.</param>
        public SingletonServiceAttribute(Type serviceType) : base(Singleton, serviceType) { }
    }
}
