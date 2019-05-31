using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.Conventions.Reflection;
using System.Collections.Generic;

namespace Rocket.Surgery.Extensions.Configuration
{
    public interface IConfigurationConventionContext : IConventionContext, Microsoft.Extensions.Configuration.IConfigurationBuilder
    {
        new IDictionary<object, object> Properties { get; }
        IHostEnvironment Environment { get; }
        IConfiguration Configuration { get; }
    }
}
