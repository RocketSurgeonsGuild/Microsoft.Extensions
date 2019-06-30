using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.Conventions.Reflection;
using Rocket.Surgery.Extensions.Logging;

namespace Rocket.Surgery.Extensions.Logging
{
    /// <summary>
    /// Class LoggingExtensions.
    /// </summary>
    public static class LoggingExtensions
    {
        /// <summary>
        /// Uses the logging.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="options">The options.</param>
        /// <returns>IConventionHostBuilder.</returns>
        public static IConventionHostBuilder UseLogging(
            this IConventionHostBuilder container,
            RocketLoggingOptions options)
        {
            container.Scanner.PrependConvention(new LoggingServiceConvention(container.Scanner, container.DiagnosticSource));
            container.Scanner.AppendDelegate(new LoggingConventionDelegate(context => context.SetMinimumLevel(options.GetLogLevel(context))));
            return container;
        }
    }
}
