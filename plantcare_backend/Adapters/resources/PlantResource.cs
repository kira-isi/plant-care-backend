using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Adapters.resources
{
    public class PlantResource
    {	
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid PlantTypeId { get; set; }
        public Guid LocationId { get; set; }
    }
}