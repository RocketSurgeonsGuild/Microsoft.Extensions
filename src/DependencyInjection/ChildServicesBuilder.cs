﻿using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rocket.Surgery.Builders;
using Rocket.Surgery.Conventions.Reflection;
using Rocket.Surgery.Conventions.Scanners;

namespace Rocket.Surgery.Extensions.DependencyInjection
{
    public abstract class ChildServicesBuilder : Builder<IServiceConventionContext>, IServiceConventionContext
    {
        protected ChildServicesBuilder(IServicesBuilder parent) : base(parent, ((IBuilder)parent).Properties) { }

        public IConfiguration Configuration => Parent.Configuration;

        public IHostingEnvironment Environment => Parent.Environment;

        public IAssemblyProvider AssemblyProvider => Parent.AssemblyProvider;

        public IAssemblyCandidateFinder AssemblyCandidateFinder => Parent.AssemblyCandidateFinder;

        public IServiceCollection Services => Parent.Services;
        public IObservable<IServiceProvider> OnBuild => Parent.OnBuild;
        public ILogger Logger => Parent.Logger;
    }
}
