using Domain.valueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities
{
    public class RecurringCareTask : CareTask
    {
        public TimeSpan Interval { get; init; }
        public DateTime LastPerformed { get; private set; }

        public RecurringCareTask(CareType type, ICareTaskDetails details, TimeSpan interval)
            : base(type, details)
        {
            Interval = interval;
            LastPerformed = DateTime.Today;
        }

        public override bool IsDue()
        {
            DateTime now = DateTime.Now;
            var dueDate = LastPerformed + Interval - TimeSpan.FromDays(1);
            return now.Date >= dueDate.Date && now.Date < (LastPerformed + Interval).Date;
        }

        public override bool IsOverdue()
        {
            DateTime now = DateTime.Now;
            var overdueDate = LastPerformed + Interval;
            return now.Date >= overdueDate.Date;
        }

        public override void MarkAsPerformed()
        {
            LastPerformed = DateTime.Today;
        }
    }
}
