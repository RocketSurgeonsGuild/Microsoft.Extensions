using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.Conventions.Reflection;
using Rocket.Surgery.Conventions.Scanners;

namespace Rocket.Surgery.Extensions.Configuration
{
    /// <summary>
    /// Interface ILoggingConvention
    /// Implements the <see cref="Rocket.Surgery.Conventions.IConventionContainer{Rocket.Surgery.Extensions.Configuration.IConfigurationBuilder, Rocket.Surgery.Extensions.Configuration.IConfigurationConvention, Rocket.Surgery.Extensions.Configuration.ConfigurationConventionDelegate}" />
    /// </summary>
    /// <seealso cref="Rocket.Surgery.Conventions.IConventionContainer{Rocket.Surgery.Extensions.Configuration.IConfigurationBuilder, Rocket.Surgery.Extensions.Configuration.IConfigurationConvention, Rocket.Surgery.Extensions.Configuration.ConfigurationConventionDelegate}" />
    public interface IConfigurationBuilder : IConventionContainer<IConfigurationBuilder, IConfigurationConvention, ConfigurationConventionDelegate> { }
}
