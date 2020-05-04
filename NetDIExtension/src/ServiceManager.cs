using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace NetDIExtension
{
    /// <summary>
    /// A management class of NetDIExtension.
    /// </summary>
    public static class ServiceManager
    {
        /// <summary>
        /// Scans and register services (classes annotated to be registered to DI container).
        /// </summary>
        /// <param name="services">IServiceCollection for register services.</param>
        /// <param name="isDebug">Specifies true if debug output is needed.</param>
        public static void Scan(IServiceCollection services, bool isDebug = false)
        {
            Action<string> output = _ => { };
            if (isDebug) { output = Console.WriteLine; }

            foreach (var classType in Assembly.GetCallingAssembly().GetTypes())
            {
                if (classType.GetCustomAttribute<ServiceAttribute>(true) is ServiceAttribute sa)
                {
                    output($"NetDIExtension: registered <{sa.ServiceLifetime}> -> {classType.Name}");

                    Type serviceType = GetServiceType(classType, sa);
                    Type implementType = classType;

                    Func<Type, Type, IServiceCollection> addService = sa.ServiceLifetime switch
                    {
                        ServiceLifetime.Transient => services.AddTransient,
                        ServiceLifetime.Scoped => services.AddScoped,
                        ServiceLifetime.Singleton => services.AddSingleton,
                        _ => throw new InvalidOperationException("NetDIExtension: ServiceLifetime not specified."),
                    };

                    // register service and implement to DI container.
                    addService(serviceType, implementType);
                }
                else
                {
                    output($"NetDIExtension: skipped -> {classType.Name}");
                }
            }
        }

        private static Type GetServiceType(Type classtype, ServiceAttribute sa)
        {
            if (sa.ServiceType != null)
                return sa.ServiceType;

            if (!sa.FindService)
                return classtype;

            Type[] interfaces = GetSimilarNamedInterfaces(classtype);

            return interfaces.Length switch
            {
                0 => classtype,
                1 => interfaces[0],
                _ => throw new NetDIExtensionException($"NetDIExtension: cannot specify appropriate service interface for class <{classtype.Name}>"),
            };
        }

        private static Type[] GetSimilarNamedInterfaces(Type type)
        {
            string className = GetClassNameForFindingInterface(type);

            Type[] interfaces = type.GetInterfaces()
                .Where(i => i.Name.Contains(className, StringComparison.CurrentCultureIgnoreCase))
                .ToArray();

            return interfaces;
        }

        private static string GetClassNameForFindingInterface(Type type) => type.Name.Replace("Impl", "");

    }
}
