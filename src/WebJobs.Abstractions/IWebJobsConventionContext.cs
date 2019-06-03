using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.Conventions.Reflection;

namespace Rocket.Surgery.Extensions.WebJobs
{
    public interface IWebJobsConventionContext : IConventionContext, IWebJobsBuilder
    {
        IConfiguration Configuration { get; }
        IAssemblyProvider AssemblyProvider { get; }
        IAssemblyCandidateFinder AssemblyCandidateFinder { get; }

        /// <summary>
        /// The environment that this convention is running
        ///
        /// Based on IHostEnvironment / IHostingEnvironment
        /// </summary>
        IRocketEnvironment Environment { get; }
    }
}
