using System;
using System.Collections.Generic;

#nullable disable

namespace _1135AirportApi.db
{
    public partial class AddExpenseType
    {
        public AddExpenseType()
        {
            CrossAddExpenses = new HashSet<CrossAddExpense>();
            CrossTarifAddExpenses = new HashSet<CrossTarifAddExpense>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public decimal? AddCost { get; set; }

        public virtual ICollection<CrossAddExpense> CrossAddExpenses { get; set; }
        public virtual ICollection<CrossTarifAddExpense> CrossTarifAddExpenses { get; set; }
    }
}
