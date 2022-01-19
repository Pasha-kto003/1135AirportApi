using System;
using System.Collections.Generic;

#nullable disable

namespace _1135AirportApi.db
{
    public partial class Tarif
    {
        public Tarif()
        {
            CrossTarifAddExpenses = new HashSet<CrossTarifAddExpense>();
            Transfers = new HashSet<Transfer>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<CrossTarifAddExpense> CrossTarifAddExpenses { get; set; }
        public virtual ICollection<Transfer> Transfers { get; set; }
    }
}
