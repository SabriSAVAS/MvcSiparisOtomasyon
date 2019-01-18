using SiparisEnt.Business.Abstract;
using SiparisEnt.Dto.DashboardVM;
using System.Web.Mvc;

namespace SiparisEnt.WebUI.Controllers
{

    public class HomeController : BaseController
    {
        // GET: Home
        private IProductService _productService;
        private IOrderService _orderService;

        public HomeController(IProductService productService, IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }


        public ActionResult Index()
        {
            var model = new DashboardViewModel
            {
                NewPaddingOrder= _orderService.GetNewPaddingOrder(),
                CompletedOrder=_orderService.GetCompletedOrder(),
                PreparedOrder=_orderService.GetPreparedOrder(),
                OrdersShipped=_orderService.GetOrdersShipped(),
                OrderDetailItems = _orderService.GetTop10OrderDetailItems(),
                CompletedOrderTotal=_orderService.GetCompletedOrderTotal()
            };
            Session["OrdersShipped"] = model.OrdersShipped;
            return View(model);
        }




    }
}