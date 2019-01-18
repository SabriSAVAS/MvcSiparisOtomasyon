using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Entities.ContextTypes;

namespace SiparisEnt.Dto.DashboardVM
{
    public class DashboardViewModel
    {
        public DashboardViewModel()
        {
            OrderDetailItems=new List<OrderDetailItem>();
        }
        public int NewPaddingOrder { get; set; }
        public int CompletedOrder { get; set; }
        public int PreparedOrder { get; set; }
        public int OrdersShipped { get; set; }

        public List<OrderDetailItem> OrderDetailItems { get; set; }
        public decimal CompletedOrderTotal { get; set; }
    }
}
