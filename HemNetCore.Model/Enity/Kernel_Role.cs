using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace HemNetCore.Model.Enity
{
    [SugarTable("Kernel_Role")]
   public class Kernel_Role
    {
        public Guid ID { get; set; }

        public string RoleName { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public bool? IsDeleted { get; set; }

        public Guid? CreateUserId { get; set; }


        public Guid? UpdateUserID { get; set; }

        public Guid? OrganizationID { get; set; }

        public Guid? PartnerID { get; set; }

        public bool? IsAdministrator { get; set; }

        public bool IsEjz { get; set; }

        public Guid? ParentID { get; set; }
    }
}
