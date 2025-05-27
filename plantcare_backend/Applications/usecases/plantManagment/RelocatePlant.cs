using Application.repositoryInterfaces;
using Domain.valueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecases.plantManagment
{
    public class RelocatePlant
    {
        private readonly IPlantRepository _plantRepository;

        public RelocatePlant(IPlantRepository plantRepository)
        {
            _plantRepository = plantRepository;
        }

        public async Task<bool> ExecuteAsync(Guid plantId, Location newLocation)
        {
            var plant = await _plantRepository.GetByIdAsync(plantId);
            if (plant == null) return false;

            plant.Relocate(newLocation);
            await _plantRepository.UpdateAsync(plant);
            return true;
        }
    }
}
