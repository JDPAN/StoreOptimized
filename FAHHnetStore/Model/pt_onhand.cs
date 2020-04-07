using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAHHnetStore.Model
{
    /// <summary>
    /// 库存表
    /// </summary>
    public class pt_onhand
    {
        /// <summary>
        /// 料号  
        /// </summary>
        public string pn { get; set; }

        /// <summary>
        /// 存储位置
        /// </summary>
        public string locate { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal onhand { get; set; }

        /// <summary>
        /// 库位
        /// </summary>
        public string whs { get; set; }
    }
}
