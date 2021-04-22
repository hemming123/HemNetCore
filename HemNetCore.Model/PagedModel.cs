using System;
using System.Collections.Generic;
using System.Text;

namespace HemNetCore.Model
{
    /// <summary>
    /// 通用分页信息类
    /// </summary>
    public class PagedModel<T>
    {
        /// <summary>
        /// 当前页标
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// 总条数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 是否第一页
        /// </summary>
        public bool IsFirstPage => PageIndex == 1;

        /// <summary>
        /// 是否最后一页
        /// </summary>
        public bool IsLastPage => PageIndex == TotalPages || TotalPages == 0;

        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool IsNextPage => PageIndex + 1 < TotalPages;

        /// <summary>
        /// 返回分页数据
        /// </summary>
        public List<T> PageData { get; set; }
    }
}
