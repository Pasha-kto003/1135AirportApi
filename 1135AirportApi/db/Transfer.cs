using System;
using System.Collections.Generic;

#nullable disable

namespace _1135AirportApi.db
{
    public partial class Transfer
    {
        public Transfer()
        {
            CrossAddExpenses = new HashSet<CrossAddExpense>();
        }

        public int Id { get; set; }
        public int? IdOrder { get; set; }
        public int? IdAirportStart { get; set; }
        public int? IdAirportEnd { get; set; }
        public DateTime? DateStartUtc { get; set; }
        public DateTime? DateEndUtc { get; set; }
        public string Sit { get; set; }
        public int? IdTarif { get; set; }
        public decimal? Cost { get; set; }
        public int? IdAirCompany { get; set; }

        public virtual Aircompany IdAirCompanyNavigation { get; set; }
        public virtual Airport IdAirportEndNavigation { get; set; }
        public virtual Airport IdAirportStartNavigation { get; set; }
        public virtual Order IdOrderNavigation { get; set; }
        public virtual Tarif IdTarifNavigation { get; set; }
        public virtual ICollection<CrossAddExpense> CrossAddExpenses { get; set; }
    }
}
