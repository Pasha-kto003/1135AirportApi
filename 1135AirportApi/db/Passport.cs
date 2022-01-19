using System;
using System.Collections.Generic;

#nullable disable

namespace _1135AirportApi.db
{
    public partial class Passport
    {
        public Passport()
        {
            Clients = new HashSet<Client>();
        }

        public int Id { get; set; }
        public string Seria { get; set; }
        public string Nomer { get; set; }
        public DateTime? GainDate { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
