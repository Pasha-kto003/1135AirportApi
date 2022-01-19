using ModelsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1135AirportApi.db
{
    public partial class AddExpenseType
    {
        public static explicit operator AddExpenseTypeApi(AddExpenseType type)
        {
            return new AddExpenseTypeApi { Id = type.Id, Title = type.Title, AddCost = type.AddCost };
        }

        public static explicit operator AddExpenseType(AddExpenseTypeApi type)
        {
            return new AddExpenseType { Id = type.Id, Title = type.Title, AddCost = type.AddCost };
        }
    }
}
