using Microsoft.Extensions.Configuration;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.Conventions.Reflection;

namespace Rocket.Surgery.Extensions.Logging
{
    /// <summary>
    /// Interface ILoggingConvention
    /// Implements the <see cref="Rocket.Surgery.Conventions.IConventionBuilder{Rocket.Surgery.Extensions.Logging.ILoggingBuilder, Rocket.Surgery.Extensions.Logging.ILoggingConvention, Rocket.Surgery.Extensions.Logging.LoggingConventionDelegate}" />
    /// </summary>
    /// <seealso cref="Rocket.Surgery.Conventions.IConventionBuilder{Rocket.Surgery.Extensions.Logging.ILoggingBuilder, Rocket.Surgery.Extensions.Logging.ILoggingConvention, Rocket.Surgery.Extensions.Logging.LoggingConventionDelegate}" />
    public interface ILoggingBuilder : IConventionBuilder<ILoggingBuilder, ILoggingConvention, LoggingConventionDelegate> { }
}
