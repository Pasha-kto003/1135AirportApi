using ModelsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1135AirportApi.db
{
    public partial class Transfer
    {
        public static explicit operator TransferApi(Transfer type)
        {
            return new TransferApi { Id = type.Id, Cost = type.Cost, DateEndUtc = type.DateEndUtc, DateStartUtc = type.DateStartUtc, IdAirCompany = type.IdAirCompany,  IdAirportEnd = type.IdAirportEnd,  IdAirportStart = type.IdAirportStart, IdOrder = type.IdOrder,  IdTarif = type.IdTarif, Sit = type.Sit };
        }

        public static explicit operator Transfer(TransferApi type)
        {
            return new Transfer { Id = type.Id, Cost = type.Cost, DateEndUtc = type.DateEndUtc, DateStartUtc = type.DateStartUtc, IdAirCompany = type.IdAirCompany, IdAirportEnd = type.IdAirportEnd, IdAirportStart = type.IdAirportStart, IdOrder = type.IdOrder, IdTarif = type.IdTarif, Sit = type.Sit };
        }
    }
}
