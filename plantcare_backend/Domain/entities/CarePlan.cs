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

        public void AddTask(CareTask task)
		{
            TaskList.Add(task);	
		}

        public void RemoveTask(Guid taskId) 
		{ 
			TaskList.RemoveAll(t => t.Id == taskId);
        }

        public void ClearTaskList()
		{
            TaskList.Clear();
		}

        public void AddPlant(Plant plant) 
		{
			Plants.Add(plant.PlantID);
		}

        public void RemovePlant(Guid plantId) {
			Plants.Remove(plantId);
		}

        public void ClearPlants() {
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