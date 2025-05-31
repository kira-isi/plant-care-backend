using Adapters.resources;
using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapters.mapper
{
    public static class LocationMapper
    {
        public static LocationResource ToResource(Location loc) => new()
        {
            Id = loc.Id,
            Name = loc.Name,
            Description = loc.Description
        };

        public static Location FromResource(LocationResource dto) =>
            new(dto.Id, dto.Name, dto.Description);
    }

}
