using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SiparisEnt.Entities.Concrete;
using DateTime = System.DateTime;

namespace SiparisEnt.Dto.OrderVM
{
 
    public class OrderModel
    {
        public OrderModel()
        {
           
            DeliveryList = new List<SelectListItem>();
            ExchangeList = new List<SelectListItem>();    
            StatusList = new List<SelectListItem>();
            OrderDetailList = new List<OrderDetailBasketModel>();
            Order = new Order();
        }
        public Order Order { get; set; }
        public List<SelectListItem> StatusList { get; set; }
        public List<SelectListItem> ExchangeList { get; set; }
        public List<SelectListItem> DeliveryList { get; set; }
        public List<OrderDetailBasketModel> OrderDetailList { get; set; }
        public string CustomerName { get; set; }
    }
}

