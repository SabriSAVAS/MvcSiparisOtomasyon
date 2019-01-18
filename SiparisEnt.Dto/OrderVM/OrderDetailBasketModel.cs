using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Dto.OrderVM
{
    public class OrderDetailBasketModel : BaseModel
    {
        public OrderDetailBasketModel()
        {
            Quantity = 1;
            OrderDetail=new OrderDetail();
        }

        public OrderDetail OrderDetail { get; set; }
        public double Quantity { get; set; }
        public string ProductName { get; set; }
      

    }

    public class OrderDetailCart
    {
        public static OrderDetailCart ActiveOrder
        {
            get
            {
                HttpContext context = HttpContext.Current;
                if (context.Session["ActiveOrder"] == null)
                    context.Session["ActiveOrder"] = new OrderDetailCart();
                return (OrderDetailCart)context.Session["ActiveOrder"];
            }
        }
        private List<OrderDetailBasketModel> _stoklar = new List<OrderDetailBasketModel>();

        public List<OrderDetailBasketModel> _Items { get { return _stoklar; } }

        public void OrderAdd(OrderDetail item,string productName)
        {
            if (_stoklar.Any(x => x.OrderDetail.ProductId == item.ProductId))
            {
                //OrderDetailBasketModel pro = _stoklar.SingleOrDefault(x => x.ProductId == item.ProductId);
                //if (pro != null) pro.Quantity = item.Quantity;
            }
            else
            {
                _stoklar.Add(new OrderDetailBasketModel{OrderDetail = item,Quantity = 1,ProductName = productName});
            }
        }
        public OrderDetailBasketModel OrderUpdate(OrderDetail item)
        {
            if (_stoklar.Any(x => x.OrderDetail.ProductId == item.ProductId))
            {
                OrderDetailBasketModel pro = _stoklar.SingleOrDefault(x => x.OrderDetail.ProductId == item.ProductId);
                if (pro != null) pro.OrderDetail = item;
                return pro;
            }
            return null;
        }

        public void OrderRemove(OrderDetail item)
        {
          
            if (_stoklar.Any(x => x.OrderDetail.ProductId == item.ProductId))
            {
                OrderDetailBasketModel pro = _stoklar.SingleOrDefault(x => x.OrderDetail.ProductId == item.ProductId);
                _stoklar.Remove(pro);
            }

        }
        public void Clear()
        {

           _stoklar.Clear();
        }
    }
}

