using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.valueObjects
{
    public class Location : IEquatable<Location>
    {
        public string Name { get; }
        public string Description { get; }

        public Location(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public bool Equals(Location? other)
        {
            if (other is null) return false;
            return Name == other.Name && Description == other.Description;
        }

        public override bool Equals(object? obj) => Equals(obj as Location);

        //wenn Equals dann auch GetHashCode
        public override int GetHashCode() => HashCode.Combine(Name, Description);
    }

}
