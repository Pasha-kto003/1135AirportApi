using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi
{
    public class OrderApi : ApiBaseType
    {
        public int? IdClient { get; set; }
        public DateTime? DateBuy { get; set; }
        public int? Status { get; set; }

        public List<TransferApi> Transfers { get; set; }
    }
}
