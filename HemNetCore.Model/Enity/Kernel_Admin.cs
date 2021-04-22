using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace HemNetCore.Model.Enity
{
    [SugarTable("Kernel_Admin")]
    public class Kernel_Admin
    {
        public Guid ID { get; set; }

        public Guid UserId { get; set; }

        public Guid PartnerId { get; set; }

        public Guid? RoleId { get; set; }

        public Guid? StoreID { get; set; }
    }
}
