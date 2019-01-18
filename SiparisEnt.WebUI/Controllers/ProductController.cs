using AutoMapper;
using PagedList;
using SiparisEnt.Business.Abstract;
using SiparisEnt.Dto.ProductVM;
using SiparisEnt.Entities.Concrete;
using SiparisEnt.WebUI.Infrastructure.Alerts;
using SiparisEnt.WebUI.Infrastructure.Attribute;
using SiparisEnt.WebUI.Infrastructure.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SiparisEnt.WebUI.Controllers
{

    public class ProductController : BaseController
    {
        private IProductService _productService;
        private IBrandService _brandService;
        private IUnitService _unitService;
        private ICategoryService _categoryService;
        private ITaxService _taxService;
        private IExcService _excService;
        private IOrderDetailService _orderDetailService;
        private IMapper _mapper;

        public ProductController(IProductService productService, IBrandService brandService, IUnitService unitService, ICategoryService categoryService, ITaxService taxService, IExcService excService, IMapper mapper, IOrderDetailService orderDetailService)
        {
            _productService = productService;
            _brandService = brandService;
            _unitService = unitService;
            _categoryService = categoryService;
            _taxService = taxService;
            _excService = excService;
            _mapper = mapper;
            _orderDetailService = orderDetailService;
        }

        #region AddEditList
        // GET: Product

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }
      
        public ActionResult List(ProductSearchModel productSearchModel)
        {
            int pageIndex = productSearchModel.Page ?? 1;
            var productList = _productService.GetAll().Where(
                x => (string.IsNullOrEmpty(productSearchModel.ProductCode) ||
                      x.ProductCode.ToLower().Trim().Contains(productSearchModel.ProductCode.ToLower().Trim()))
                     &&
                     (string.IsNullOrEmpty(productSearchModel.ProductName) ||
                      x.ProductName.ToLower().Trim().Contains(productSearchModel.ProductName.ToLower().Trim()))
            ).ToList();

            var list = _mapper.Map<List<Product>>(productList);
            productSearchModel.ProdcutList = list.OrderByDescending(x => x.Id).ToPagedList(pageIndex, 10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_productList", productSearchModel);
            }

            return View(productSearchModel);
        }
        
        public ActionResult Add()
        {
            var model = new ProductModel();
            model.BrandList = GetBrandList();
            model.CategoryList = GetCategoryList();
            model.UnitList = GetUnListList();
            model.TaxList = GetTaxList();
            model.ExcList = GetExcList();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        [ExceptionHandler]
        public ActionResult Add(Product product)
        {           
                if (_productService.Add(product) != null)
                    return RedirectToAction("List").WiActionResult("Kayıt işlemi başarılı.");
                return RedirectToAction("List").WiActionResult("Kayıt işlemi sırasında bir hata oluştu.");
        }
     
        public ActionResult Update(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return HttpNotFound();
            }

            var product = _productService.GetById(Id ?? 0);
            var productModel =new ProductModel();
            productModel.Product = product;
            productModel.BrandList = GetBrandList();
            productModel.CategoryList = GetCategoryList();
            productModel.UnitList = GetUnListList();
            productModel.TaxList = GetTaxList();
            productModel.ExcList = GetExcList();
            return View(productModel);
        }
        [HttpPost, ValidateAntiForgeryToken]
        [ExceptionHandler]
        public ActionResult Update(Product product)
        {
                if (_productService.Update(product) != null)
                    return RedirectToAction("List").WiActionResult("Güncelleme işlemi başarılı.");
                return RedirectToAction("List").WiActionResult("Güncelleme işlemi sırasında bir hata oluştu.");       
        }
        [HttpPost]
        [ExceptionHandler]
        public ActionResult Delete(int Id)
        {
            var product = _productService.GetById(Id);
            var order = _orderDetailService.GetAll().FirstOrDefault(x => x.ProductId == product.Id);
            var result = _productService.Delete(product);
            return order!=null 
                ? Json(JsonError.SetMessage("Hareket görmüş kayıt silinemez.", "info"), JsonRequestBehavior.AllowGet) 
                : Json(result ? JsonError.SetMessage("Silme işlemi başarlı.", "success") 
                : JsonError.SetMessage("Silme işlemi başarısız.", "error"), JsonRequestBehavior.AllowGet);

        }
        #endregion


        #region Method
        private List<SelectListItem> GetBrandList()
        {
            return _brandService.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
        }

        private List<SelectListItem> GetCategoryList()
        {
            return _categoryService.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
        }
        private List<SelectListItem> GetUnListList()
        {
            return _unitService.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
        }
        private List<SelectListItem> GetTaxList()
        {
            return _taxService.GetAll().OrderByDescending(x => x.Id).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = "Kdv %"+x.Name
            }).ToList();
        }
        private List<SelectListItem> GetExcList()
        {
            return _excService.GetAll().Select(x => new SelectListItem
            {
                Value = x.Name.ToString(),
                Text = x.Name
            }).ToList();
        }

        public ActionResult GetProductCodeControl(string productCode)
        {
            return Json(!_productService.GetProductCodeControl(productCode), JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}