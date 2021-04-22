using System;
using System.Collections.Generic;
using System.Text;

namespace HemNetCore.Model.ViewModel
{
    public class UserSessionVModel
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public Guid? RoleId { get; set; }

        /// <summary>
        /// 分公司ID
        /// </summary>
        public Guid PartnerId { get; set; }

        /// <summary>
        /// 门店ID
        /// </summary>
        public Guid? StoreId { get; set; }

        /// <summary>
        /// 组织ID
        /// </summary>
        public Guid? OrganizationID { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 是否E家政
        /// </summary>
        public bool IsEjz { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsAdministrator { get; set; }

        /// <summary>
        /// 菜单ID
        /// </summary>
        public Guid? MenuId { get; set; }

        /// <summary>
        /// 登录手机号
        /// </summary>
        public string LoginName { get; set; }


        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime OperatorTime { get; set; }
    }
}
