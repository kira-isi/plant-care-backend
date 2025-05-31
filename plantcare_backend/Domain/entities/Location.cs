using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entities
{
    public class Location
    {
        public Guid Id { get; }
        public string Name { get; }
        public string? Description { get; }

        public Location(string name, string? description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
        }

        public Location(Guid id, string name, string? description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Location(string id, string name, string? description)
        {
            Id = Guid.Parse(id);
            Name = name;
            Description = description;
        }
    }

}
