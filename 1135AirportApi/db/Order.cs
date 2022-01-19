using System;
using System.Collections.Generic;

#nullable disable

namespace _1135AirportApi.db
{
    public partial class Order
    {
        public Order()
        {
            Transfers = new HashSet<Transfer>();
        }

        public int Id { get; set; }
        public int? IdClient { get; set; }
        public DateTime? DateBuy { get; set; }
        public int? Status { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual ICollection<Transfer> Transfers { get; set; }
    }
}
