using Application.repositoryInterfaces;
using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecases.carePlanManagement
{
    public class DeleteCarePlan
    {
        private readonly ICarePlanRepository _carePlanRepository;

        public DeleteCarePlan(ICarePlanRepository carePlanRepository)
        {
            _carePlanRepository = carePlanRepository;
        }

        public async Task<bool> ExecuteAsync(Guid carePlanId)
        {
            CarePlan plan = await _carePlanRepository.GetByIdAsync(carePlanId);
            if (plan == null) return false;

            await _carePlanRepository.DeleteAsync(plan);
            return true;
        }
    }
}
