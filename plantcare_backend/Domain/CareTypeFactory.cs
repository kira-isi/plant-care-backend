using Domain.valueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class CareTypeFactory
    {
        public static CareType FromString(string typeName)
        {
            return typeName switch
            {
                "Watering" => new Watering(),
                "Fertilizing" => new Fertilizing(),
                "Repotting" => new Repotting(),
                "Pruning" => new Pruning(),
                _ => throw new ArgumentException($"Unknown care type: {typeName}")
            };
        }
    }
}
