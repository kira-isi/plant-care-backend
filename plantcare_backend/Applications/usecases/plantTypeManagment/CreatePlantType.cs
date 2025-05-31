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
    public class CreatePlantType
    {
        private readonly IPlantTypeRepository _plantTypeRepository;

        public CreatePlantType(IPlantTypeRepository plantTypeRepository)
        {
            _plantTypeRepository = plantTypeRepository;
        }

        public async Task<Guid> ExecuteAsync(string name, int requiredWaterAmountMl, int weeklyWateringTimes, bool needsDirectSunlight)
        {
            var plantType = new PlantType(name, requiredWaterAmountMl, weeklyWateringTimes, needsDirectSunlight);
            await _plantTypeRepository.AddAsync(plantType);
            return plantType.Id;
        }
    }
}
