using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Rocket.Surgery.Builders;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.Conventions.Reflection;
using Rocket.Surgery.Conventions.Scanners;
using IMsftConfigurationBuilder = Microsoft.Extensions.Configuration.IConfigurationBuilder;

namespace Rocket.Surgery.Extensions.Configuration
{
    /// <summary>
    /// Logging Builder
    /// </summary>
    public class ConfigurationBuilder : ConventionContainerBuilder<IConfigurationBuilder, IConfigurationConvention, ConfigurationConventionDelegate>, IConfigurationBuilder, IConfigurationConventionContext
    {
        private readonly IConventionScanner _scanner;
        private readonly IMsftConfigurationBuilder _builder;
        private readonly DiagnosticSource _diagnosticSource;

        public ConfigurationBuilder(
            IConventionScanner scanner,
            IHostingEnvironment envionment,
            IConfiguration configuration,
            IMsftConfigurationBuilder builder,
            DiagnosticSource diagnosticSource,
            IDictionary<object, object> properties): base(scanner, properties)
        {
            _scanner = scanner ?? throw new ArgumentNullException(nameof(scanner));
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            Environment = envionment ?? throw new ArgumentNullException(nameof(envionment));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _diagnosticSource = diagnosticSource ?? throw new ArgumentNullException(nameof(diagnosticSource));
            Logger = new DiagnosticLogger(diagnosticSource);
        }

        protected override IConfigurationBuilder GetBuilder() => this;

        public IHostingEnvironment Environment { get; }
        public IConfiguration Configuration { get; }
        public ILogger Logger { get; }

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
