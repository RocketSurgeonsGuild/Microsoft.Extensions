﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rocket.Surgery.Builders;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.Conventions.Reflection;
using Rocket.Surgery.Conventions.Scanners;
using Rocket.Surgery.Extensions.DependencyInjection.Internals;

namespace Rocket.Surgery.Extensions.DependencyInjection
{
    public class ServicesBuilder : ConventionBuilder<IServicesBuilder, IServiceConvention, ServiceConventionDelegate>, IServicesBuilder
    {
        private readonly DiagnosticSource _diagnosticSource;
        private readonly ServiceProviderObservable _onBuild;

        public ServicesBuilder(
            IConventionScanner scanner,
            IAssemblyProvider assemblyProvider,
            IAssemblyCandidateFinder assemblyCandidateFinder,
            IServiceCollection services,
            IConfiguration configuration,
            IHostEnvironment environment,
            DiagnosticSource diagnosticSource,
            IDictionary<object, object> properties)
            : base(scanner, assemblyProvider, assemblyCandidateFinder, properties)
        {
            _diagnosticSource = diagnosticSource ?? throw new ArgumentNullException(nameof(diagnosticSource));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            Environment = environment ?? throw new ArgumentNullException(nameof(environment));

            Services = services ?? throw new ArgumentNullException(nameof(services));
            Logger = new DiagnosticLogger(diagnosticSource);
            _onBuild = new ServiceProviderObservable(Logger);
            ServiceProviderOptions = new ServiceProviderOptions()
            {
                ValidateScopes = environment.IsDevelopment(),
            };
        }

        protected override IServicesBuilder GetBuilder() => this;
        public ServiceProviderOptions ServiceProviderOptions { get; }

        /// <summary>
        /// Builds the root container, and returns the lifetime scopes for the application and system containers
        /// </summary>
        /// <param name="logger"></param>
        /// <returns></returns>
        public IServiceProvider Build()
        {
            new ConventionComposer(Scanner)
                .Register(this, typeof(IServiceConvention), typeof(ServiceConventionDelegate));

            var result = Services.BuildServiceProvider(ServiceProviderOptions);
            _onBuild.Send(result);
            return result;
        }

        public IConfiguration Configuration { get; }
        public IHostEnvironment Environment { get; }

        public IServiceCollection Services { get; }
        public ILogger Logger { get; }
        public IObservable<IServiceProvider> OnBuild => _onBuild;
    }
}
