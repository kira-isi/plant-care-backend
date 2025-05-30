using Adapters.resources;
using Domain.entities;
using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Adapters.mapper
{
    public static class PlantMapper
    {
        public static PlantResource ToResource(Plant plant) => new()
        {
            Id = plant.Id,
            Name = plant.Name,
            PlantTypeId = plant.PlantTypeId,
            LocationId = plant.LocationId
        };

        public static Plant FromResource(PlantResource dto) =>
            new Plant(dto.Id, dto.PlantTypeId, dto.LocationId, dto.Name);
    }
}