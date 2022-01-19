using System;
using System.Collections.Generic;

#nullable disable

namespace _1135AirportApi.db
{
    public partial class CrossTarifAddExpense
    {
        public int Id { get; set; }
        public int? IdTarif { get; set; }
        public int? IdTypeExpense { get; set; }

        public virtual Tarif IdTarifNavigation { get; set; }
        public virtual AddExpenseType IdTypeExpenseNavigation { get; set; }
    }
}
