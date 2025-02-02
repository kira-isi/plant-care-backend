using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plant_care._4_domain_code
{
    public class PestControl : RoutineAction
    {
        public PestControl(TimeSpan interval) : base(interval) { }

        public override bool IsOverDue()
        {
            return lastPerformed.Add(interval).AddDays(14) <= DateTime.UtcNow;
        }

        public override void Execute()
        {
            base.Execute();
            // Bewässerung durchführen
        }
    }
}