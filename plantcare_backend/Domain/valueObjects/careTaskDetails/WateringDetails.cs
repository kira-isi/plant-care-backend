using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.valueObjects.careTaskDetails
{
    public class WateringDetails : ICareTaskDetails
    {
        public int AmountInMl { get; }

        public string Summary => $"{AmountInMl} ml";

        public WateringDetails(int amountInMl)
        {
        AmountInMl = amountInMl;
        }
    }
}
