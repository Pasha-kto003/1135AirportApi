using System;
using System.Collections.Generic;

#nullable disable

namespace _1135AirportApi.db
{
    public partial class Airport
    {
        public Airport()
        {
            TransferIdAirportEndNavigations = new HashSet<Transfer>();
            TransferIdAirportStartNavigations = new HashSet<Transfer>();
        }

        public int Id { get; set; }
        public int? IdCity { get; set; }
        public string Title { get; set; }

        public virtual City IdCityNavigation { get; set; }
        public virtual ICollection<Transfer> TransferIdAirportEndNavigations { get; set; }
        public virtual ICollection<Transfer> TransferIdAirportStartNavigations { get; set; }
    }
}
