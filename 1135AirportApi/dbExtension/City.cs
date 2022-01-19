using ModelsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1135AirportApi.db
{
    public partial class City
    {
        public static explicit operator CityApi(City city)
        {
            if (city == null)
                return null;
            return new CityApi
            {
                Id = city.Id,
                Title = city.Title,
                UtcAdd = city.UtcAdd,
                /*Airports =*/  // todo - не выводятся
            };
        }
        public static explicit operator City(CityApi city)
        {
            if (city == null)
                return null;
            return new City
            {
                Id = city.Id,
                Title = city.Title,
                UtcAdd = city.UtcAdd
                
            };
        }
    }
}
