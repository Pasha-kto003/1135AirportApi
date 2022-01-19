using ModelsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1135AirportApi.db
{
    public partial class Order
    {
        public static explicit operator OrderApi(Order type)
        {
            return new OrderApi { Id = type.Id, IdClient = type.IdClient,  DateBuy = type.DateBuy, Status = type.Status };
        }

        public static explicit operator Order(OrderApi type)
        {
            return new Order { Id = type.Id, IdClient = type.IdClient, DateBuy = type.DateBuy, Status = type.Status };
        }
    }
}
