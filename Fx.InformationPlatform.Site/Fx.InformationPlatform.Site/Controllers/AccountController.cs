using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.Account.IService;
using Fx.Entity.Account;
using Fx.Entity.MemberShip;
using Fx.InformationPlatform.Site.ViewModel;
using FxCacheService.FxSite;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 帐号控制器
    /// </summary>
    public class AccountController : Controller
    {
        private IAccountService accountService;
        private GlobalCache gloCache;
        public AccountController(IAccountService accountService,
            GlobalCache gloCache)
        {
            this.accountService = accountService;
            this.gloCache = gloCache;
            ViewBag.UserCount = gloCache.UserCount();
        }

        //
        // GET: /Account/

        public ActionResult Index()
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
                var userExtend = accountService.GetUserExtendInfo(user.Email);
                Session[user.Email] = userExtend.NickName == null ? "" : userExtend.NickName;
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
            var other = new OtherInformation();
            other.Address = "";
            other.Mobile = user.Mobile;
            other.QQ = user.QQ;
            other.Sex = SexCatalog.Male;
            other.NickName = user.NickName;
            var entityResult = accountService.AddUser(membershipuser, other);
            if (entityResult.isSuccess)
            {
                // 跳转到登录页面
                //System.Web.Security.FormsAuthentication.SetAuthCookie(user.Email, true);
                //Session[user.Email] = user.NickName == null ? "" : user.NickName;
                var ticket = new System.Web.Security.FormsAuthenticationTicket(user.Email, true, 30);
                string authTicket = System.Web.Security.FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName, authTicket);
                cookie.Domain = AppSettings.FormDomain;
                var userExtend = accountService.GetUserExtendInfo(user.Email);
                Session[user.Email] = userExtend.NickName == null ? "" : userExtend.NickName;
                Response.Cookies.Add(cookie);
                gloCache.UserCountAdd();
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

        public ActionResult ResetPassword()
        {
            return View();
        }


        /// <summary>
        /// 邮箱重置密码 需要考虑恶意破解的问题 但是没有实现
        /// </summary>
        /// <param name="useremail"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ResetPassword(string useremail)
        {
            var isExist = accountService.IsExistUser(useremail);
            if (isExist.isSuccess)
            {
                accountService.ResetPassword(useremail);
                ViewBag.Tip = "已发送邮件到您的邮箱,如果你未收到，请耐心等待几分钟";
                return View();
            }
            else
            {
                ViewBag.Tip = "对不起，不存在这个邮箱帐号";
                return View();
            }
        }

    }
}
