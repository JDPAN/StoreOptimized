using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAHHnetStore.Model
{
    public class OrderModel
    {
        /// <summary>
        /// 工单号
        /// </summary>
        public string wo { get; set; }

        /// <summary>
        /// 项号
        /// </summary>
        public string wi { get; set; }

        //重写equals方法
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != typeof(OrderModel))
                return false;
            OrderModel order = obj as OrderModel;
            //按需求定制自己需要的比较方式
            return (this.wo == order.wo && this.wi == order.wi);
        }
    }
}
