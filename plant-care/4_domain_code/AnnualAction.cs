using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plant_care._4_domain_code
{
    public abstract class AnnualAction : Action
    {
        public DateTime dueDate { get; private set; }

        protected AnnualAction(DateTime dueDate)
        {
            this.dueDate = dueDate;
        }

        public bool IsDue()
        {
            return DateTime.UtcNow >= dueDate;
        }

        //zu addierende Zeit verändert such je nach spezifischer Aktion
        public abstract bool IsOverDue();

        //enthält Anpassung des dueDate und zusätzliche spezifische Funktionen
        public abstract void Execute();
    }
}
