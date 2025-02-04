using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plant_care._4_domain_code
{
    public class Fertilizing : RoutineAction
    {
        public String fertiliser {  get; }

        public Fertilizing(TimeSpan interval, String fertiliser) : base(interval)
        {
            this.fertiliser = fertiliser;
        }

        public override bool IsOverDue()
        {
            return lastPerformed.Add(interval).AddDays(7) <= DateTime.UtcNow;
        }

        public override void Execute()
        {
            base.Execute();
            // Düngung durchführen
        }
    }
}
