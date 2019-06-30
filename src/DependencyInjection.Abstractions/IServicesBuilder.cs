using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.Conventions.Reflection;

namespace Rocket.Surgery.Extensions.DependencyInjection
{
    /// <summary>
    /// IServicesBuilder.
    /// Implements the <see cref="Rocket.Surgery.Conventions.IConventionBuilder{Rocket.Surgery.Extensions.DependencyInjection.IServicesBuilder, Rocket.Surgery.Extensions.DependencyInjection.IServiceConvention, Rocket.Surgery.Extensions.DependencyInjection.ServiceConventionDelegate}" />
    /// Implements the <see cref="Rocket.Surgery.Extensions.DependencyInjection.IServiceConventionContext" />
    /// </summary>
    /// <seealso cref="Rocket.Surgery.Conventions.IConventionBuilder{Rocket.Surgery.Extensions.DependencyInjection.IServicesBuilder, Rocket.Surgery.Extensions.DependencyInjection.IServiceConvention, Rocket.Surgery.Extensions.DependencyInjection.ServiceConventionDelegate}" />
    /// <seealso cref="Rocket.Surgery.Extensions.DependencyInjection.IServiceConventionContext" />
    public interface IServicesBuilder : IConventionBuilder<IServicesBuilder, IServiceConvention, ServiceConventionDelegate>, IServiceConventionContext
    {
        /// <summary>
        /// Build the service provider from this container
        /// </summary>
        /// <returns>IServiceProvider.</returns>
        IServiceProvider Build();
    }
}
