using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisEnt.Entities.Concrete
{
   public class Order:EntityBase
    {
        public Order()
        {
            PayMethod = "PEŞIN";
            OrderNo = 0;
            StatusId = 1;
            OrderSeries = "SP";
            ExchangeRate = 1;
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            IsDelete = false;
            OrderDate = DateTime.Now;
            DeliveryDate = DateTime.Now;
        }
        public int UserId { get; set; }

        public int CustomerId { get; set; }

        public string CustomerAuthorized { get; set; }

        public int StatusId { get; set; }

        public int ExchangeId { get; set; }

        public decimal ExchangeRate { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public int DeliveryId { get; set; }
     
        public string PayMethod { get; set; }

        public string OrderSeries { get; set; }

        public int OrderNo { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public bool IsDelete { get; set; }
    }
}
