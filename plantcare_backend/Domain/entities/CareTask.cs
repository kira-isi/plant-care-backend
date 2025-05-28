using Domain.valueObjects;
using Domain.valueObjects.careTaskDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities
{
    public abstract class CareTask
    {
        public Guid Id { get; set; }
        public CareType Type { get; }
        public ICareTaskDetails Details { get; }

        public CareTask(CareType type, ICareTaskDetails details)
        {
            if (type.Matches(details))
                throw new ArgumentException($"Invalid details type for care type {type.ToString()}");

            Type = type;
            Details = details;
        }

        public abstract bool IsDue();
        public abstract bool IsOverdue();

        public abstract void MarkAsPerformed();

        //obsolete durch polymorphieanpassung in CareType
        //public static bool MatchesDetailsType(CareType type, ICareTaskDetails details)
        //{
        //    return type switch
        //    {
        //        CareType.Watering => details is WateringDetails,
        //        CareType.Fertilizing => details is FertilizingDetails,
        //        CareType.Repotting => true, // falls keine Details nötig
        //        CareType.Pruning => true,
        //        _ => false
        //    };
        //}
    }
}
