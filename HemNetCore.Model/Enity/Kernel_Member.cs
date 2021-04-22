using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace HemNetCore.Model.Enity
{
    /// <summary>
    /// 会员表
    /// </summary>
    [SugarTable("Kernel_Member")]
    public class Kernel_Member
    {
        [SugarColumn(IsPrimaryKey =true)]
        public Guid ID { get; set; }

        public Guid UserId { get; set; }

        public string IDCard { get; set; }

        public bool IDCardAuth { get; set; }

        public Guid RegionId { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int MemberLevel { get; set; }

        public decimal? RegInt { get; set; }

        public decimal? RegIat { get; set; }

        public bool VIP { get; set; }

        public DateTime? VIPActiveTime { get; set; }

        public bool Shareholder { get; set; }

        public DateTime? LastUpdateTime { get; set; }

        public Guid? UpdateUserId { get; set; }

        public Guid? PartnerId { get; set; }

        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 黑名单标志
        /// </summary>
        public bool IsBlacklist { get; set; }

        /// <summary>
        /// 设置黑名单时间
        /// </summary>
        public DateTime? SetBlacklistTime { get; set; }

        //设置黑名单人
        public Guid? SetBlacklistUserID { get; set; }

        /// <summary>
        /// 设置黑名单原因
        /// </summary>
        public string SetBlacklistReason { get; set; }


        /// <summary>
        /// 移除黑名单人
        /// </summary>
        public DateTime? RemoveBlacklistTime { get; set; }


        /// <summary>
        /// 移除黑名单时间
        /// </summary>
        public Guid? RemoveBlacklistUserID { get; set; }

        /// <summary>
        /// 移除黑名单原因
        /// </summary>
        public string RemoveBlacklistReason { get; set; }


        /// <summary>
        /// 是否调试
        /// </summary>
        public bool IsDebug { get; set; }

        /// <summary>
        /// 所属门店ID
        /// </summary>
        public Guid? StoreID { get; set; }


        /// <summary>
        /// VIP归属时间
        /// </summary>
        public DateTime? VIPAffiliationTime { get; set; }
        /// <summary>
        /// 是否股东
        /// </summary>
        public bool StockHolder { get; set; }
    }
}
