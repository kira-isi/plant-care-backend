using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plant_care._4_domain_code
{
    public class PlantType
    {
        public string name { get; }
        public float requiredWaterAmount { get; }
        public int dailyWateringTimes { get; }
        public bool needsDirectSunlight { get; }

        public PlantType(string name, float requiredWaterAmount, int dailyWateringTimes, bool needsDirectSunlight)
        {
            this.name = name;
            this.requiredWaterAmount = requiredWaterAmount;
            this.dailyWateringTimes = dailyWateringTimes;
            this.needsDirectSunlight = needsDirectSunlight;
        }
    }
}