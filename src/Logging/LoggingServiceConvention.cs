using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Rocket.Surgery.Conventions.Scanners;
using Rocket.Surgery.Extensions.DependencyInjection;

namespace Rocket.Surgery.Extensions.Logging
{
    /// <summary>
    /// Class LoggingServiceConvention.
    /// Implements the <see cref="Rocket.Surgery.Extensions.DependencyInjection.IServiceConvention" />
    /// Implements the <see cref="Rocket.Surgery.Extensions.Logging.ILoggingConvention" />
    /// </summary>
    /// <seealso cref="Rocket.Surgery.Extensions.DependencyInjection.IServiceConvention" />
    /// <seealso cref="Rocket.Surgery.Extensions.Logging.ILoggingConvention" />
    public class LoggingServiceConvention : IServiceConvention, ILoggingConvention
    {
        private readonly IConventionScanner _scanner;
        private readonly DiagnosticSource _diagnosticSource;
        private readonly RocketLoggingOptions _options;
        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingServiceConvention"/> class.
        /// </summary>
        /// <param name="scanner">The scanner.</param>
        /// <param name="diagnosticSource">The diagnostic source.</param>
        public LoggingServiceConvention(
            IConventionScanner scanner,
            DiagnosticSource diagnosticSource)
        {
            this._scanner = scanner;
            this._diagnosticSource = diagnosticSource;
        }

        /// <summary>
        /// Registers the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
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

        /// <summary>
        /// Registers the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public void Register(ILoggingConventionContext context)
        {
            context.AddConfiguration(context.Configuration.GetSection("Logging"));
        }
    }
}
