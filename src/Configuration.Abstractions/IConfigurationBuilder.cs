using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Rocket.Surgery.Builders;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.Conventions.Reflection;
using Rocket.Surgery.Conventions.Scanners;

namespace Rocket.Surgery.Extensions.Configuration
{
    /// <summary>
    /// Interface ILoggingConvention
    /// </summary>
    /// TODO Edit XML Comment Template for ILoggingConvention
    public interface IConfigurationBuilder : IBuilder, IConventionContainer<IConfigurationBuilder, IConfigurationConvention, ConfigurationConventionDelegate> { }
}
