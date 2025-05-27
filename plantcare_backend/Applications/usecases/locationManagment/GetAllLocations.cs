using Application.repositoryInterfaces;
using Domain.valueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecases.locationManagment
{
    public class GetAllLocations
    {
        private readonly ILocationRepository _locationRepository;

        public GetAllLocations(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<List<Location>> ExecuteAsync()
        {
            return await _locationRepository.GetAllAsync();
        }
    }
}
