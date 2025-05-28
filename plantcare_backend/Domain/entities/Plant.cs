using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.entities
{
    public class Plant
	{	
		public Guid PlantID {get;}
        public String Name { get;} //optional wird über location und type schon gut definiert
        public PlantType Type { get;}
        public Location Location { get; private set; }


		public Plant(PlantType type, Location location, String? name = null)
		{
			this.PlantID = Guid.NewGuid();
			this.Name = name;
			this.Type = type;
            this.Location = location;
		}

        public void Relocate(Location newLocation)
        {
            this.Location = newLocation;
        }
    }
}