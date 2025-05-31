using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapters.resources
{
    public class CarePlanResource
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public List<CareTaskResource> TaskList { get; set; }
        public List<Guid> Plants { get; set; }
    }
}