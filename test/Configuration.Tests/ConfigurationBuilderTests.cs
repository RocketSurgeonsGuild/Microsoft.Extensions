using System;
using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Rocket.Surgery.Conventions.Reflection;
using Rocket.Surgery.Conventions.Scanners;
using Rocket.Surgery.Extensions.Testing;
using Xunit;
using Xunit.Abstractions;

namespace Rocket.Surgery.Extensions.Configuration.Tests
{
    public class ConfigurationBuilderTests : AutoTestBase
    {
        public ConfigurationBuilderTests(ITestOutputHelper outputHelper) : base(outputHelper) { }

        [Fact]
        public void Constructs()
        {
            var configuration = AutoFake.Resolve<IConfiguration>();
            var builder = AutoFake.Resolve<ConfigurationBuilder>();

            builder.Configuration.Should().BeSameAs(configuration);
            Action a = () => { builder.AppendConvention(A.Fake<IConfigurationConvention>()); };
            a.Should().NotThrow();
            a = () => { builder.AppendDelegate(delegate { }); };
            a.Should().NotThrow();
        }

        [Fact]
        public void BuildsALogger()
        {
            var builder = AutoFake.Resolve<ConfigurationBuilder>();

            Action a = () => builder.Build();
            a.Should().NotThrow();
        }
    }
}
