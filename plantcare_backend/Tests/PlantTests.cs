using Application.repositoryInterfaces;
using Application.usecases.plantManagment;
using Domain.entities;
using entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tests
{
    public class PlantTests
    {
        [Fact]
        public async Task ExecuteAsync_CreatesPlantWithCorrectValues()
        {
            // Arrange
            var repoMock = new Mock<IPlantRepository>();
            var useCase = new CreatePlant(repoMock.Object);
            var type = new PlantType("Aloe", 200, 1, false);
            var location = new Location("Fenster", "Süd");

            // Act
            var id = await useCase.ExecuteAsync(type, location, "Meine Aloe");

            // Assert
            repoMock.Verify(r => r.AddAsync(It.Is<Plant>(p =>
                p.Name == "Meine Aloe" &&
                p.PlantTypeId == type.Id &&
                p.LocationId == location.Id)), Times.Once);
        }

        [Fact]
        public async Task ExecuteAsync_ReturnsFalse_WhenPlantNotFound()
        {
            // Arrange
            var repo = new Mock<IPlantRepository>();
            repo.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Plant?)null);
            var useCase = new DeletePlant(repo.Object);

            // Act
            var result = await useCase.ExecuteAsync(Guid.NewGuid());

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task ExecuteAsync_UpdatesPlantLocation()
        {
            // Arrange
            var originalLocation = Guid.NewGuid();
            var newLocation = new Location("Balkon", "Ostseite");
            var plant = new Plant(Guid.NewGuid(), originalLocation, "Umzugspflanze");

            var repo = new Mock<IPlantRepository>();
            repo.Setup(r => r.GetByIdAsync(plant.Id)).ReturnsAsync(plant);
            var useCase = new RelocatePlant(repo.Object);

            // Act
            var result = await useCase.ExecuteAsync(plant.Id, newLocation);

            // Assert
            Assert.True(result);
            Assert.Equal(newLocation.Id, plant.LocationId);
            repo.Verify(r => r.UpdateAsync(plant), Times.Once);
        }

        [Fact]
        public async Task ExecuteAsync_ReturnsFalse_WhenPlantIsInCarePlan()
        {
            // Arrange
            var plantId = Guid.NewGuid();
            var mock = new Mock<ICarePlanRepository>();
            mock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<CarePlan>
            {
                new CarePlan(Guid.NewGuid(), "TestCarePlan", new List<CareTask>(), new List<Guid> { plantId }),

            });
            var useCase = new CanDeletePlant(mock.Object);

            // Act
            var result = await useCase.ExecuteAsync(plantId);

            // Assert
            Assert.False(result);
        }
    }

}
