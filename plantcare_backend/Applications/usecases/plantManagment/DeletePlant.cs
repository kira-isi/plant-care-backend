using Application.repositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecases.plantManagment
{
    public class DeletePlant
    {
        private readonly IPlantRepository _plantRepository;

        public DeletePlant(IPlantRepository plantRepository)
        {
            _plantRepository = plantRepository;
        }

        public async Task<bool> ExecuteAsync(Guid plantId)
        {
            var plant = await _plantRepository.GetByIdAsync(plantId);
            if (plant == null)
                return false;

            await _plantRepository.DeleteAsync(plant);
            return true;
        }
    }
}
