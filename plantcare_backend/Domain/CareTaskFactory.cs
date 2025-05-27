using Domain.entities;
using Domain.valueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class CareTaskFactory
    {
        public static CareTask CreateScheduled(CareType type, ICareTaskDetails details, DateTime date)
            => new ScheduledCareTask(type, details, date);

        public static CareTask CreateRecurring(CareType type, ICareTaskDetails details, TimeSpan interval)
            => new RecurringCareTask(type, details, interval);
    }

}
