using ModelsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1135AirportApi.db
{
    public partial class Airport
    {
        public static explicit operator AirportApi(Airport airport)
        {
            if (airport == null)
                return null;
            return new AirportApi
            {
                Id = airport.Id,
                Title = airport.Title,
                IdCity = airport.IdCity
                /*Airports =*/  // todo - не выводятся
            };
        }
        public static explicit operator Airport(AirportApi airportApi)
        {
            if (airportApi == null)
                return null;
            return new Airport
            {
                Id = airportApi.Id,
                Title = airportApi.Title,
                IdCity = airportApi.IdCity
            };
        }
    }
}
