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

        public async Task<Guid> Execute(CreateCarePlanCommand command)
        {
            var carePlan = new CarePlan(command.Name);

            foreach (var plantId in command.PlantIds)
            {
                var plant = await _plantRepository.GetByIdAsync(plantId);
                if (plant != null)
                {
                    carePlan.addPlant(plant);
                }
            }

            await _carePlanRepository.AddAsync(carePlan);

            return carePlan.id;
        }
    }
}