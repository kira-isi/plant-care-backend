using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plant_care._4_domain_code
{ 
	internal abstract class Action
	{
		public String name { get; set; }
		public String description { get; set; }
		public Action(String name, String description) {
			this.name = name;	
			this.description = description;

		}
	}
}
