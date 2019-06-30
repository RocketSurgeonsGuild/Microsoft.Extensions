using Rocket.Surgery.Conventions;

namespace Rocket.Surgery.Extensions.Configuration
{
    /// <summary>
    ///  ILoggingConvention
    /// Implements the <see cref="Rocket.Surgery.Conventions.IConvention{Rocket.Surgery.Extensions.Configuration.IConfigurationConventionContext}" />
    /// </summary>
    /// <seealso cref="Rocket.Surgery.Conventions.IConvention{Rocket.Surgery.Extensions.Configuration.IConfigurationConventionContext}" />
    public interface IConfigurationConvention : IConvention<IConfigurationConventionContext>
    {

    }
}
