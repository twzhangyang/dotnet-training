using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace WebApi.Tests.Artist;

public class ArtistTests : IClassFixture<MusicWebApplicationFactory<Program>>
{
    private readonly MusicWebApplicationFactory<Program> _factory;

    public ArtistTests(MusicWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetArtistListTest()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/api/Artists");

        // Assert
        response.EnsureSuccessStatusCode();
        var artists = await response.Content.ReadFromJsonAsync<List<WebApi.Artist.Artist>>();

        artists!.Count.Should().Be(1);
    }
}
