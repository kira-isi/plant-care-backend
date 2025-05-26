using Domain.valueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities
{
    public class ScheduledCareTask : CareTask
    {
        public DateTime ScheduledDate { get; init; }
        public bool IsCompleted { get; private set; }

        public ScheduledCareTask(CareType type, ICareTaskDetails details, DateTime scheduledDate)
            : base(type, details)
        {
            ScheduledDate = scheduledDate;
        }

        public override bool IsDue()
        {
            return !IsCompleted && DateTime.Today == ScheduledDate.Date;
        }

        public override bool IsOverdue()
        {
            return !IsCompleted && DateTime.Today > ScheduledDate.Date;
        }


        public override void MarkAsPerformed()
        {
            IsCompleted = true;
        }
    }
}
