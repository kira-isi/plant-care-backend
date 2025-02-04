using plant_care._4_domain_code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plant_care._4_domain_code
{
    public class CarePlan
	{
        public Guid id {get;}
        public String name {get; private set; }
        public List<Action> actions {get; private set; }
        public List<Plant> plants {get; private set; }
        public INotificationService notificationService {get; private set; }	

		public CarePlan(String name, INotificationService notificationService)
		{
			this.id = Guid.NewGuid();
			this.name = name;
			this.actions = new List<Action>();
			this.plants = new List<Plant>();
			this.notificationService = notificationService;
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

		public void addPlant(Plant plant) 
		{
			plants.Add(plant);
		}

		public void removePlant(Plant plant) {
			plants.Remove(plant);
		}

		public void clearPlants() {
			plants.Clear();
		}

        public void getDueActions()
        {
            List<Action> actionsDue = new List<Action>();
			foreach (Action action in this.actions)
			{
				if (action.IsDue())
				{
					actionsDue.Add(action);
				}
			}
        }

        public void getOverdueActions()
        {
            List<Action> actionsOverdue = new List<Action>();
            foreach (Action action in this.actions)
            {
                if (action.IsOverdue())
                {
                    actionsOverdue.Add(action);
                }
            }
        }
    }
}