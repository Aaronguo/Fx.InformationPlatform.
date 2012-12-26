using System.ComponentModel.DataAnnotations;

namespace Fx.Entity.Account
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "昵称不能为空")]
        [StringLength(128, MinimumLength = 1, ErrorMessage = "用户名最大长度为128个字符")]
        public string NickName { get; set; }

        [EmailCheck(ErrorMessage = "请填写正确的邮箱地址")]
        [StringLength(256, MinimumLength = 1, ErrorMessage = "Email最大长度为256个字符")]
        [Required(ErrorMessage = "Email不能为空")]
        public string Email { get; set; }

        //[MobileCheck(ErrorMessage = "请填写正确的手机号码")]
        //[Required(ErrorMessage = "手机号码不能为空")]
        [StringLength(11, ErrorMessage = "手机号码长度为11字符")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        [StringLength(256, MinimumLength = 1, ErrorMessage = "密码最大长度为256个字符")]
        public string Password { get; set; }


        //[Required(ErrorMessage = "地址不能为空")]
        //[StringLength(50, ErrorMessage = "地址长度最大为50个字符")]
        //public string Address { get; set; }

        [StringLength(20, MinimumLength = 0, ErrorMessage = "QQ最大长度为20个字符")]
        public string QQ { get; set; }

        [StringLength(128, MinimumLength = 0, ErrorMessage = "密码最大长度为256个字符")]
        public string HeadPicture { get; set; }

        /// <summary>
        /// 密保问题
        /// </summary>
        [Required(ErrorMessage = "请选择密保问题",AllowEmptyStrings=false)]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "密保问题最大长度为20个字符")]
        public string PasswordQuestion { get; set; }

        /// <summary>
        /// 密保问题答案
        /// </summary>
        [Required(ErrorMessage = "密保问题答案不能为空")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "密保问题答案最大长度为20个字符")]
        public string PasswordAnswer { get; set; }


        [Required(ErrorMessage = "注册码不能为空")]
        public string VerificationCode { get; set; }
    }
}
