using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Tests.Artist;
using Xunit;

namespace WebApi.Tests;

public class WeatherTests : IClassFixture<MusicWebApplicationFactory<Program>>
{
    private readonly MusicWebApplicationFactory<Program> _factory;

    public WeatherTests(MusicWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetWeatherTest()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/WeatherForecast");

        // Assert
        response.EnsureSuccessStatusCode();
        var weather = await response.Content.ReadFromJsonAsync<List<WeatherForecast>>();
        Assert.Equal(5, weather!.Count);
    }
}
