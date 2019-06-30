using Rocket.Surgery.Conventions;

namespace Rocket.Surgery.Extensions.Logging
{
    /// <summary>
    ///  ILoggingConvention
    /// Implements the <see cref="Rocket.Surgery.Conventions.IConvention{Rocket.Surgery.Extensions.Logging.ILoggingConventionContext}" />
    /// </summary>
    /// <seealso cref="Rocket.Surgery.Conventions.IConvention{Rocket.Surgery.Extensions.Logging.ILoggingConventionContext}" />
    public interface ILoggingConvention : IConvention<ILoggingConventionContext>{}
}
