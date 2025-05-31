using Application.repositoryInterfaces;
using Application.usecases.locationManagment;
using entities;
using Moq;

namespace Tests
{
    public class LocationTests
    {
        [Fact]
        public async Task ExecuteAsync_AddsLocationToRepo()
        {
            // Arrange
            var repoMock = new Mock<ILocationRepository>();
            var useCase = new CreateLocation(repoMock.Object);

            // Act
            await useCase.ExecuteAsync("Fenster", "Nordseite");

            // Assert
            repoMock.Verify(r => r.AddAsync(It.Is<Location>(l => l.Name == "Fenster" && l.Description == "Nordseite")), Times.Once);
        }

        [Fact]
        public async Task ExecuteAsync_ThrowsArgumentException_WhenNameIsEmpty()
        {
            // Arrange
            var repoMock = new Mock<ILocationRepository>();
            var useCase = new CreateLocation(repoMock.Object);

            // Act
            var action = async () => await useCase.ExecuteAsync("", "Nordseite");

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(action);
        }

        [Fact]
        public async Task ExecuteAsync_ReturnsCorrectLocation()
        {
            // Arrange
            var locationId = Guid.NewGuid();
            var expectedLocation = new Location(locationId, "Fenster", "Südseite");
            var repoMock = new Mock<ILocationRepository>();
            repoMock.Setup(r => r.GetByIdAsync(locationId)).ReturnsAsync(expectedLocation);
            var useCase = new GetLocationById(repoMock.Object);

            // Act
            var result = await useCase.ExecuteAsync(locationId);

            // Assert
            Assert.Equal(expectedLocation, result);
        }

        [Fact]
        public async Task ExecuteAsync_ReturnsNull_WhenLocationNotFound()
        {
            // Arrange
            var unknownId = Guid.NewGuid();
            var repoMock = new Mock<ILocationRepository>();
            repoMock.Setup(r => r.GetByIdAsync(unknownId)).ReturnsAsync((Location?)null);
            var useCase = new GetLocationById(repoMock.Object);

            // Act
            var result = await useCase.ExecuteAsync(unknownId);

            // Assert
            Assert.Null(result);
        }

    }
}