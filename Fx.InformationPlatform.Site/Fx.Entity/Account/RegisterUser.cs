﻿using System.ComponentModel.DataAnnotations;

namespace Fx.Entity.Account
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "昵称不能为空")]
        [StringLength(256, MinimumLength = 1, ErrorMessage = "用户名长度为1~256个字符")]
        public string NickName { get; set; }

        [EmailCheck(ErrorMessage = "请填写正确的邮箱地址")]
        [Required(ErrorMessage = "Email不能为空")]
        public string Email { get; set; }

        //[MobileCheck(ErrorMessage = "请填写正确的手机号码")]
        //[Required(ErrorMessage = "手机号码不能为空")]
        [StringLength(11, ErrorMessage = "手机号码长度为11字符")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        [StringLength(256, MinimumLength = 1, ErrorMessage = "用户名长度为1~128个字符")]
        public string Password { get; set; }


        //[Required(ErrorMessage = "地址不能为空")]
        //[StringLength(50, ErrorMessage = "地址长度最大为50个字符")]
        //public string Address { get; set; }

        public string QQ { get; set; }

        public string HeadPicture { get; set; }

        [Required(ErrorMessage = "注册码不能为空")]
        public string VerificationCode { get; set; }
    }
}
