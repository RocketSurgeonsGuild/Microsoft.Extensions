using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.Conventions.Scanners;
using Rocket.Surgery.Extensions.DependencyInjection;

namespace Rocket.Surgery.Extensions.Logging
{
    /// <summary>
    /// LoggingServiceConvention.
    /// Implements the <see cref="Rocket.Surgery.Extensions.DependencyInjection.IServiceConvention" />
    /// Implements the <see cref="Rocket.Surgery.Extensions.Logging.ILoggingConvention" />
    /// </summary>
    /// <seealso cref="Rocket.Surgery.Extensions.DependencyInjection.IServiceConvention" />
    /// <seealso cref="Rocket.Surgery.Extensions.Logging.ILoggingConvention" />
    public class LoggingServiceConvention : IServiceConvention, ILoggingConvention
    {
        /// <summary>
        /// Registers the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public void Register(IServiceConventionContext context)
        {
            var loggingBuilder = new LoggingBuilder(
                context.Get<IConventionScanner>(),
                context.AssemblyProvider,
                context.AssemblyCandidateFinder,
                context.Services,
                context.Environment,
                context.Configuration,
                context.Logger,
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
