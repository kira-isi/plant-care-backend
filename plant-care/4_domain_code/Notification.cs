using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plant_care._4_domain_code
{
	internal class Notification
	{
		private String message {get;set;}
		private DateTime sendTime {get;set;}

		public Notification(string message)
		{
			this.message = message;
		}
	}
}
