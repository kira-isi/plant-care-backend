using Application.repositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecases.carePlanManagement
{
    public class RemovePlantFromCarePlan
    {
        private readonly ICarePlanRepository _carePlanRepository;
        private readonly IPlantRepository _plantRepository;

        public RemovePlantFromCarePlan(ICarePlanRepository carePlanRepository, IPlantRepository plantRepository)
        {
            _carePlanRepository = carePlanRepository;
            _plantRepository = plantRepository;
        }

        public async Task<bool> ExecuteAsync(Guid carePlanId, Guid plantId)
        {
            var plan = await _carePlanRepository.GetByIdAsync(carePlanId);
            if (plan == null) return false;

            var plant = await _plantRepository.GetByIdAsync(plantId);
            if (plant == null) return false;

            plan.RemovePlant(plant.PlantID);
            await _carePlanRepository.UpdateAsync(plan);
            return true;
        }
    }
}
