using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAHHnetStore.Model
{
    /// <summary>
    /// 发料表
    /// </summary>
    public class wois
    {
        /// <summary>
        /// 工单号
        /// </summary>
        public string wo { get; set; }

        /// <summary>
        /// 项号
        /// </summary>
        public string wi { get; set; }

        /// <summary>
        /// 产品编码
        /// </summary>
        public string bn { get; set; }

        /// <summary>
        ///BOM数量 
        /// </summary>
        public decimal bn_qty { get; set; }

        /// <summary>
        /// 零件编号
        /// </summary>
        public string bi { get; set; }

        /// <summary>
        /// 零件料号
        /// </summary>
        public string pn { get; set; }

        /// <summary>
        /// 物料描述
        /// </summary>
        public string pndes { get; set; }

        /// <summary>
        /// 需求数量
        /// </summary>
        public decimal qty { get; set; }

        /// <summary>
        /// 已发数量
        /// </summary>
        public decimal isu { get; set; }
    }
}
