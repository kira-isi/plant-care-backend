using Application.repositoryInterfaces;
using Domain.entities;
using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecases.locationManagment
{
    public class GetAllPlantType
    {
        private readonly IPlantTypeRepository _plantTypeRepository;

        public GetAllPlantType(IPlantTypeRepository plantTypeRepository)
        {
            _plantTypeRepository = plantTypeRepository;
        }

        public async Task<List<PlantType>> ExecuteAsync()
        {
            return await _plantTypeRepository.GetAllAsync();
        }
    }
}
