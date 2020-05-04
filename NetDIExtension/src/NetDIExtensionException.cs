using System;
using System.Collections.Generic;
using System.Text;

namespace NetDIExtension
{
    /// <summary>
    /// An Exception of NetDIExtension.
    /// </summary>
    public class NetDIExtensionException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the Exception class.
        /// </summary>
        public NetDIExtensionException() { }

        /// <summary>
        /// Initializes a new instance of the Exception class with a specified error message.
        /// </summary>
        /// <param name="message">The error message string.</param>
        public NetDIExtensionException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the Exception class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message string.</param>
        /// <param name="innerException">The inner exception reference.</param>
        public NetDIExtensionException(string message, Exception innerException) : base(message, innerException) { }
    }
}
