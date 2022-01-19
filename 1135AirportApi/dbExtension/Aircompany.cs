using ModelsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1135AirportApi.db
{
    public partial class Aircompany
    {
        public static explicit operator AircompanyApi(Aircompany company)
        {
            return new AircompanyApi { Id = company.Id, Title = company.Title };
        }

        public static explicit operator Aircompany(AircompanyApi company)
        {
            return new Aircompany { Id = company.Id, Title = company.Title };
        }
    }
}
