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
    public static class LoggingExtensions
    {
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
