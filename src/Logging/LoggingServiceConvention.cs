using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Rocket.Surgery.Conventions.Scanners;
using Rocket.Surgery.Extensions.DependencyInjection;

namespace Rocket.Surgery.Extensions.Logging
{
    public class LoggingServiceConvention : IServiceConvention, ILoggingConvention
    {
        private readonly IConventionScanner _scanner;
        private readonly DiagnosticSource _diagnosticSource;
        private readonly RocketLoggingOptions _options;
        public LoggingServiceConvention(
            IConventionScanner scanner,
            DiagnosticSource diagnosticSource)
        {
            this._scanner = scanner;
            this._diagnosticSource = diagnosticSource;
        }

        public void Register(IServiceConventionContext context)
        {
            var loggingBuilder = new LoggingBuilder(
                _scanner,
                context.AssemblyProvider,
                context.AssemblyCandidateFinder,
                context.Services,
                context.Environment,
                context.Configuration,
                _diagnosticSource,
                context.Properties
            );

            loggingBuilder.Build();
        }

        public void Register(ILoggingConventionContext context)
        {
            context.AddConfiguration(context.Configuration.GetSection("Logging"));
        }
    }
}
