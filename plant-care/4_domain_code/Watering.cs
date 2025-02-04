using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plant_care._4_domain_code
{
    public class Watering : RoutineAction
    {
        public Watering(TimeSpan interval) : base(interval) { }

        public override bool IsOverDue()
        {
            return lastPerformed.Add(interval).AddDays(1) <= DateTime.UtcNow;
        }

        public override void Execute()
        {
            base.Execute();
            // Bewässerung durchführen
        }
    }
}
