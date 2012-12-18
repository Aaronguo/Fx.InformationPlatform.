using System;
using System.Web.Security;
using System.Linq;
using System.Data.Entity;
using Fx.Infrastructure;

namespace Fx.Domain.Account
{
    public class UserAccountService : IService.IAccountService
    {
        public DomainResult IsExistUser(string userName)
        {
            var user = Membership.GetUser(userName);
            if (user != null)
            {
                var ret = DomainResult.GetDefault();
                ret.Tag = user;
                return ret;
            }
            else
            {
                return new DomainResult(false);
            }

        }

        public DomainResult AddUser(Entity.MemberShip.Membership entity, Entity.MemberShip.OtherInformation other)
        {
            if (!IsExistUser(entity.Users.UserName).isSuccess)
            {
                var result = DomainResult.GetDefault();
                try
                {
                    MembershipCreateStatus createStatus;
                    Membership.CreateUser(entity.Email, entity.Password, entity.Email, null, null, true, null, out createStatus);
                    if (createStatus == MembershipCreateStatus.Success)
                    {
                        using (var content = new SiteContext())
                        {
                            var user = content.Users.Where(r => r.UserName == entity.Users.UserName).First();
                            other.ApplicationId = user.ApplicationId;
                            other.UserId = user.UserId;
                            other.Email = entity.Email;

                            var rEntity = content.OtherInformations.Add(other);
                            try
                            {
                                content.SaveChanges();
                            }
                            catch (Exception)
                            {
                                DeleteUser(entity);
                            }
                        }
                    }
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

        /// <summary>
        /// 实现部分 业务角度来说 其实是不需要的
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public DomainResult DeleteUser(Entity.MemberShip.Membership entity)
        {
            if (IsExistUser(entity.Users.UserName).isSuccess)
            {
                var result = DomainResult.GetDefault();
                try
                {
                    Membership.DeleteUser(entity.Users.UserName);
                    using (var content = new SiteContext())
                    {
                        var other = content.OtherInformations
                            .Where(r => r.Email == entity.Users.UserName).FirstOrDefault();
                        if (other != null)
                        {
                            content.OtherInformations.Remove(other);
                            content.SaveChanges();
                        }
                    }
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
                return new DomainResult(false) { ResultMsg = "用户不存在" };
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public DomainResult UpdateUser(Entity.MemberShip.Membership entity)
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



        public DomainResult ChangePassword(Entity.MemberShip.Membership entity, string oldPassword)
        {
            var result = DomainResult.GetDefault();
            var u = Membership.GetUser(entity.Users.UserName);
            if (u != null)
            {
                try
                {
                    //u.ChangePasswordQuestionAndAnswer(entity.Password, null, null);
                    u.ChangePassword(oldPassword, entity.Password);
                    //u.ResetPassword(u.GetPassword());
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


        public int GetUserCount()
        {
            using (var content = new SiteContext())
            {
                return content.Users.Count();
            }
        }


        public Guid GetCurrentUser(string Email)
        {
            using (var content = new SiteContext())
            {
                return content.Memberships.Where(r => r.Email == Email).First().UserId;
            }
        }


        public Entity.MemberShip.OtherInformation GetUserExtendInfo(string Email)
        {
            using (var content = new SiteContext())
            {
                return content.OtherInformations.Where(r => r.Email == Email).First();
            }
        }

        public DomainResult ResetPassword(string Email)
        {
            var result = DomainResult.GetDefault();
            var u = Membership.GetUser(Email);
            if (u != null)
            {
                string password = u.ResetPassword();
                var template = "亲爱的用户，您在<a herf=\"http://yingtao.co.uk\">英淘网</a>上申请了重置密码, " +
                    "您现在的密码为@Model.Password,为了密码安全，" +
                    "请及时在<a href=\"http://usercenter.yingtao.co.uk/UserCenter/ChangePassword\">用户中心</a>修改密码。<br />" +
                    "注意:此邮件由系统发出，请勿回复,谢谢!";

                var emailSend = FluentEmail.Email
                    .From(System.Configuration.ConfigurationManager.AppSettings["resetsendemail"].ToString())
                    .To(Email)
                    .Subject("英淘网密码找回")
                    .UsingTemplate(template, new { Password = password, });
                var e = emailSend.Send();                
            }
            else
            {
                result.isSuccess = false;
                result.ResultMsg = "用户" + Email + "不存在";
            }
            return result;
        }



    }
}
