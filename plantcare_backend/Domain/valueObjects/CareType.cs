using Domain.valueObjects.careTaskDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.valueObjects
{
    public abstract class CareType
    {
       public abstract bool Matches(ICareTaskDetails detail);
    }

    public class Watering : CareType
    {
		public override bool Matches(ICareTaskDetails detail)
		{
			return detail is WateringDetails;
		}
	}

    public class Fertilizing : CareType
    {
		public override bool Matches(ICareTaskDetails detail)
		{
			return detail is FertilizingDetails;
		}
	}

    public class Repotting : CareType {
		public override bool Matches(ICareTaskDetails detail)
		{
			return detail is DummyDetails;
		}
	}
    public class Pruning : CareType {
		public override bool Matches(ICareTaskDetails detail)
		{
			return detail is DummyDetails;
		}
	}

}
