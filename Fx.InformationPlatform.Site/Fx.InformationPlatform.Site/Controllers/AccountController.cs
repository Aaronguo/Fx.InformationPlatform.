using System;
using System.Collections.Generic;
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
            //accountService.AddUser(new Entity.Membership()
            //{
            //    Users = new Entity.Users() { UserName = "czj" },
            //    Password = "dsasdsa"
            //});
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
            return View();
        }


        [HttpPost]
        public ActionResult Login(RegisterUser user)
        {
            var result = accountService.VaildUser(user.UserName, user.Password);
            if (result.isSuccess)
            {
                // 跳转到登录页面
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
            if (!ModelState.IsValid)
            {
                return View("Register", user);
            }
            var membershipuser = new Membership();
            membershipuser.Users = new Users();
            membershipuser.Users.UserName = user.UserName;
            membershipuser.MobilePIN = user.Mobile;
            membershipuser.Email = user.Email;
            membershipuser.Password = user.Password;
            var entityResult = accountService.AddUser(membershipuser);
            if (entityResult.isSuccess)
            {
                // 跳转到登录页面
                Session["CurrentUser"] = user.UserName;
                return new HomeController().Index();
            }
            else
            {
                ViewBag.Error = entityResult.ResultMsg;
                return View("Register", user);
            }
        }

        public ActionResult LoginOff()
        {
            Session["CurrentUser"] = null;
            return new HomeController().Index();
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
