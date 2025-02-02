using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plant_care._4_domain_code
{
    public interface ICarePlanRepository
    {
        Task<IEnumerable<CarePlan>> GetPlansWithDueAsync();
        Task<IEnumerable<CarePlan>> GetPlansWithOverdueAsync();
    }
}
