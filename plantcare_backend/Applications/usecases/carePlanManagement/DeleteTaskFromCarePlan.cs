using Application.repositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecases.carePlanManagement
{
    public class DeleteTaskFromCarePlan
    {
        private readonly ICarePlanRepository _carePlanRepository;

        public DeleteTaskFromCarePlan(ICarePlanRepository carePlanRepository)
        {
            _carePlanRepository = carePlanRepository;
        }

        public async Task<bool> ExecuteAsync(Guid carePlanId, Guid taskId)
        {
            var carePlan = await _carePlanRepository.GetByIdAsync(carePlanId);
            if (carePlan == null) return false;

            carePlan.RemoveTask(taskId);
            await _carePlanRepository.UpdateAsync(carePlan);
            return true;
        }
    }
}
