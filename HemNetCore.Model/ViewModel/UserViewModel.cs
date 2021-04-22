using System;
using System.Collections.Generic;
using System.Text;

namespace HemNetCore.Model.ViewModel
{
    public class UserViewModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 地址
        /// </summary>

        public string Address { get; set; }
    }
}
