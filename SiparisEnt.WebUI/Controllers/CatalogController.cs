using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using PagedList;
using PagedList.Mvc;
using SiparisEnt.Business.Abstract;
using SiparisEnt.Dto.CatalogVM;

namespace SiparisEnt.WebUI.Controllers
{
    public class CatalogController : Controller
    {
        // GET: Catalog
        private IMapper _mapper;
        private ICustomerService _customerService;
        private IProductService _productService;
        private ICustomerAuthorizedService _customerAuthorizedService;

        public CatalogController(ICustomerService customerService, IMapper mapper, IProductService productService, ICustomerAuthorizedService customerAuthorizedService)
        {
            _customerService = customerService;
            _mapper = mapper;
            _productService = productService;
            _customerAuthorizedService = customerAuthorizedService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductPopup(ProductPopupModel model)
        {
            int pageIndex = model.Page ?? 1;
            var products = _productService.GetAll().Where(x =>
                (string.IsNullOrEmpty(model.ProductCode) ||
                 x.ProductCode.Trim().ToLower().Contains(model.ProductCode.Trim().ToLower())) 
            &&
                (string.IsNullOrEmpty(model.ProductName) ||
                 x.ProductName.Trim().ToLower().Contains(model.ProductName.Trim().ToLower()))
                ).ToList();
            var productlistpopup = _mapper.Map<List<ProductListPopup>>(products);
            model.ProductListPopups = productlistpopup.OrderByDescending(x => x.Id).ToPagedList(pageIndex, 5);
            if (Request.IsAjaxRequest())
            {
                return PartialView("ProductListPopup", model);
            }
            return PartialView("_ProductPopup", model);
        }


        public ActionResult CustomerPopup(CustomerPopupModel model)
        {
            int pageIndex = model.Page ?? 1;
            var customer = _customerService.GetAll().Where(x =>
                (string.IsNullOrEmpty(model.CusName) ||
                 x.Name.Trim().ToLower().Contains(model.CusName.Trim().ToLower()))
                ).ToList();
            var cutomerlistpopup = _mapper.Map<List<CustomerListPopup>>(customer);
            model.CustomerListPopups = cutomerlistpopup.OrderByDescending(x => x.Id).ToPagedList(pageIndex, 5);
            if (Request.IsAjaxRequest())
            {
                return PartialView("CustomerListPopup", model);
            } 
            return PartialView("_CustomerPopup", model);
        }

        public ActionResult CustomerAuthorizedPopup()
        {
            var model = new CustomerAuthorizedPopupModel();
           
               return PartialView("_CustomerAuthorizedPopup", model);
            
         
         
        }

        public ActionResult GetCustomerAutList(int customerId)
        {
            var model = new CustomerAuthorizedPopupModel();
            var customeraut = _customerAuthorizedService.GetCustomerById(customerId);
            if (customeraut == null)
            {
                return PartialView("_CustomerAuthorizedPopup", model);
            }
            model.CustomerAuthorizedList = customeraut;
            return PartialView("CustomerAuthorizedListPopup", model);
        }


      
        public ActionResult CustomerAuthorizedAdd()
        {
            var model = new CustomerAuthorizedAddViewModel();
            return PartialView("_CustomerAuthorizedAddPopup", model);
        }
        [HttpPost]
        public ActionResult CustomerAuthorizedAdd(CustomerAuthorizedAddViewModel model)
        {
            if (model.CustomerAuthorized!=null)
            {
                _customerAuthorizedService.Add(model.CustomerAuthorized);
            }
        
           
          return PartialView("_CustomerAuthorizedAddPopup",model);
        }


    }
}