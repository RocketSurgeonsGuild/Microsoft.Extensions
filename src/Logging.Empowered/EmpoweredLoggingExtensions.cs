using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.Conventions.Reflection;
using Rocket.Surgery.Extensions.Logging;

namespace Rocket.Surgery.Extensions.Logging
{
    public static class EmpoweredLoggingExtensions
    {
        public static IConventionHostBuilder UseEmpoweredLogging(
            this IConventionHostBuilder container,
            EmpoweredLoggingOptions options)
        {
            container.Scanner.AppendConvention(new LoggingServiceConvention(container.Scanner, container.DiagnosticSource, options));
            return container;
        }
    }
}
