using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plant_care._4_domain_code
{
	internal class Plant
	{	
		private Guid plantID {get; set;}
		private String name { get; set; }
		private String type { get; set; }
		private float requiredWaterAmount { get; set; }
		private int dailyWateringTimes { get; set; }
		private Boolean needsDirectSunlight { get; set; }
		private Boolean keepOutside { get; set; }

		public Plant(Guid plantID, string name, string type, float requiredWaterAmount, int dailyWateringTimes, bool needsDirectSunlight, bool keepOutside)
		{
			this.plantID = plantID;
			this.name = name;
			this.type = type;
			this.requiredWaterAmount = requiredWaterAmount;
			this.dailyWateringTimes = dailyWateringTimes;
			this.needsDirectSunlight = needsDirectSunlight;
			this.keepOutside = keepOutside;
		}

		
	}
}
