using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.Conventions.Reflection;
using Rocket.Surgery.Conventions.Scanners;

namespace Rocket.Surgery.Extensions.WebJobs
{
    public class WebJobsConventionBuilder : ConventionBuilder<IWebJobsConventionBuilder, IWebJobsConvention, WebJobsConventionDelegate>, IWebJobsConventionBuilder
    {
        private readonly DiagnosticSource _diagnosticSource;

        public WebJobsConventionBuilder(
            IConventionScanner scanner,
            IAssemblyProvider assemblyProvider,
            IAssemblyCandidateFinder assemblyCandidateFinder,
            IWebJobsBuilder webJobsBuilder,
            IConfiguration configuration,
            IRocketEnvironment environment,
            DiagnosticSource diagnosticSource,
            IDictionary<object, object> properties)
            : base(scanner, assemblyProvider, assemblyCandidateFinder, properties)
        {
            Environment = environment ?? throw new ArgumentNullException(nameof(environment));
            _diagnosticSource = diagnosticSource ?? throw new ArgumentNullException(nameof(diagnosticSource));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            WebJobsBuilder = webJobsBuilder ?? throw new ArgumentNullException(nameof(webJobsBuilder));
            Services = webJobsBuilder.Services ?? throw new ArgumentNullException(nameof(webJobsBuilder));
            Logger = new DiagnosticLogger(diagnosticSource);
        }

        /// <summary>
        /// Calls all conventions and loads them into the webJobsBuilder
        /// </summary>
        /// <returns></returns>
        public void Build()
        {
            new ConventionComposer(Scanner)
                .Register(this, typeof(IWebJobsConvention), typeof(WebJobsConventionDelegate));
        }

        public IWebJobsBuilder WebJobsBuilder { get; }
        public IConfiguration Configuration { get; }
        public IServiceCollection Services { get; }
        public ILogger Logger { get; }
        public IRocketEnvironment Environment { get; }
    }
}
