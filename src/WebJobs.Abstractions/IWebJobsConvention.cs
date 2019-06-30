using Rocket.Surgery.Conventions;

namespace Rocket.Surgery.Extensions.WebJobs
{
    /// <summary>
    /// Interface IWebJobsConvention
    /// Implements the <see cref="Rocket.Surgery.Conventions.IConvention{Rocket.Surgery.Extensions.WebJobs.IWebJobsConventionContext}" />
    /// </summary>
    /// <seealso cref="Rocket.Surgery.Conventions.IConvention{Rocket.Surgery.Extensions.WebJobs.IWebJobsConventionContext}" />
    public interface IWebJobsConvention : IConvention<IWebJobsConventionContext>
    {
    }
}
