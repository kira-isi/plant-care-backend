using Application.repositoryInterfaces;
using Domain;
using Domain.entities;
using Domain.valueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecases.carePlanManagement
{
    public class AddTaskToCarePlan
    {
        private readonly ICarePlanRepository _carePlanRepository;

        public AddTaskToCarePlan(ICarePlanRepository carePlanRepository)
        {
            _carePlanRepository = carePlanRepository;
        }

        public async Task<bool> Execute(
            Guid carePlanId,
            CareType type,
            ICareTaskDetails details,
            DateTime? scheduledDate = null,
            TimeSpan? interval = null)
        {
            var carePlan = await _carePlanRepository.GetByIdAsync(carePlanId);
            if (carePlan == null) return false;

            CareTask newTask;

            if (scheduledDate != null)
            {
                newTask = CareTaskFactory.CreateScheduled(type, details, scheduledDate.Value);
            }
            else if (interval != null)
            {
                newTask = CareTaskFactory.CreateRecurring(type, details, interval.Value);
            }
            else
            {
                // Keine gültigen Planungsdaten → Fehler
                return false;
            }

            carePlan.AddTask(newTask);
            await _carePlanRepository.UpdateAsync(carePlan);
            return true;
        }
    }

}
