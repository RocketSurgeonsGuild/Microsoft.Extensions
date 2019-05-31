using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.Conventions.Reflection;

namespace Rocket.Surgery.Extensions.DependencyInjection
{
    public interface IServiceConventionContext : IConventionContext
    {
        IConfiguration Configuration { get; }
        IHostEnvironment Environment { get; }
        IAssemblyProvider AssemblyProvider { get; }
        IAssemblyCandidateFinder AssemblyCandidateFinder { get; }
        IServiceCollection Services { get; }
        IObservable<IServiceProvider> OnBuild { get; }
    }
}
