using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HemNetCore.Model.Dto
{
    public class MemberDto : PagedParmDto
    {
        [Display(Name = "登录名")]
        public string LoginName { get; set; }

        [Display(Name = "姓名")]
        public string UserName { get; set; }

        [Display(Name = "手机号")]
        public string Phone { get; set; }
    }
}
