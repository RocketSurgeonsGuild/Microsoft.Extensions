using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rocket.Surgery.Builders;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.Conventions.Reflection;
using Rocket.Surgery.Conventions.Scanners;
using Rocket.Surgery.Extensions.Logging;

namespace Rocket.Surgery.Extensions.Logging
{
    /// <summary>
    /// Logging Builder
    /// </summary>
    public class LoggingBuilder : ConventionBuilder<ILoggingBuilder, ILoggingConvention, LoggingConventionDelegate>, ILoggingBuilder, ILoggingConventionContext
    {
        public LoggingBuilder(
            IConventionScanner scanner,
            IAssemblyProvider assemblyProvider,
            IAssemblyCandidateFinder assemblyCandidateFinder,
            IServiceCollection services,
            IRocketEnvironment environment,
            IConfiguration configuration,
            DiagnosticSource diagnosticSource,
            IDictionary<object, object> properties) : base(environment, scanner, assemblyProvider, assemblyCandidateFinder, properties)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            var diagnosticSource1 = diagnosticSource ?? throw new ArgumentNullException(nameof(diagnosticSource));
            Logger = new DiagnosticLogger(diagnosticSource1);
        }

        public IServiceCollection Services { get; }
        public IConfiguration Configuration { get; }
        public ILogger Logger { get; }

        public void Build()
        {
            new ConventionComposer(Scanner).Register(
                this,
                typeof(ILoggingConvention),
                typeof(LoggingConventionDelegate)
            );
        }
    }
}
