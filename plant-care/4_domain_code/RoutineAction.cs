using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace plant_care._4_domain_code
{
    public abstract class RoutineAction : Action
    {
        public TimeSpan interval { get; }
        public DateTime lastPerformed { get; private set; }

        protected RoutineAction(TimeSpan interval)
        {
            this.interval = interval;
            lastPerformed = DateTime.MinValue; // Noch nie ausgeführt
        }

        public override bool IsDue()
        {
            return lastPerformed.Add(interval)  <= DateTime.UtcNow;
        }

        //zu addierende Zeit verändert such je nach spezifischer Aktion
        public override abstract bool IsOverDue();

        public override void Execute()
        {
            lastPerformed = DateTime.UtcNow;
        }
    }
}
