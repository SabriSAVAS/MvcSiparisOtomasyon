using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace SiparisEnt.Dto.OrderVM
{
   public class OrderDetailItemModel:BaseModel
    {
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CityName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerAuthorized { get; set; }
        public string StatusName { get; set; }
        public int StatusId { get; set; }
        public string ExchangeName { get; set; }
        public int ExchangeId { get; set; }
        public decimal ExchangeRate { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryName { get; set; }
        public int DeliveryId { get; set; }
        public string PayMethod { get; set; }
        public string OrderSeries { get; set; }
        public int OrderNo { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsDelete { get; set; }
        public decimal OrderTotal { get; set; }
    }
}
