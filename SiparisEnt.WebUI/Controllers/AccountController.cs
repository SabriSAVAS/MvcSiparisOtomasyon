using AutoMapper;
using PagedList;
using SiparisEnt.Business.Abstract;
using SiparisEnt.Dto.AccountVM;
using SiparisEnt.Entities.Concrete;
using SiparisEnt.WebUI.Infrastructure.Alerts;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SiparisEnt.WebUI.Infrastructure.EncryptDecrypt;

namespace SiparisEnt.WebUI.Controllers
{
    public class AccountController : BaseController
    {
        private IUserService _userService;
        private IMapper _mapper;

        public AccountController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        #region AddEditList
        // GET: Account
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }
        public ActionResult List(AccountSearchModel accountSearchModel)
        {
            int pageIndex = accountSearchModel.Page ?? 1;

            var data = _userService.GetAll().Where(x =>
                (string.IsNullOrEmpty(accountSearchModel.UserName) || x.FirstName.ToLower().Trim()
                     .Contains(accountSearchModel.UserName.ToLower().Trim()))
                &&
                (string.IsNullOrEmpty(accountSearchModel.eMail) ||
                 x.eMail.ToLower().Trim().Contains(accountSearchModel.eMail.ToLower().Trim()))
            ).ToList();

            var accountList = _mapper.Map<List<AccountModel>>(data);
            accountSearchModel.AccountList = accountList.ToPagedList(pageIndex, 10);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_accountList", accountSearchModel);
            }

            return View(accountSearchModel);
        }
        public ActionResult Add()
        {
            var accountModel = new AccountModel();
            return View(accountModel);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Add(AccountModel accountModel)
        {
            if (ModelState.IsValid)
            {
                accountModel.Password = Crypto.Encrypt(accountModel.Password);
                var result = _userService.Add(_mapper.Map<User>(accountModel));
                if (result != null)
                    return RedirectToAction("List").WiActionResult("Kayıt işlemi başarılı.");
                return RedirectToAction("List").WiActionResult("Kayıt işlemi sırasında bir hata oluştu.");

            }

            return View(accountModel);
        }
        public ActionResult Edit(int Id)
        {
            if (Id == 0)
            {
                return HttpNotFound();
            }

            var account = _userService.GetById(Id);

            var accountModel = _mapper.Map<AccountModel>(account);
            accountModel.Password = Crypto.Decrypt(account.Password);
            accountModel.ConfirimPassword = Crypto.Decrypt(account.Password);
            return View(accountModel);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(AccountModel accountModel)
        {
            if (ModelState.IsValid)
            {
                var account = _userService.GetById(accountModel.Id);
                account = _mapper.Map<User>(accountModel);
                account.Password = Crypto.Encrypt(accountModel.Password);
                var result = _userService.Update(account);
                if (result != null)
                    return RedirectToAction("List").WiActionResult("Güncelleme işlemi başarılı.");
                return RedirectToAction("List").WiActionResult("Güncelleme işlemi sırasında bir hata oluştu.");

            }

            return View(accountModel);
        }
        public ActionResult Delete(int Id)
        {
            var account = _userService.GetById(Id);
            var result = _userService.Delete(account);
            return Json(result);
        }

        #endregion

        #region Method

        public ActionResult AccountChangePassword()
        {
            var model = new AccountChangePasswordModel();
            return PartialView("_AccountChangePassword", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccountChangePassword(AccountChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.GetById(model.Id);
                user.Password = Crypto.Encrypt(model.Password);
                if (_userService.Update(user) != null)
                    return Json("1", JsonRequestBehavior.AllowGet);
                return Json("-1", JsonRequestBehavior.AllowGet);
            }
            return PartialView("_AccountChangePassword", model);
        } 
        #endregion
    }
}