using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapters.resources
{
    public class PlantTypeResource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int RequiredWaterAmountMl { get; set; }
        public int WeeklyWateringTimes { get; set; }
        public bool NeedsDirectSunlight { get; set; }
    }
}