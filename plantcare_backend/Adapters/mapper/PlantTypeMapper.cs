using Adapters.resources;
using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapters.mapper
{
    public static class PlantTypeMapper
    {
        public static PlantTypeResource ToResource(PlantType type) => new()
        {
            Id = type.Id,
            Name = type.Name,
            RequiredWaterAmountMl = type.RequiredWaterAmountMl,
            WeeklyWateringTimes = type.WeeklyWateringTimes,
            NeedsDirectSunlight = type.NeedsDirectSunlight
        };

        public static PlantType FromResource(PlantTypeResource dto) =>
            new(dto.Id, dto.Name, dto.RequiredWaterAmountMl, dto.WeeklyWateringTimes, dto.NeedsDirectSunlight);
    }
}
