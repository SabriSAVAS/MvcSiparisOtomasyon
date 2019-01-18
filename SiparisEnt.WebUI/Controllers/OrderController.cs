using AutoMapper;
using PagedList;
using SiparisEnt.Business.Abstract;
using SiparisEnt.Dto.OrderVM;
using SiparisEnt.Entities.Concrete;
using SiparisEnt.WebUI.Infrastructure.AccountHelpers;
using SiparisEnt.WebUI.Infrastructure.Alerts;
using SiparisEnt.WebUI.Infrastructure.Attribute;
using SiparisEnt.WebUI.Infrastructure.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SiparisEnt.WebUI.Controllers
{
    public class OrderController : BaseController
    {
        private IProductService _productService;
        private IOrderDetailService _orderDetailService;
        private IUnitService _unitService;
        private ITaxService _taxService;
        private IOrderService _orderService;
        private IOrderBasketService _orderBasketService;
        private IDeliveryService _deliveryService;
        private IExcService _excService;
        private ICustomerService _customerService;
        private IStatusService _statusService;
        private IMapper _mapper;

        #region Ctor
        public OrderController(IMapper mapper, IOrderService orderService, IOrderBasketService orderBasketService, IDeliveryService deliveryService, IExcService excService, IProductService productService, IUnitService unitService, ITaxService taxService, IOrderDetailService orderDetailService, ICustomerService customerService, IStatusService statusService)
        {
            _mapper = mapper;
            _orderService = orderService;
            _orderBasketService = orderBasketService;
            _deliveryService = deliveryService;
            _excService = excService;
            _productService = productService;
            _unitService = unitService;
            _taxService = taxService;
            _orderDetailService = orderDetailService;
            _customerService = customerService;
            _statusService = statusService;
        }
        #endregion

        #region AddEditList
        // GET: Order
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }
        public ActionResult List(OrderSearchModel model)
        {
            System.Web.HttpContext.Current.Session["ActiveOrder"] = null;
            int pageIndex = model.Page ?? 1;
            var orderList = _orderService.GetOrderDetailItems().Where(x =>
                (string.IsNullOrEmpty(model.OrderNo) ||
                 x.OrderNoSeries.Trim().Contains(model.OrderNo.Trim()))
                 &
                (model.StatusId == 0 || model.StatusId == null ||
                 x.StatusId == model.StatusId)
                &
               (x.OrderDate >= Convert.ToDateTime(model.StartDateTime) & x.OrderDate <= Convert.ToDateTime(model.EndDateTime))
                );

            var data = _mapper.Map<List<OrderDetailItemModel>>(orderList);

            model.StatusList = GetStatusList();
            model.Status2List = GetStatusList();
            model.OrderDetailItemModels = data.ToPagedList(pageIndex, 10);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_OrderList", model);
            }
            return View(model);
        }

        public ActionResult Add()
        {

            var model = new OrderModel();
            model.Order.UserId = AccountHelper.GetAccount().Id;
            model.Order.OrderNo = _orderService.GetOrderSerial(model.Order.OrderSeries);
            var basket = OrderDetailCart.ActiveOrder._Items;
            model.OrderDetailList = _mapper.Map<List<OrderDetailBasketModel>>(basket);
            model.DeliveryList = GetDeliveryList();
            model.ExchangeList = GetExchangeList();
            model.StatusList = GetStatusList();

            return View(model);
        }



        [HttpPost, ValidateAntiForgeryToken]
        [ExceptionHandler]
        public ActionResult Add(Order order)
        {
            var model = new OrderModel();

            var basket = OrderDetailCart.ActiveOrder._Items;
            if (!basket.Any())
            {
                model.DeliveryList = GetDeliveryList();
                model.ExchangeList = GetExchangeList();
                return View(model).WithWarning("Sepette ürün yok!");
            }

            var orderresult = _orderService.Add(order);
            if (orderresult != null)
            {

                var baskets = OrderDetailCart.ActiveOrder._Items.ToList();

                int count = 0;
                foreach (var detail in baskets)
                {

                    detail.OrderDetail.OrderId = orderresult.Id;
                    detail.OrderDetail.RowNo = count;
                    detail.Id = 0;

                    _orderDetailService.Add(detail.OrderDetail);
                    count++;
                }
                OrderDetailCart.ActiveOrder.Clear();
                return RedirectToAction("List").WiActionResult("Kayıt işlemi başarılı.");
            }
            else
            {
                return View(new OrderModel());
            }
        }

        public ActionResult Edit(int id)
        {
            System.Web.HttpContext.Current.Session["ActiveOrder"] = null;
            var order = _orderService.GetById(id);
            var orderModel = new OrderModel { Order = order };

            orderModel.CustomerName = _customerService.GetById(orderModel.Order.CustomerId).Name;
            orderModel.DeliveryList = GetDeliveryList();
            orderModel.ExchangeList = GetExchangeList();
            orderModel.StatusList = GetStatusList();

            var orderDetails = _orderDetailService.GetAll().Where(x => x.OrderId == order.Id);

            var orderDetail = new OrderDetailBasketModel();
            foreach (var orderDetailBasket in orderDetails)
            {
                orderDetail.ProductName = _productService.GetById(orderDetailBasket.ProductId).ProductName;
                //var detail = _mapper.Map<OrderDetailBasketModel>(orderDetailBasket);
                OrderDetailCart.ActiveOrder.OrderAdd(orderDetailBasket, orderDetail.ProductName);
                Session["cart"] = OrderDetailCart.ActiveOrder._Items.Count;
            }

            var orderbasketlist = OrderDetailCart.ActiveOrder._Items;
            var orderDetailBasketModel = _mapper.Map<List<OrderDetailBasketModel>>(orderbasketlist);
            orderModel.OrderDetailList = orderDetailBasketModel;
            return View(orderModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        [ExceptionHandler]
        public ActionResult Edit(OrderModel orderModel)
        {
            var basket = OrderDetailCart.ActiveOrder._Items;
            if (!basket.Any())
            {
                orderModel.DeliveryList = GetDeliveryList();
                orderModel.ExchangeList = GetExchangeList();
                orderModel.StatusList = GetStatusList();
                return View(orderModel).WithWarning("Sepette ürün yok!");
            }

            var order = _orderService.GetById(orderModel.Order.Id);

            var orderresult = _orderService.Update(orderModel.Order);

            if (orderresult != null)
            {
                DeleteOrderDetail(orderresult);
                var orderdetailBasketModels = OrderDetailCart.ActiveOrder._Items;

                int count = 0;
                foreach (var orderdetail in orderdetailBasketModels)
                {
                    orderdetail.OrderDetail.OrderId = order.Id;
                    orderdetail.OrderDetail.RowNo = orderdetail.OrderDetail.RowNo++;
                    _orderDetailService.Add(orderdetail.OrderDetail);
                }
               OrderDetailCart.ActiveOrder.Clear();
                
                return RedirectToAction("List").WiActionResult("Güncelleme işlemi başarılı.");
            }
            else
            {
                OrderDetailCart.ActiveOrder.Clear();
                return View(orderModel);
            }
        }


        [ExceptionHandler]
        public ActionResult Delete(int id)
        {
            var order = _orderService.GetById(id);

            var result = false;
            if (order != null)
            {
                var orderdetails = _orderDetailService.GetOrderById(order.Id);
                foreach (var orderdetail in orderdetails)
                {
                    _orderDetailService.Delete(orderdetail);
                }
                result = _orderService.Delete(order);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [ExceptionHandler]
        public ActionResult OrderDelete(int orderId)
        {
            var order = _orderService.GetById(orderId);


            if (order != null)
            {
                var orderdetails = _orderDetailService.GetOrderById(order.Id);
                foreach (var orderdetail in orderdetails)
                {
                    _orderDetailService.Delete(orderdetail);
                }
                _orderService.Delete(order);
            }

            return RedirectToAction("List", "Order").WiActionResult("Sipariş Silindi");
        }
        #endregion

        #region OrderDetail
        [HttpPost]
        public ActionResult GetOrderBasketList()
        {
            var model = new OrderModel();
            var basket = OrderDetailCart.ActiveOrder._Items;
            model.OrderDetailList = _mapper.Map<List<OrderDetailBasketModel>>(basket);

            return PartialView("_OrderDetails", model);
        }
        [HttpPost]
        public ActionResult AddOrderBasket(int productId)
        {
            var product = _productService.GetById(productId);

            OrderDetailBasketModel orderBasket = new OrderDetailBasketModel();
            orderBasket.ProductName = _productService.GetById(productId).ProductName;

            orderBasket.OrderDetail.ProductId = productId;
            orderBasket.Quantity = 1;
            orderBasket.OrderDetail.UserId = AccountHelper.GetAccount().Id;
            orderBasket.OrderDetail.Discount = 0;
            orderBasket.OrderDetail.Unit = _unitService.GetById(product.UnitId??1).Name;
            orderBasket.OrderDetail.Tax = Convert.ToDecimal(_taxService.GetById(product.Tax).Name);
            orderBasket.OrderDetail.UnitPrice = product.Price;


            orderBasket.OrderDetail.Total = (decimal)(orderBasket.Quantity * (double)Convert.ToDecimal(orderBasket.OrderDetail.UnitPrice));

            OrderCalcTax(orderBasket);

            OrderDetailCart.ActiveOrder.OrderAdd(orderBasket.OrderDetail, orderBasket.ProductName);

            return Json("1");
        }

        [HttpPost]
        public ActionResult ChangeOrderQuantity(int id, double orderquantity)
        {

            var order = OrderDetailCart.ActiveOrder._Items
                .FirstOrDefault(x => x.OrderDetail.ProductId == id);
            if (order != null)
            {
                order.Quantity = orderquantity;
                order.OrderDetail.Total = (decimal)(order.Quantity * Convert.ToDouble(order.OrderDetail.UnitPrice));
                order.OrderDetail.DisCountTotal = (decimal)(order.OrderDetail.Discount * (decimal)order.OrderDetail.Total) / 100;

                var result = OrderDetailCart.ActiveOrder.OrderUpdate(order.OrderDetail);
                OrderTotalCalc(result);
                if (result != null)
                    return Json("1");
            }

            return Json("-1");
        }
        public ActionResult ChangeOrderPrice(int id, decimal orderprice)
        {


            var order = OrderDetailCart.ActiveOrder._Items
                .FirstOrDefault(x => x.OrderDetail.ProductId == id);
            if (order != null)
            {
                order.OrderDetail.UnitPrice = orderprice;
                order.OrderDetail.Total = (decimal)(order.Quantity * (double)orderprice);
                order.OrderDetail.DisCountTotal = (decimal)(order.OrderDetail.Discount * (decimal)order.OrderDetail.Total) / 100;
                var result = OrderDetailCart.ActiveOrder.OrderUpdate(order.OrderDetail);
                OrderTotalCalc(result);
                if (result != null)
                    return Json("1");
            }

            return Json("-1");


        }
        public ActionResult ChangeOrderDisCount(int id, decimal orderdiscount)
        {

            var order = OrderDetailCart.ActiveOrder._Items
                .FirstOrDefault(x => x.OrderDetail.ProductId == id);
            if (order != null)
            {
                order.OrderDetail.Discount = orderdiscount;
                order.OrderDetail.Total = (decimal)(order.Quantity * (double)Convert.ToDecimal(order.OrderDetail.UnitPrice));
                order.OrderDetail.DisCountTotal = (decimal)(orderdiscount * (decimal)order.OrderDetail.Total) / 100;
                var result = OrderDetailCart.ActiveOrder.OrderUpdate(order.OrderDetail);
                OrderTotalCalc(result);
                if (result != null)
                    return Json("1");
            }

            return Json("-1");
        }
        [HttpPost]
        public ActionResult DeleteOrderBasket(int id, int orderdtId = 0)
        {
            var order = OrderDetailCart.ActiveOrder._Items.FirstOrDefault(x => x.OrderDetail.ProductId == id);
            if (order != null)
            {
                OrderDetailCart.ActiveOrder.OrderRemove(order.OrderDetail);
                return Json(JsonError.SetMessage("Silme işlemi başarılı.", "success"), JsonRequestBehavior.AllowGet);
            }
            return Json(JsonError.SetMessage("Silme işlemi başarısız.", "error"), JsonRequestBehavior.AllowGet);

        }
        private void OrderTotalCalc(OrderDetailBasketModel orderBasket)
        {
            // var order = _orderBasketService.GetAll().FirstOrDefault(x => x.Id == orderBasket.Id && x.UserId == AccountHelper.GetAccount().Id);
            var order = OrderDetailCart.ActiveOrder._Items
                .FirstOrDefault(x => x.OrderDetail.ProductId == orderBasket.OrderDetail.ProductId);
            if (order != null)
            {
                OrderCalcTax(order);
                OrderDetailCart.ActiveOrder.OrderUpdate(order.OrderDetail);
            }

        }
        private void DeleteOrderDetail(Order orderresult)
        {
            var orderdetails = _orderDetailService.GetOrderById(orderresult.Id);
            if (orderdetails != null)
            {
                foreach (var orderdetail in orderdetails)
                {
                    _orderDetailService.Delete(orderdetail);
                }
            }
        }
        private static void OrderCalcTax(OrderDetailBasketModel orderBasket)
        {
            if (orderBasket.OrderDetail.Tax == 0)
            {
                orderBasket.OrderDetail.Tax1Total = 0;
            }

            if (orderBasket.OrderDetail.Tax == 1)
            {
                orderBasket.OrderDetail.Tax2Total =
                    (decimal)(orderBasket.OrderDetail.Tax * (decimal)orderBasket.OrderDetail.Total) / 100;
            }

            if (orderBasket.OrderDetail.Tax == 8)
            {
                orderBasket.OrderDetail.Tax3Total =
                    (decimal)(orderBasket.OrderDetail.Tax * (decimal)orderBasket.OrderDetail.Total) / 100;
            }

            if (orderBasket.OrderDetail.Tax == 18)
            {
                orderBasket.OrderDetail.Tax4Total =
                    (decimal)(orderBasket.OrderDetail.Tax * (decimal)orderBasket.OrderDetail.Total) / 100;
            }
        }
        #endregion

        #region Method
        [HttpPost]
        public ActionResult OrderSeriNo(string orderSeries)
        {
            var result = _orderService.GetOrderSerial(orderSeries);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        private List<SelectListItem> GetDeliveryList()
        {
            return _deliveryService.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
        }
        private List<SelectListItem> GetExchangeList()
        {
            return _excService.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
        }
        private List<SelectListItem> GetStatusList()
        {
            return _statusService.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
        }
        public ActionResult MultiStatuChange(string id, int statuId)
        {
            string[] ordersId = id.Split(',');
            foreach (var s in ordersId)
            {
                var orderId = Convert.ToInt32(s);

                var order = _orderService.GetById(orderId);
                order.StatusId = statuId;
                _orderService.Update(order);
            }

            return Json("1", JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}