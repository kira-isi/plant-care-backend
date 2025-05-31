using Application.repositoryInterfaces;
using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecases.locationManagment
{
    public class GetLocationById
    {
        private readonly ILocationRepository _locationRepository;

        public GetLocationById(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<Location?> ExecuteAsync(Guid id)
        {
            return await _locationRepository.GetByIdAsync(id);
        }
    }

}
