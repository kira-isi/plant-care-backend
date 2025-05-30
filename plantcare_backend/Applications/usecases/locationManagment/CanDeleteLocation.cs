using Application.repositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecases.locationManagment
{
    public class CanDeleteLocation
    {
        private readonly IPlantRepository _plantRepository;

        public CanDeleteLocation(IPlantRepository plantRepository)
        {
            _plantRepository = plantRepository;
        }

        public async Task<bool> ExecuteAsync(Guid locationId)
        {
            var allPlants = await _plantRepository.GetAllAsync();
            return !allPlants.Any(p => p.LocationId == locationId);
        }
    }
}