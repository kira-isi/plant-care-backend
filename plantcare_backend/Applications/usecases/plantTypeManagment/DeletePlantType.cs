using Application.repositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecases.locationManagment
{
    public class DeletePlantType
    {
        private readonly ILocationRepository _locationRepository;

        public DeletePlantType(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<bool> ExecuteAsync(Guid locationId)
        {
            var location = await _locationRepository.GetByIdAsync(locationId);
            if (location == null) return false;

            await _locationRepository.DeleteAsync(location);
            return true;
        }
    }
}
