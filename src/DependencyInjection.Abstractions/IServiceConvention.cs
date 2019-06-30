using Rocket.Surgery.Conventions;

namespace Rocket.Surgery.Extensions.DependencyInjection
{
    /// <summary>
    /// Interface IServiceConvention
    /// Implements the <see cref="Rocket.Surgery.Conventions.IConvention{Rocket.Surgery.Extensions.DependencyInjection.IServiceConventionContext}" />
    /// </summary>
    /// <seealso cref="Rocket.Surgery.Conventions.IConvention{Rocket.Surgery.Extensions.DependencyInjection.IServiceConventionContext}" />
    public interface IServiceConvention : IConvention<IServiceConventionContext>
    {
    }
}
