using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace HemNetCore.Model.Enity
{
    [SugarTable("Kernel_Partner")]
    public class Kernel_Partner
    {
        public Guid ID { get; set; }

        public string PartnerName { get; set; }

        public string OrgCode { get; set; }

        public int Level { get; set; }

        public DateTime JoinTime { get; set; }

        public bool Deleted { get; set; }

        public DateTime? CreateTime { get; set; }

        public Guid? CreateUserId { get; set; }

        public DateTime? LastUpdateTime { get; set; }

        public Guid? UpdateUserId { get; set; }

        public Guid? ParentId { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public decimal? Longitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public decimal? Latitude { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        ///// <summary>
        ///// 合作形式
        ///// </summary>
        //public FormOfCooperation FormOfCooperation { get; set; }

        /// <summary>
        /// 营业执照
        /// </summary>
        public int? BusinessLicense { get; set; }

        /// <summary>
        /// 法人
        /// </summary>
        public string PartnerContacter { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string PartnerPhone { get; set; }

        /// <summary>
        /// 税号
        /// </summary>
        public string LicenseNumber { get; set; }

        /// <summary>
        /// 注册资本
        /// </summary>
        public decimal? RegisteredCapital { get; set; }

        /// <summary>
        /// 法人
        /// </summary>
        public string LegalPerson { get; set; }

        /// <summary>
        /// 保证金
        /// </summary>
        public decimal? Margin { get; set; }
    }
}
