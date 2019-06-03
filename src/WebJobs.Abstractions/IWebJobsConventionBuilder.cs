using Rocket.Surgery.Conventions;

namespace Rocket.Surgery.Extensions.WebJobs
{
    /// <summary>
    /// Class IWebJobsConventionBuilder.
    /// </summary>
    /// TODO Edit XML Comment Template for IWebJobsConventionBuilder
    public interface IWebJobsConventionBuilder : IConventionBuilder<IWebJobsConventionBuilder, IWebJobsConvention, WebJobsConventionDelegate>, IWebJobsConventionContext
    {
        /// <summary>
        /// Build the service provider from this container
        /// </summary>
        void Build();
    }
}
