using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Core.DataAccess.EntityFramework;
using SiparisEnt.DataAccess.Abstarct;
using SiparisEnt.Entities.Concrete;
using SiparisEnt.Entities.ContextTypes;

namespace SiparisEnt.DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, SipEntegrasyonContext>, IOrderDal
    {
        public List<OrderDetailItem> GetOrderDetailItems(int takelist = 200)
        {
            using (SipEntegrasyonContext db = new SipEntegrasyonContext())
            {
                var orders = db.Orders.Where(x => x.IsDelete == false).OrderByDescending(x => x.Id).Take(takelist);
                List<OrderDetailItem> orderDetailItems = new List<OrderDetailItem>();

                foreach (var dbOrder in orders)
                {
                    OrderDetailItem item = new OrderDetailItem();
                    var customer = db.Customers.FirstOrDefault(x => x.Id == dbOrder.CustomerId);
                    var staut = db.Status.FirstOrDefault(x => x.Id == dbOrder.StatusId);
                    item.Id = dbOrder.Id;

                    item.UserId = dbOrder.UserId;
                    item.DeliveryId = dbOrder.DeliveryId;
                    item.CustomerId = dbOrder.CustomerId;
                    item.ExchangeId = dbOrder.ExchangeId;
                    item.StatusId = dbOrder.StatusId;
                    item.CreateDate = dbOrder.CreateDate;
                    item.CustomerAuthorized = dbOrder.CustomerAuthorized;
                    if (customer != null)
                    {
                        item.CustomerName = customer.Name;
                        item.CustomerPhone = customer.Phone;
                        item.CityName = db.Cities.FirstOrDefault(x => x.Id == customer.CityId)?.Name;
                    }

                    item.DeliveryDate = dbOrder.DeliveryDate;
                    item.DeliveryName = db.Deliveries.FirstOrDefault(x => x.Id == dbOrder.DeliveryId)?.Name;
                    item.ExchangeName = db.Excs.FirstOrDefault(x => x.Id == dbOrder.ExchangeId)?.Name;
                    item.ExchangeRate = dbOrder.ExchangeRate;
                    item.IsDelete = dbOrder.IsDelete;
                    item.OrderDate = dbOrder.OrderDate;
                    item.OrderNo = dbOrder.OrderNo;
                    item.OrderSeries = dbOrder.OrderSeries;
                    item.OrderNoSeries = Convert.ToString(dbOrder.OrderSeries) + ' ' + dbOrder.OrderNo;
                    item.PayMethod = dbOrder.PayMethod;
                    if (staut != null) item.StatusName = staut.Name;
                    item.UpdateDate = dbOrder.UpdateDate;
                    item.UserName = db.Users.FirstOrDefault(x => x.Id == dbOrder.UserId)?.FirstName + " " +
                                    db.Users.FirstOrDefault(x => x.Id == dbOrder.UserId)?.LastName;
                    item.OrderTotal =
                     ItemOrderTotal(db, dbOrder);

                    orderDetailItems.Add(item);
                }

                return orderDetailItems.Where(x => x.IsDelete == false).OrderByDescending(x => x.Id).Take(takelist).ToList();
            }
        }

        private static decimal ItemOrderTotal(SipEntegrasyonContext db, Order dbOrder)
        {
            try
            {
                return db.OrderDetails.Where(x => x.OrderId == dbOrder.Id).Sum(x => ((x.Total - x.DisCountTotal) * x.Tax / 100) + (x.Total - x.DisCountTotal));
            }
            catch
            {
                return 0;
            }

        }

        public int GetOrderSira(string orderseri)
        {
            using (SipEntegrasyonContext db = new SipEntegrasyonContext())
            {
                var result = db.Orders.OrderByDescending(x => x.Id).FirstOrDefault(x => x.OrderSeries == orderseri);
                if (result == null)
                {
                    return 1;

                }
                else if (result.OrderNo == 0)
                {
                    return 1;
                }

                return result.OrderNo + 1;
            }
        }

        public bool OrderIsCustomerControl(int customerId)
        {
            using (SipEntegrasyonContext db = new SipEntegrasyonContext())
            {
                var result = db.Orders.Any(x => x.CustomerId == customerId);

                return result;
            }
        }

        public decimal GetCompletedOrderTotal()
        {
            using (SipEntegrasyonContext context = new SipEntegrasyonContext())
            {
                var orders = (from order in context.Orders
                              join orderdetail in context.OrderDetails
                                  on order.Id equals orderdetail.OrderId
                              where order.StatusId == 10 && order.IsDelete == false
                             
                              select new
                              {
                                 ordertotal=orderdetail.Total,
                                 taxtotal=orderdetail.Tax1Total + orderdetail.Tax2Total + orderdetail.Tax3Total+ orderdetail.Tax4Total
                              }).ToList();

                return orders.Sum(x => x.ordertotal + x.taxtotal);
                //group orderdetail by orderdetail.OrderId into g
            }
        }
    }
}
//var result = from dbOrder in db.Orders
//             join dbUser in db.Users on dbOrder.UserId equals dbUser.Id
//             join dbCustomer in db.Customers on dbOrder.CustomerId equals dbCustomer.Id
//             join dbStatuse in db.Status on dbOrder.StatusId equals dbStatuse.Id
//             join dbExc in db.Excs on dbOrder.ExchangeId equals dbExc.Id
//             join dbDelivery in db.Deliveries on dbOrder.DeliveryId equals dbDelivery.Id
//             //join dbOrderDetail in db.OrderDetails on dbOrder.Id equals dbOrderDetail.OrderId 
//             where dbOrder.IsDelete == false
//             select new OrderDetailItem
//             {
//                 Id = dbOrder.Id,
//                 UserId = dbOrder.UserId,
//                 DeliveryId = dbOrder.DeliveryId,
//                 CustomerId = dbOrder.CustomerId,
//                 ExchangeId = dbOrder.ExchangeId,
//                 StatusId = dbOrder.StatusId,
//                 CreateDate = dbOrder.CreateDate,
//                 CustomerAuthorized = dbOrder.CustomerAuthorized,
//                 CustomerName = dbCustomer.Name,
//                 CustomerPhone = dbCustomer.Phone,
//                 CityName = db.Cities.FirstOrDefault(x => x.Id == dbCustomer.CityId).Name,
//                 DeliveryDate = dbOrder.DeliveryDate,
//                 DeliveryName = dbDelivery.Name,
//                 ExchangeName = dbExc.Name,
//                 ExchangeRate = dbOrder.ExchangeRate,
//                 IsDelete = dbOrder.IsDelete,
//                 OrderDate = dbOrder.OrderDate,
//                 OrderNo = dbOrder.OrderNo,
//                 OrderSeries = dbOrder.OrderSeries,
//                 PayMethod = dbOrder.PayMethod,
//                 StatusName = dbStatuse.Name,
//                 UpdateDate = dbOrder.UpdateDate,
//                 UserName = dbUser.FirstName + " " + dbUser.LastName,
//                 OrderTotal = db.OrderDetails.Where(x => x.OrderId == dbOrder.Id).Sum(x => x.Total)
//             };