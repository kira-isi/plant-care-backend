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
			return detail is Watering;
		}
	}

    public class Fertilizing : CareType
    {
		public override bool Matches(ICareTaskDetails detail)
		{
			return detail is Fertilizing;
		}
	}

    public class Repotting : CareType {
		public override bool Matches(ICareTaskDetails detail)
		{
			return detail is Repotting;
		}
	}
    public class Pruning : CareType {
		public override bool Matches(ICareTaskDetails detail)
		{
			return detail is Pruning;
		}
	}

}
