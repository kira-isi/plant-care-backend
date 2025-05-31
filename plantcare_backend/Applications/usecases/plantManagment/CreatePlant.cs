using Application.repositoryInterfaces;
using Domain.entities;
using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecases.plantManagment
{
    public class CreatePlant
    {
        private readonly IPlantRepository _plantRepository;

        public CreatePlant(IPlantRepository plantRepository)
        {
            _plantRepository = plantRepository;
        }

        public async Task<Guid> ExecuteAsync(PlantType type, Location location, string? name = null)
        {
            var plant = new Plant(type.Id, location.Id, name);
            await _plantRepository.AddAsync(plant);
            return plant.Id;
        }
    }
}