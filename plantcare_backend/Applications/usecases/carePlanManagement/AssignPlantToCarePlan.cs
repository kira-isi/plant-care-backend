using Application.repositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecases.carePlanManagement
{
    public class AssignPlantToCarePlan
    {
        private readonly ICarePlanRepository _carePlanRepository;
        private readonly IPlantRepository _plantRepository;

        public AssignPlantToCarePlan(
            ICarePlanRepository carePlanRepository,
            IPlantRepository plantRepository)
        {
            _carePlanRepository = carePlanRepository;
            _plantRepository = plantRepository;
        }

        public async Task<bool> ExecuteAsync(Guid carePlanId, Guid plantId)
        {
            var carePlan = await _carePlanRepository.GetByIdAsync(carePlanId);
            if (carePlan == null) return false;

            var plant = await _plantRepository.GetByIdAsync(plantId);
            if (plant == null) return false;

            carePlan.addPlant(plant);
            await _carePlanRepository.UpdateAsync(carePlan);
            return true;
        }
    }
}
