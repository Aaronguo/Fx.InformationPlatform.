using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Fx.Entity.Account
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "用户名不能为空")]
        [StringLength(256, MinimumLength = 4, ErrorMessage = "用户名长度为4~256个字符")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "请填写正确的邮箱地址")]
        [Required(ErrorMessage = "Email不能为空")]
        public string Email { get; set; }

        [MobileCheck(ErrorMessage = "请填写正确的手机号码")]
        [Required(ErrorMessage = "手机号码不能为空")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        [StringLength(256, MinimumLength = 6, ErrorMessage = "用户名长度为6~128个字符")]
        public string Password { get; set; }
    }
}
