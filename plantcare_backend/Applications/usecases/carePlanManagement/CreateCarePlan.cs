using Domain.entities;
using Application.repositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecases.carePlanManagement
{
    public class CreateCarePlan
    {
        private readonly ICarePlanRepository _carePlanRepository;
        private readonly IPlantRepository _plantRepository;

        public CreateCarePlan(ICarePlanRepository carePlanRepository, IPlantRepository plantRepository)
        {
            _carePlanRepository = carePlanRepository;
            _plantRepository = plantRepository;
        }

        public async Task<Guid> Execute(string name, List<Guid> plants)
        {
            var carePlan = new CarePlan(name);

            foreach (var plantId in plants)
            {
                var plant = await _plantRepository.GetByIdAsync(plantId);
                if (plant != null)
                {
                    carePlan.AddPlant(plant);
                }
            }

            await _carePlanRepository.AddAsync(carePlan);

            return carePlan.Id;
        }
    }
}