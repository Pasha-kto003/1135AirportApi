using System;
using System.Collections.Generic;

#nullable disable

namespace _1135AirportApi.db
{
    public partial class CrossAddExpense
    {
        public int Id { get; set; }
        public int? IdTransfer { get; set; }
        public int? IdTypeExpense { get; set; }

        public virtual Transfer IdTransferNavigation { get; set; }
        public virtual AddExpenseType IdTypeExpenseNavigation { get; set; }
    }
}
