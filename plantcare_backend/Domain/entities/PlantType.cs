using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities
{
    public class PlantType
    {
        public Guid Id { get; }
        public string Name { get; }
        public int RequiredWaterAmountMl { get; }
        public int WeeklyWateringTimes { get; }
        public bool NeedsDirectSunlight { get; }

        public PlantType(Guid Id, string name, int requiredWaterAmountMl, int weeklyWateringTimes, bool needsDirectSunlight)
        {
            this.Id = Id;
            this.Name = name;
            this.RequiredWaterAmountMl = requiredWaterAmountMl;
            this.WeeklyWateringTimes = weeklyWateringTimes;
            this.NeedsDirectSunlight = needsDirectSunlight;
        }
    }
}