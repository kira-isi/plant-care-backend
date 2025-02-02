using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plant_care._4_domain_code
{
    public class Location
    {
        public string description { get; }

        public Location(string description)
        {
            this.description = description;
        }
    }
}
