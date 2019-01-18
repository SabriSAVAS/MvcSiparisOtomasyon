using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using SiparisEnt.Business.Abstract;
using SiparisEnt.Core.CrossCuttingConcerns.Security.Web;
using SiparisEnt.Dto.LoginVM;
using SiparisEnt.WebUI.Infrastructure.EncryptDecrypt;


namespace SiparisEnt.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private IUserService _userService;
        private IMapper _mapper;

        public LoginController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET: Login
        public ActionResult Index()
        {
            var loginModel = new LoginModel();

            return View(loginModel);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel loginModel)
        {

            if (ModelState.IsValid)
            {
                var user = _userService.IsVaildUser(loginModel.eMail,loginModel.Password);
                
                if (user != null)
                {
                    AuthenticationHelper.CreateAutCookie(
                       user.Id, user.FirstName + " " + user.LastName,
                        user.eMail,
                        DateTime.Now.AddDays(15),
                        _userService.GetUserRoleItems(user).Select(u => u.RoleName).ToArray(),
                        false,
                        user.FirstName,
                        user.LastName);
                    return RedirectToAction("Index","Home");
                }
               
            }
            
            return View(loginModel);
        }

        public ActionResult SingAout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}