using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecases.carePlanManagement
{
    public class CreateCarePlanCommand
{
    public string Name { get; set; }
    public List<Guid> PlantIds { get; set; } = new();
}
}
