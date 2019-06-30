using Rocket.Surgery.Conventions;

namespace Rocket.Surgery.Extensions.WebJobs
{
    /// <summary>
    /// IWebJobsConventionBuilder.
    /// Implements the <see cref="Rocket.Surgery.Conventions.IConventionBuilder{Rocket.Surgery.Extensions.WebJobs.IWebJobsConventionBuilder, Rocket.Surgery.Extensions.WebJobs.IWebJobsConvention, Rocket.Surgery.Extensions.WebJobs.WebJobsConventionDelegate}" />
    /// Implements the <see cref="Rocket.Surgery.Extensions.WebJobs.IWebJobsConventionContext" />
    /// </summary>
    /// <seealso cref="Rocket.Surgery.Conventions.IConventionBuilder{Rocket.Surgery.Extensions.WebJobs.IWebJobsConventionBuilder, Rocket.Surgery.Extensions.WebJobs.IWebJobsConvention, Rocket.Surgery.Extensions.WebJobs.WebJobsConventionDelegate}" />
    /// <seealso cref="Rocket.Surgery.Extensions.WebJobs.IWebJobsConventionContext" />
    public interface IWebJobsConventionBuilder : IConventionBuilder<IWebJobsConventionBuilder, IWebJobsConvention, WebJobsConventionDelegate>, IWebJobsConventionContext
    {
        /// <summary>
        /// Build the service provider from this container
        /// </summary>
        void Build();
    }
}
