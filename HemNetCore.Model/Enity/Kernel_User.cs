using System;
using System.Collections.Generic;
using System.Text;
using HemNetCore.Model.Enum;
using SqlSugar;

namespace HemNetCore.Model.Enity
{
    /// <summary>
    /// 用户表
    /// </summary>
    [SugarTable("Kernel_User")]
    public class Kernel_User
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [SugarColumn(IsPrimaryKey =true)]
        public Guid ID { get; set; }

        public string LoginName { get; set; }

        public string Name { get; set; }

        public UserType UserType { get; set; }
        public DateTime? PasswordActiveTime { get; set; }

        public string Email { get; set; }

        public bool EmailAuth { get; set; }


        public string MobilePhone { get; set; }

        public bool MobilePhoneAuth { get; set; }

        public string Password { get; set; }

        public string QQ { get; set; }


        public string WeChat { get; set; }


        public DateTime LastLoginTime { get; set; }

        public Guid ImageId { get; set; }

        public bool Locked { get; set; }

        public bool Deleted { get; set; }

        public DateTime? CreateTime { get; set; }

        public Guid? CreateUserId { get; set; }

        public DateTime? LastUpdateTime { get; set; }

        public Guid? UpdateUserId { get; set; }

        public string NumberAttribution { get; set; }

        public Guid? PartnerID { get; set; }
        public int? ImgId { get; set; }

        public string WeChatOpenId { get; set; }

        public DateTime? DeleteTime { get; set; }

        public Guid? StoreID { get; set; }

        public int Gender { get; set; }

    }
}
