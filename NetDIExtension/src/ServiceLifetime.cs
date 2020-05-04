using System;
using System.Collections.Generic;
using System.Text;

namespace NetDIExtension
{
    /// <summary>
    /// Represents the lifetime of a service in an DI container.
    /// </summary>
    public enum ServiceLifetime
    {
        /// <summary>
        /// Specifies that a new instance of the service will be created every time it is requested.
        /// </summary>
        Transient,

        /// <summary>
        /// Specifies that a new instance of the service will be created for each scope.
        /// </summary>
        Scoped,

        /// <summary>
        /// Specifies that a single instance of the service will be created.
        /// </summary>
        Singleton,
    }
}
