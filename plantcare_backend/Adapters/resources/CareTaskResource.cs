using Domain.valueObjects;
using Domain.valueObjects.careTaskDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapters.resources
{
    public class CareTaskResource
    {
        public Guid Id { get; set; }
        public CareType Type { get; set; }

        // Details – nur eines von beiden wird verwendet:
        public WateringDetailsResource? WateringDetails { get; set; }
        public FertilizingDetailsResource? FertilizingDetails { get; set; }

        public DateTime? ScheduledDate { get; set; }
        public bool? IsCompleted { get; set; }

        public int? IntervalDays { get; set; }
        public DateTime? LastPerformed { get; set; }
    }
}
