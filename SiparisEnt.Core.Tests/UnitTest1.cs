using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiparisEnt.DataAccess.Concrete.EntityFramework;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Core.Tests
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void GetAllProcut()
        {

            //EfProductDal productDal = new EfProductDal();
            //EfCustomerDal customerDal = new EfCustomerDal();

          
                for (int z = 0; z < 9995000; z++)
                {


                    EfOrderDal orderDal = new EfOrderDal();

                    Order order = new Order();
                    order.StatusId = GetStatu();
                    order.CustomerId = GetCustomer();
                    order.OrderDate = DateTime.Now;
                    order.CustomerAuthorized = "SABRİ";
                    order.DeliveryDate = DateTime.Now;
                    order.DeliveryId = GetDelivery();
                    order.ExchangeId = 1;
                    order.ExchangeRate = 0;
                    order.PayMethod = "PEŞİN";
                    order.OrderSeries = "SP";
                    order.OrderNo = orderDal.GetOrderSira("SP");
                    order.CreateDate = DateTime.Now;
                    order.UpdateDate = DateTime.Now;

                    order.UserId = 2;
                    order.IsDelete = false;
                    var result = orderDal.Add(order);
                    if (result != null)
                    {
                        Random random = new Random();
                        var randomcount = random.Next(1, 6);
                        for (int i = 0; i < randomcount; i++)
                        {
                            EfOrderDetailDal detailDal = new EfOrderDetailDal();
                            OrderDetail orderDetail = new OrderDetail();
                            orderDetail.OrderId = order.Id;
                            orderDetail.Description = "";
                            orderDetail.DisCountTotal = 0;
                            orderDetail.Discount = 0;
                            orderDetail.ProductId = GetProduct();
                            orderDetail.RowNo = 0;
                            orderDetail.Quantity = 1;
                            orderDetail.Tax = 18;
                            orderDetail.Tax4Total = 21;
                            orderDetail.Tax1Total = 0;
                            orderDetail.Tax2Total = 0;
                            orderDetail.Tax3Total = 0;
                            orderDetail.Unit = "ADET";
                            orderDetail.UserId = 2;
                            orderDetail.UnitPrice = 120;
                            orderDetail.Total = orderDetail.Tax4Total +
                                                ((decimal) orderDetail.Quantity * orderDetail.UnitPrice);
                            detailDal.Add(orderDetail);
                        }

                    }
                }
         
            
          
           
        }

        private int GetProduct()
        {
            try
            {
                EfProductDal productDal = new EfProductDal();
                var datas = productDal.GetList();
                Random rndRandom = new Random();
                return rndRandom.Next(41, datas.Count);
            }
            catch (Exception e)
            {
                return 70;
            }

           
        }

        private int GetDelivery()
        {
            try
            {
                EfDeliveryDal deliveryDal = new EfDeliveryDal();
                var datas = deliveryDal.GetList();
                Random rndRandom = new Random();
                return rndRandom.Next(1, datas.Count);
            }
            catch (Exception e)
            {
                return 3;
            }

            
        }

        private int GetCustomer()
        {
            try
            {
                EfCustomerDal customerDal = new EfCustomerDal();
                var datas = customerDal.GetList();
                Random rndRandom = new Random();
                return rndRandom.Next(18, datas.Count - 1);
            }
            catch (Exception e)
            {
                return 50;
            }
          
        }

        private int GetStatu()
        {
            try
            {
                EfStatusDal statusDal = new EfStatusDal();
                var datas = statusDal.GetList();
                Random rndRandom = new Random();
                return rndRandom.Next(1, datas.Count);
            }
            catch (Exception e)
            {
                return 2;
            }
          
        }
    }
}