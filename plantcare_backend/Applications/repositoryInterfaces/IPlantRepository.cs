using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.repositoryInterfaces
{
    public interface IPlantRepository : IGenericRepository<Plant>
    {
        Task<IEnumerable<Plant>> GetPlantsByTypeAsync(PlantType plantType);
    }
}
