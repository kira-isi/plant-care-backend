using plant_care._4_domain_code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plant_care._4_domain_code
{
	internal class CarePlan
	{
		private Guid id {get; set;}
		private List<Action> actions {get; set;}
		//TODO: is plan for multiple plants or just one?
		//private List<Plant> plants {get; set;}
		private Plant plant {get; set;}
		private List<Notification>notifications {get; set;}	

		//public CarePlan(Guid id, List<Action> actions, List<Plant> plants)
		//{
		//	this.id = id;
		//	this.actions = actions;
		//	this.plants = plants;
		//}

		public CarePlan(Guid id, List<Action> actions, Plant plant)
		{
			this.id = id;
			this.actions = actions;
			this.plant = plant;
		}

		public void addAction(Action action)
		{	
			actions.Add(action);	
		}

		public Boolean removeAction(Action action) 
		{ 
			return actions.Remove(action);
		}

		public void clearActionList()
		{
			actions.Clear();
		}

		//public void addPlant(Plant plant) 
		//{
		//	plants.Add(plant);
		//}

		//public void removePlant(Plant plant) {
		//	plants.Remove(plant);
		//}
		//public void clearPlants() {
		//	plants.Clear();
		//}

		//TODO: reverse dependency injection for service to send from here?
		public void sendNotification(String message)
		{
			Notification notif = new Notification(message);
		}
	}
}
