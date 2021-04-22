using System;
using System.Collections.Generic;
using System.Text;

namespace HemNetCore.Model
{
    public class PagedParmDto
    {

        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// 每页总条数
        /// </summary>
        public int PageSize { get; set; } = 20;


        /// <summary>
        /// 排序字段
        /// </summary>
        public string OrderBy { get; set; }


        /// <summary>
        /// 排序方式，ASC或者 DESC
        /// </summary>
        public string Sort { get; set; }
    }
}
