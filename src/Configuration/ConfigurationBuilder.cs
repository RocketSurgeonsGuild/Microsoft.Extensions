using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.Conventions.Reflection;
using Rocket.Surgery.Conventions.Scanners;
using IMsftConfigurationBuilder = Microsoft.Extensions.Configuration.IConfigurationBuilder;

namespace Rocket.Surgery.Extensions.Configuration
{
    /// <summary>
    /// Logging Builder
    /// Implements the <see cref="Rocket.Surgery.Conventions.ConventionContainerBuilder{Rocket.Surgery.Extensions.Configuration.IConfigurationBuilder, Rocket.Surgery.Extensions.Configuration.IConfigurationConvention, Rocket.Surgery.Extensions.Configuration.ConfigurationConventionDelegate}" />
    /// Implements the <see cref="Rocket.Surgery.Extensions.Configuration.IConfigurationBuilder" />
    /// Implements the <see cref="Rocket.Surgery.Extensions.Configuration.IConfigurationConventionContext" />
    /// </summary>
    /// <seealso cref="Rocket.Surgery.Conventions.ConventionContainerBuilder{Rocket.Surgery.Extensions.Configuration.IConfigurationBuilder, Rocket.Surgery.Extensions.Configuration.IConfigurationConvention, Rocket.Surgery.Extensions.Configuration.ConfigurationConventionDelegate}" />
    /// <seealso cref="Rocket.Surgery.Extensions.Configuration.IConfigurationBuilder" />
    /// <seealso cref="Rocket.Surgery.Extensions.Configuration.IConfigurationConventionContext" />
    public class ConfigurationBuilder : ConventionContainerBuilder<IConfigurationBuilder, IConfigurationConvention, ConfigurationConventionDelegate>, IConfigurationBuilder, IConfigurationConventionContext
    {
        private readonly IConventionScanner _scanner;
        private readonly IMsftConfigurationBuilder _builder;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationBuilder"/> class.
        /// </summary>
        /// <param name="scanner">The scanner.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="builder">The builder.</param>
        /// <param name="diagnosticSource">The diagnostic source.</param>
        /// <param name="properties">The properties.</param>
        /// <exception cref="ArgumentNullException">
        /// scanner
        /// or
        /// builder
        /// or
        /// configuration 
        /// or
        /// diagnosticSource
        /// </exception>
        public ConfigurationBuilder(
            IConventionScanner scanner,
            IRocketEnvironment environment,
            IConfiguration configuration,
            IMsftConfigurationBuilder builder,
            ILogger diagnosticSource,
            IDictionary<object, object> properties) : base(scanner, properties)
        {
            _scanner = scanner ?? throw new ArgumentNullException(nameof(scanner));
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            Environment = environment;
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            Logger = diagnosticSource ?? throw new ArgumentNullException(nameof(diagnosticSource));
        }

        /// <summary>
        /// Gets the environment.
        /// </summary>
        /// <value>The environment.</value>
        public IRocketEnvironment Environment { get; }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// A logger that is configured to work with each convention item
        /// </summary>
        /// <value>The logger.</value>
        public ILogger Logger { get; }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        public void Build()
        {
            new ConventionComposer(_scanner)
                .Register(
                    this,
                    typeof(IConfigurationConvention),
                    typeof(ConfigurationConventionDelegate)
                );
        }

        IMsftConfigurationBuilder IMsftConfigurationBuilder.Add(IConfigurationSource source) => _builder.Add(source);
        IConfigurationRoot IMsftConfigurationBuilder.Build() => _builder.Build();
        IDictionary<string, object> IMsftConfigurationBuilder.Properties => _builder.Properties;
        IList<IConfigurationSource> IMsftConfigurationBuilder.Sources => _builder.Sources;
    }
}
