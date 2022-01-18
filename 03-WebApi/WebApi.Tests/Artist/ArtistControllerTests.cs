using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Artist;
using WebApi.Artist.Request;
using Xunit;

namespace WebApi.Tests.Artist;

public class ArtistControllerTests
{
    [Fact]
    public async Task ShouldAddArtist()
    {
        // Arrange
        var artistRequest = new AddArtistRequest() { Name = "artist" };
        var mockedArtistService = new Mock<IArtistService>();
        mockedArtistService.Setup(service => service.Save(artistRequest))
            .ReturnsAsync(new WebApi.Artist.Artist() { Name = "artist" });
        var controller = new ArtistsController(mockedArtistService.Object);

        // Act
        var result = await controller.Post(artistRequest);

        // Assert
        result.Name.Should().Be(artistRequest.Name);
    }
}
