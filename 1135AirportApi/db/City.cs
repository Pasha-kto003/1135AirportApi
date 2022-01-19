using System;
using System.Collections.Generic;

#nullable disable

namespace _1135AirportApi.db
{
    public partial class City
    {
        public City()
        {
            Airports = new HashSet<Airport>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? UtcAdd { get; set; }

        public virtual ICollection<Airport> Airports { get; set; }
    }
}
