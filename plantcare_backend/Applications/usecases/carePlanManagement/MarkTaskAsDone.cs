using Application.repositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecases.carePlanManagement
{
    public class MarkTaskAsDone
    {
        private readonly ICarePlanRepository _carePlanRepository;

        public MarkTaskAsDone(ICarePlanRepository carePlanRepository)
        {
            _carePlanRepository = carePlanRepository;
        }

        public async Task<bool> Execute(Guid carePlanId, Guid taskId)
        {
            var carePlan = await _carePlanRepository.GetByIdAsync(carePlanId);
            if (carePlan == null) return false;

            var task = carePlan.TaskList.FirstOrDefault(t => t.Id == taskId);
            if (task == null) return false;

            task.MarkAsPerformed();

            await _carePlanRepository.UpdateAsync(carePlan);
            return true;
        }
    }

}
