using ModelsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1135AirportApi.db
{
    public partial class Tarif
    {
        public static explicit operator TarifApi(Tarif type)
        {
            return new TarifApi { Id = type.Id, Title = type.Title };
        }

        public static explicit operator Tarif(TarifApi type)
        {
            return new Tarif { Id = type.Id, Title = type.Title};
        }
    }
}
