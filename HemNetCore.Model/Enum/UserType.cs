using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HemNetCore.Model.Enum
{
    public enum UserType
    {
        /// <summary>
        /// 会员
        /// </summary>
        [Description("会员")]
        Member,
        /// <summary>
        /// 员工
        /// </summary>
        [Description("员工")]
        Admin,
        /// <summary>
        /// 服务员
        /// </summary>
        [Description("服务员")]
        Employee,
        /// <summary>
        /// 对公用户
        /// </summary>
        [Description("对公用户")]
        PublicUsers,
        /// <summary>
        /// 人力资源机构
        /// </summary>
        [Description("人力资源机构")]
        HumanResourcesInstitutions,

        /// <summary>
        /// 编外人员
        /// </summary>
        [Description("编外人员")]
        StaffMember
    }

}
