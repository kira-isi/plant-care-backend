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
		public Guid Id {get;}
        public String Name { get;} //optional wird über location und type schon gut definiert
        public Guid PlantTypeId { get;}
        public Guid LocationId { get; private set; }


		public Plant(Guid plantTypeId, Guid locationId, String? name = null)
		{
			this.Id = Guid.NewGuid();
			this.Name = name;
			this.PlantTypeId = plantTypeId;
            this.LocationId = locationId;
		}

        public Plant(Guid id, Guid plantTypeId, Guid locationId, String? name = null)
        {
            this.Id = id;
            this.Name = name;
            this.PlantTypeId = plantTypeId;
            this.LocationId = locationId;
        }

        public void Relocate(Guid newLocationId)
        {
            this.LocationId = newLocationId;
        }
    }
}