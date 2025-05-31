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

        public PlantType(string name, int requiredWaterAmountMl, int weeklyWateringTimes, bool needsDirectSunlight)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.RequiredWaterAmountMl = requiredWaterAmountMl;
            this.WeeklyWateringTimes = weeklyWateringTimes;
            this.NeedsDirectSunlight = needsDirectSunlight;
        }

        public PlantType(Guid Id, string name, int requiredWaterAmountMl, int weeklyWateringTimes, bool needsDirectSunlight)
        {
            this.Id = Id;
            this.Name = name;
            this.RequiredWaterAmountMl = requiredWaterAmountMl;
            this.WeeklyWateringTimes = weeklyWateringTimes;
            this.NeedsDirectSunlight = needsDirectSunlight;
        }

        public PlantType(string Id, string name, long requiredWaterAmountMl, long weeklyWateringTimes, long needsDirectSunlight)
        {
            this.Id = Guid.Parse(Id);
            this.Name = name;
            this.RequiredWaterAmountMl = (int) requiredWaterAmountMl;
            this.WeeklyWateringTimes = (int) weeklyWateringTimes;
            this.NeedsDirectSunlight = needsDirectSunlight != 0;
        }
    }
}