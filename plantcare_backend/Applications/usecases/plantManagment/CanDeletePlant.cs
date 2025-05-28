using Application.repositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecases.plantManagment
{
    public class CanDeletePlant
    {
        private readonly ICarePlanRepository _carePlanRepository;

        public CanDeletePlant(ICarePlanRepository carePlanRepository)
        {
            _carePlanRepository = carePlanRepository;
        }

        public async Task<bool> ExecuteAsync(Guid plantId)
        {
            var allPlans = await _carePlanRepository.GetAllAsync();
            return !allPlans.Any(plan => plan.plants.Contains(plantId));
        }
    }
}
