using Application.repositoryInterfaces;
using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecases.locationManagment
{
    public class CreatePlantType
    {
        private readonly ILocationRepository _locationRepository;

        public CreatePlantType(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<Guid> ExecuteAsync(string name, string? description)
        {
            var location = new Location(name, description);
            await _locationRepository.AddAsync(location);
            return location.Id;
        }
    }
}
