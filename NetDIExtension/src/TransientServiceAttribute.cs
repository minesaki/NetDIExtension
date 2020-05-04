using System;

namespace NetDIExtension
{
    /// <summary>
    /// <para>Represents the class must be registered as TransientService to DI container.</para>
    /// </summary>
    public class TransientServiceAttribute : ServiceAttribute
    {
        private const ServiceLifetime Transient = ServiceLifetime.Transient;

        /// <summary>
        /// Specifies the class to be registered as TransientService to DI container.
        /// </summary>
        /// <param name="findService">Specifies whether to register interface with similar name to the class automatically.</param>
        public TransientServiceAttribute(bool findService = true) : base(Transient, findService) { }

        /// <summary>
        /// Specifies the class implements <c>serviceType</c> and to be registered as TransientService to DI container.
        /// </summary>
        /// <param name="serviceType">Specifies the type to be registered as a service of the class.</param>
        public TransientServiceAttribute(Type serviceType) : base(Transient, serviceType) { }
    }
}
