using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.valueObjects.careTaskDetails
{
    public class FertilizingDetails : ICareTaskDetails
    {
        public string FertilizerName { get; set; }
        public string Dosage { get; set; } //freitext weil für den Nutzer angenehm z.B. eine Kappe, zwei Löffel

        public string Summary => $"{FertilizerName} – {Dosage}";

        public FertilizingDetails(string fertilizerName, string dosage)
        {
            FertilizerName = fertilizerName;
            Dosage = dosage;
        }
    }
}
