using System;

namespace NetDIExtension
{
    /// <summary>
    /// <para>Represents the class must be registered as ScopedService to DI container.</para>
    /// </summary>
    public class ScopedServiceAttribute : ServiceAttribute
    {
        private const ServiceLifetime Scoped = ServiceLifetime.Scoped;

        /// <summary>
        /// Specifies the class to be registered as ScopedService to DI container.
        /// </summary>
        /// <param name="findService">Specifies whether to register interface with similar name to the class automatically.</param>
        public ScopedServiceAttribute(bool findService = true) : base(Scoped, findService) { }

        /// <summary>
        /// Specifies the class implements <c>serviceType</c> and to be registered as ScopedService to DI container.
        /// </summary>
        /// <param name="serviceType">Specifies the type to be registered as a service of the class.</param>
        public ScopedServiceAttribute(Type serviceType): base(Scoped, serviceType) { }
    }
}
