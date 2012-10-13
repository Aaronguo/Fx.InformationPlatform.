using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Entity;

namespace Fx.Domain.Account.IService
{
    public interface IAccountService
    {
        DomainResult AddUser(Membership entity);

        DomainResult DeleteUser(Membership entity);

        DomainResult UpdateUser(Membership entity);

        DomainResult ChangePassword(Membership entity);

        /// <summary>
        /// 用户帐号是否存在
        /// </summary>
        /// <param name="userName">帐号</param>
        /// <returns></returns>
        DomainResult IsExistUser(string userName);

        /// <summary>
        /// 验证用户
        /// </summary>
        /// <param name="userName">帐号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        DomainResult VaildUser(string userName, string password);
    }
}
