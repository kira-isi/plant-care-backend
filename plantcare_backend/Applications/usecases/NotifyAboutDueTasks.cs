using Application.repositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecases
{
    public class NotifyAboutDueTasks
    {
        private readonly ICarePlanRepository _carePlanRepository;
        private readonly INotificationService _notificationService;

        public NotifyAboutDueTasks(ICarePlanRepository carePlanRepository, INotificationService notificationService)
        {
            _carePlanRepository = carePlanRepository;
            _notificationService = notificationService;
        }

        public async Task ExecuteAsync()
        {
            var allCarePlans = await _carePlanRepository.GetAllAsync();
            string message = "";

            foreach (var plan in allCarePlans)
            {
                var due = plan.GetDueActions();
                var overdue = plan.GetOverdueActions();

                if (!due.Any() && !overdue.Any())
                    continue;

                message += $"Pflegeplan „{plan.Name}“ hat {due.Count} fällige Aufgabe(n) und {overdue.Count} überfällige Aufgabe(n).";
            }
            await _notificationService.SendNotificationToAllAsync("Heutiger Planzen-Bericht", message);
        }
    }
}