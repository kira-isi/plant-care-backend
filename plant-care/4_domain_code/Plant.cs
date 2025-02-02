using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace plant_care._4_domain_code
{
    public class Plant
	{	
		public Guid plantID {get;}
        public String name { get;} //optional wird über location und type schon gut definiert
        public PlantType type { get;}
        public Location location { get; private set; }
        public float requiredWaterAmount { get; private set; }
        public int dailyWateringTimes { get; private set; }
        public Boolean needsDirectSunlight { get; }
        public Boolean keepOutside { get;}

		public Plant(PlantType type, Location location, float requiredWaterAmount, int dailyWateringTimes, bool needsDirectSunlight, bool keepOutside, String? name = null)
		{
			this.plantID = Guid.NewGuid();
			this.name = name;
			this.type = type;
			this.requiredWaterAmount = requiredWaterAmount;
			this.dailyWateringTimes = dailyWateringTimes;
			this.needsDirectSunlight = needsDirectSunlight;
			this.keepOutside = keepOutside;
		}

        public void Relocate(Location newLocation)
        {
            this.location = newLocation;
        }
    }
}