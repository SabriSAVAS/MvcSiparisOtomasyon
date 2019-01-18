using AutoMapper;
using PagedList;
using SiparisEnt.Business.Abstract;
using SiparisEnt.Dto.CustomerVM;
using SiparisEnt.Entities.Concrete;
using SiparisEnt.WebUI.Infrastructure.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SiparisEnt.WebUI.Controllers
{
    public class CustomerController : BaseController
    {
        private ICustomerService _customerService;
        private ICityService _cityService;
        private IOrderService _orderService;
        private IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper, ICityService cityService, IOrderService orderService)
        {
            _customerService = customerService;
            _mapper = mapper;
            _cityService = cityService;
            _orderService = orderService;
        }

        #region AddEditList
        // GET: Customer
        public ActionResult Index()
        {

            return RedirectToAction("List");
        }

        public ActionResult List(CustomerSearchModel customerSearchModel)
        {
            int pageIndex = customerSearchModel.Page ?? 1;

            var data = _customerService.GetCustomerDetailAll().Where(x =>
                (string.IsNullOrEmpty(customerSearchModel.CustomerName) || x.Name.ToLower().Trim()
                     .Contains(customerSearchModel.CustomerName.Trim().ToLower()))).ToList();
            var customerDetail = _mapper.Map<List<CustomerDetailModel>>(data);

            customerSearchModel.CustomerDetailModelList = customerDetail.OrderByDescending(x => x.Id).ToPagedList(pageIndex, 10);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_customerList", customerSearchModel);
            }
            return View(customerSearchModel);
        }

        public ActionResult AddEditCustomer()
        {
            var model = new CustomerModel();
            model.CityList = GetCity();
            return PartialView("_AddEditCustomer", model);
        }
        [HttpPost]
        public ActionResult AddEditCustomer(CustomerModel model)
        {
            if (model.Id == 0)
            {
                var customer = _mapper.Map<Customer>(model);
                _customerService.Add(customer);
                return Json("1");
            }
            else
            {

                var customer = _mapper.Map<Customer>(model);
                _customerService.Update(customer);
                return Json("2");
            }


        }

        [HttpPost]
        public JsonResult Edit(int Id)
        {
            var data = _customerService.GetById(Id);
            var customerModel = _mapper.Map<CustomerModel>(data);
            return Json(customerModel, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Delete(int Id)
        {
            var customer = _customerService.GetById(Id);
            var customerresult=_orderService.OrderIsCustomerControl(customer.Id);
            if (customerresult)
            {
                return Json(JsonError.SetMessage("Hareket görmüş kayıt silinemez.", "info"));
            }
            var result = _customerService.Delete(customer);
            return Json(result ? JsonError.SetMessage("Silme işlemi başarlı.", "success") : JsonError.SetMessage("Silme işlemi başarısız.", "error"));
        }

        #endregion

        #region Method
        private List<SelectListItem> GetCity()
        {
            return _cityService.GetAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
                .ToList();
        } 
        #endregion
    }
}