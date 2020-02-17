using FluentAssertions;
using HealthChecksUIClient;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace HealthChecjsUIClientTests
{
    public class TestConcurrencyIssues2 : IClassFixture<MyWebFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public TestConcurrencyIssues2(
            MyWebFactory<Startup> factory
        ) {
            this.factory = factory.WithWebHostBuilder(builder => {
                
            });
        }

        [Fact]
        public async Task TestConcurrency_1()
        {
            // Arrange
            var client = factory.CreateClient();

            // Act
            var result = await client.GetAsync("/WeatherForecast");

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public Task TestConcurrency_2()
        {
            return TestConcurrency_1();
        }

        [Fact]
        public Task TestConcurrency_3()
        {
            return TestConcurrency_1();
        }

        [Fact]
        public Task TestConcurrency_4()
        {
            return TestConcurrency_1();
        }
        [Fact]
        public Task TestConcurrency_5()
        {
            return TestConcurrency_1();
        }
        [Fact]
        public Task TestConcurrency_6()
        {
            return TestConcurrency_1();
        }
        [Fact]
        public Task TestConcurrency_7()
        {
            return TestConcurrency_1();
        }

    }
}
