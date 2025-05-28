using Application.repositoryInterfaces;
using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecases.carePlanManagement
{
    public class GetOverdueTasksForCarePlan
    {
        private readonly ICarePlanRepository _carePlanRepository;

        public GetOverdueTasksForCarePlan(ICarePlanRepository carePlanRepository)
        {
            _carePlanRepository = carePlanRepository;
        }

        public async Task<List<CareTask>> Execute(Guid carePlanId)
        {
            var carePlan = await _carePlanRepository.GetByIdAsync(carePlanId);
            if (carePlan == null) return new List<CareTask>();

            return carePlan.GetOverdueActions();
        }
    }
}
