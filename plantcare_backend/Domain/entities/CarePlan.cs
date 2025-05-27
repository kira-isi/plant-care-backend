using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities
{
    public class CarePlan
	{
        public Guid id {get;}
        public String name {get; private set; }
        public List<CareTask> taskList {get; private set; }
        public List<Guid> plants {get; private set; }

        public CarePlan(String name)
		{
			this.id = Guid.NewGuid();
			this.name = name;
			this.taskList = new List<CareTask>();
			this.plants = new List<Guid>();
		}

        public void addTask(CareTask task)
		{
            taskList.Add(task);	
		}

        public Boolean removeTask(CareTask task) 
		{ 
			return taskList.Remove(task);
		}

        public void clearTaskList()
		{
            taskList.Clear();
		}

        public void addPlant(Plant plant) 
		{
			plants.Add(plant.PlantID);
		}

        public void removePlant(Plant plant) {
			plants.Remove(plant.PlantID);
		}

        public void clearPlants() {
			plants.Clear();
		}

        public List<CareTask> GetDueActions()
        {
            List<CareTask> actionsDue = new List<CareTask>();
			foreach (CareTask task in this.taskList)
			{
				if (task.IsDue())
				{
					actionsDue.Add(task);
				}
			}

            return actionsDue;
        }

        public List<CareTask> GetOverdueActions()
        {
            List<CareTask> actionsOverdue = new List<CareTask>();
            foreach (CareTask task in this.taskList)
            {
                if (task.IsOverdue())
                {
                    actionsOverdue.Add(task);
                }
            }

            return actionsOverdue;
        }
    }
}