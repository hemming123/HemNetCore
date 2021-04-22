using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HemNetCore.Model.Dto
{

    public class LoginDto
    {
        [Required(ErrorMessage = "登录账号不能为空")]
        [Display(Name = "登录账号")]
        public string LoginName { get; set; }

        [Required(ErrorMessage = "登录密码不能为空")]
        [Display(Name = "登录密码")]
        public string PassWord { get; set; }

        [Required(ErrorMessage = "验证码不能为空")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "验证码长度不正确")]
        [Display(Name = "验证码")]
        public string VerificationCode { get; set; }

        [Required(ErrorMessage = "验证码UID不能为空")]
        [Display(Name = "验证UUID")]
        public string UUID { get; set; }
    }
}
