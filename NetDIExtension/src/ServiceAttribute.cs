using Microsoft.Extensions.DependencyInjection;
using System;

namespace NetDIExtension
{
    /// <summary>
    /// <para>Represents the class must be registered to DI container.</para>
    /// <para>To be more specific, use <see cref="TransientServiceAttribute"/>, <see cref="ScopedServiceAttribute"/> and <see cref="SingletonServiceAttribute"/>.</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ServiceAttribute : Attribute
    {
        /// <summary>
        /// Represents the lifetime of the instance.
        /// </summary>
        public ServiceLifetime ServiceLifetime { get; }

        /// <summary>
        /// Represents the class annotated with this attribute implements this <see cref="ServiceType"/>.
        /// </summary>
        public Type ServiceType { get; }

        /// <summary>
        /// <para>Represents whether to register interface automatically as a service. (default: true) </para>
        /// <para>If true, the interface having simillar name to the class will be registered as a service.</para>
        /// <para>(e.g. Interface such as "IMyService" or "MyService" will be registered as service when the class is "MyService" or "MyServiceImpl".)</para>
        /// <para>If false and <see cref="ServiceType" /> not given, the class will be registered as both service and implement.</para>
        /// </summary>
        public bool FindService { get; }

        /// <summary>
        /// Specifies the class to be registered to DI container.
        /// </summary>
        /// <param name="serviceLifetime">Lifetime of the class's instance.</param>
        /// <param name="findService">Specifies whether to register interface with similar name to the class automatically.</param>
        public ServiceAttribute(ServiceLifetime serviceLifetime, bool findService = true)
        {
            this.ServiceLifetime = serviceLifetime;
            this.ServiceType = null;
            this.FindService = findService;
        }

        /// <summary>
        /// Specifies the class implements <c>serviceType</c> and to be registered to DI container.
        /// </summary>
        /// <param name="serviceLifetime">Lifetime of the class's instance.</param>
        /// <param name="serviceType">Specifies the type to be registered as a service of the class.</param>
        public ServiceAttribute(ServiceLifetime serviceLifetime, Type serviceType)
        {
            this.ServiceLifetime = serviceLifetime;
            this.ServiceType = serviceType;
            this.FindService = false;
        }

    }
}
