using Application.repositoryInterfaces;
using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecases.carePlanManagement
{
    public class GetAllCarePlans
    {
        private readonly ICarePlanRepository _carePlanRepository;

        public GetAllCarePlans(ICarePlanRepository carePlanRepository)
        {
            _carePlanRepository = carePlanRepository;
        }

        public async Task<List<CarePlan>> ExecuteAsync()
        {
            return await _carePlanRepository.GetAllAsync();
        }
    }
}
