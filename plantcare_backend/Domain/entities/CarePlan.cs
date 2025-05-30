using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities
{
    public class CarePlan
	{
        public Guid Id {get;}
        public String Name {get; private set; }
        public List<CareTask> TaskList {get; private set; }
        public List<Guid> Plants {get; private set; }

        public CarePlan(String name)
		{
			this.Id = Guid.NewGuid();
			this.Name = name;
			this.TaskList = new List<CareTask>();
			this.Plants = new List<Guid>();
		}

        public CarePlan(Guid id, String name, List<CareTask> taskList, List<Guid> plants)
        {
            this.Id = id;
            this.Name = name;
            this.TaskList = taskList;
            this.Plants = plants;
        }

        public void addTask(CareTask task)
		{
            TaskList.Add(task);	
		}

        public void removeTask(Guid taskId) 
		{ 
			TaskList.RemoveAll(t => t.Id == taskId);
        }

        public void clearTaskList()
		{
            TaskList.Clear();
		}

        public void addPlant(Plant plant) 
		{
			Plants.Add(plant.Id);
		}

        public void removePlant(Guid plantId) {
			Plants.Remove(plantId);
		}

        public void clearPlants() {
			Plants.Clear();
		}

        public List<CareTask> GetDueActions()
        {
            List<CareTask> actionsDue = new List<CareTask>();
			foreach (CareTask task in this.TaskList)
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
            foreach (CareTask task in this.TaskList)
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