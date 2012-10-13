using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Fx.Domain.Account
{
    public class UserAccountService : IService.IAccountService
    {
        public UserAccountService()
        {

        }


        public DomainResult IsExistUser(string userName)
        {
            var user = Membership.GetUser(userName);
            if (user != null)
            {
                return DomainResult.GetDefault();
            }
            else
            {
                return new DomainResult(false) { Tag = user };
            }
        }

        public DomainResult AddUser(Entity.Membership entity)
        {
            if (!IsExistUser(entity.Users.UserName).isSuccess)
            {

                var result = DomainResult.GetDefault();
                try
                {
                    Membership.CreateUser(entity.Users.UserName, entity.Users.UserName);
                }
                catch (Exception ex)
                {
                    result.isSuccess = false;
                    result.error = ex;
                    result.ResultMsg = ex.Message;
                }
                return result;
            }
            else
            {
                return new DomainResult(false) { ResultMsg = "用户已存在" };
            }

        }

        public DomainResult DeleteUser(Entity.Membership entity)
        {
            if (!IsExistUser(entity.Users.UserName).isSuccess)
            {

                var result = DomainResult.GetDefault();
                try
                {
                    Membership.DeleteUser(entity.Users.UserName);
                }
                catch (Exception ex)
                {
                    result.isSuccess = false;
                    result.error = ex;
                    result.ResultMsg = ex.Message;
                }
                return result;
            }
            else
            {
                return new DomainResult(false) { ResultMsg = "用户已存在" };
            }
        }

        public DomainResult UpdateUser(Entity.Membership entity)
        {
            var res = IsExistUser(entity.Users.UserName);
            if (!res.isSuccess)
            {

                var result = DomainResult.GetDefault();
                try
                {
                    var u = result.Tag as MembershipUser;
                    u.Comment = entity.Comment;

                    u.Email = entity.Email;

                    Membership.UpdateUser(u);

                }
                catch (Exception ex)
                {
                    result.isSuccess = false;
                    result.error = ex;
                    result.ResultMsg = ex.Message;
                }
                return result;
            }
            else
            {
                return new DomainResult(false) { ResultMsg = "对不起，不存在帐号" + entity.Users.UserName + "，无法更新相关信息" };
            }
        }



        public DomainResult ChangePassword(Entity.Membership entity)
        {
            var result = DomainResult.GetDefault();
            var u = Membership.GetUser(entity.Users.UserName);
            if (u != null)
            {
                try
                {
                    u.ChangePassword(u.GetPassword(), entity.Password);
                }
                catch (Exception ex)
                {
                    result = result.SetResult(ex.Message, ex);
                }
            }
            else
            {
                result = result.SetResult("当前用户不存在，修改密码失败");
            }
            return result;
        }

        public DomainResult VaildUser(string userName, string password)
        {
            if (Membership.ValidateUser(userName, password))
            {
                return DomainResult.GetDefault();
            }
            else
            {
                return DomainResult.GetDefault().SetResult("帐号密码不正确，请重新尝试");
            }
        }


    }
}
