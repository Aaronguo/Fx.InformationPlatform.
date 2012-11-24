using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.Account.IService;
using Fx.Entity.Account;
using Fx.Entity.MemberShip;

namespace Fx.InformationPlatform.Site.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService accountService;
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
            ViewBag.UserCount = UserCount();
        }

        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Profile()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(RegisterUser user, string returnUrl)
        {

            var result = accountService.VaildUser(user.Email, user.Password);
            if (result.isSuccess)
            {
                //创建验证票subdomain  share cookie
                var ticket = new System.Web.Security.FormsAuthenticationTicket(user.Email, true, 30);

                string authTicket = System.Web.Security.FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName, authTicket);
                cookie.Domain = AppSettings.FormDomain;
                Response.Cookies.Add(cookie);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Error = result.ResultMsg;
            }
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }


        public ActionResult Register(RegisterUser user)
        {
            if (!ModelState.IsValid || user == null ||
                user.VerificationCode == null || user.Email == null
                || Session["PictureCode"] == null)
            {
                return View("Register", user);
            }
            if (string.Compare(user.VerificationCode, Session["PictureCode"].ToString(), true) != 0)
            {
                ViewBag.VerificationCode = "验证码错误,请重试";
                return View("Register", user);
            }
            var membershipuser = new Membership();
            membershipuser.Users = new Users();
            membershipuser.Users.UserName = user.Email;
            membershipuser.MobilePIN = user.Mobile;
            membershipuser.Email = user.Email;
            membershipuser.Password = user.Password;
            membershipuser.OtherInformations.Address = user.Address;
            membershipuser.OtherInformations.Mobile = user.Mobile;
            membershipuser.OtherInformations.NickName = user.NickName;
            membershipuser.OtherInformations.QQ = user.QQ;
            membershipuser.OtherInformations.Sex = SexCatalog.Male;
            if (Request.Files["headPicture"].HasFile())
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "Upload/HeadPicture/";
                string filename = Path.GetFileName(Request.Files["headPicture"].FileName);
            }
            membershipuser.OtherInformations.HeadPicture = user.HeadPicture;
            var entityResult = accountService.AddUser(membershipuser);
            if (entityResult.isSuccess)
            {
                // 跳转到登录页面
                System.Web.Security.FormsAuthentication.SetAuthCookie(user.Email, true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = entityResult.ResultMsg;
                return View("Register", user);
            }
        }

        /// <summary>
        /// 注销用户
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginOff()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Session.Clear();          
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// 用户查询缓存5分钟
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 300)]
        protected int UserCount()
        {
            return accountService.GetUserCount();
        }



    }
}
