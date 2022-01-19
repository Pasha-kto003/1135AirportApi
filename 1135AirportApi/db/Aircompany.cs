using System;
using System.Collections.Generic;

#nullable disable

namespace _1135AirportApi.db
{
    public partial class Aircompany
    {
        public Aircompany()
        {
            Transfers = new HashSet<Transfer>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Transfer> Transfers { get; set; }
    }
}
