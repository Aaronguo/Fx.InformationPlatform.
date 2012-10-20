using System;
using System.Web.Security;
using System.Linq;
using System.Data.Entity;

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
                var ret = DomainResult.GetDefault();
                ret.Tag = user;
                return ret;
            }
            else
            {
                return new DomainResult(false);
            }
        }

        public DomainResult AddUser(Entity.MemberShip.Membership entity)
        {
            if ( !IsExistUser(entity.Users.UserName).isSuccess)
            {
                var result = DomainResult.GetDefault();
                try
                {
                    var muser = Membership.CreateUser(entity.Email, entity.Password, entity.Email);
                    if (muser != null)
                    {
                        AccountContext db = new AccountContext();
                        var user = db.Users.Where(r => r.UserName == entity.Users.UserName).First();
                        var otherInformation = new Fx.Entity.MemberShip.OtherInformation();
                        otherInformation.Mobile = entity.MobilePIN;
                        otherInformation.QQ = entity.OtherInformations.QQ;
                        otherInformation.Sex = entity.OtherInformations.Sex;
                        otherInformation.Address = entity.OtherInformations.Address;
                        otherInformation.HeadPicture = entity.OtherInformations.HeadPicture;
                        otherInformation.NickName = entity.OtherInformations.NickName;
                        otherInformation.ApplicationId = user.ApplicationId;
                        otherInformation.UserId = user.UserId;
                        var rEntity = db.OtherInformations.Add(otherInformation);
                        try
                        {
                            db.SaveChanges();
                        }
                        catch (Exception)
                        {
                            DeleteUser(entity);                         
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



        public DomainResult ChangePassword(Entity.MemberShip.Membership entity)
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


        public int GetUserCount()
        {
            return new AccountContext().Users.Count();
        }
    }
}
