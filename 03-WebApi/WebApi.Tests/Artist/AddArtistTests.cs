using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Artist.Request;
using Xunit;

namespace WebApi.Tests.Artist;

public class AddGetArtistTests : IClassFixture<MusicWebApplicationFactory<Program>>
{
    private readonly MusicWebApplicationFactory<Program> _factory;

    public AddGetArtistTests(MusicWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task ShouldGetSuccess_WhenRequestIsValid()
    {
        // Arrange
        var client = _factory.CreateClient();
        var request = new AddArtistRequest()
        {
            Gender = "Male",
            Name = "Hello artist"
        };

        // Act
        var response = await client.PostAsJsonAsync("/api/Artists", request);

        // Assert
        response.EnsureSuccessStatusCode();
    }

        [Fact]
    public async Task ShouldGetFailed_WhenGenderIsNull()
    {
        // Arrange
        var client = _factory.CreateClient();
        var request = new AddArtistRequest()
        {
            Name = "Hello artist"
        };

        // Act
        var response = await client.PostAsJsonAsync("/api/Artists", request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

}
