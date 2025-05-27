using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.valueObjects.careTaskDetails
{
    internal class WateringDetails : ICareTaskDetails
    {
        public double AmountInMl { get; set; }

        public string Summary => $"{AmountInMl} ml";
    }
}
