using Application.repositoryInterfaces;
using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecases.plantManagment
{
    public class GetAllPlants
    {
        private readonly IPlantRepository _plantRepository;

        public GetAllPlants(IPlantRepository plantRepository)
        {
            _plantRepository = plantRepository;
        }

        public async Task<List<Plant>> ExecuteAsync()
        {
            return await _plantRepository.GetAllAsync();
        }
    }
}
