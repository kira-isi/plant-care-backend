using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.repositoryInterfaces
{
    public interface ICarePlanRepository : IGenericRepository<CarePlan>
    {
        Task<IEnumerable<CarePlan>> GetPlansWithDueAsync();
        Task<IEnumerable<CarePlan>> GetPlansWithOverdueAsync();
    }
}
