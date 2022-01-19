using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi
{
    public class TransferApi : ApiBaseType
    {
        public int? IdOrder { get; set; }
        public int? IdAirportStart { get; set; }
        public int? IdAirportEnd { get; set; }
        public DateTime? DateStartUtc { get; set; }
        public DateTime? DateEndUtc { get; set; }
        public string Sit { get; set; }
        public int? IdTarif { get; set; }
        public decimal? Cost { get; set; }
        public int? IdAirCompany { get; set; }
    }
}
