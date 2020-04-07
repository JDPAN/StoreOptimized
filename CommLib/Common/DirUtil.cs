using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

#region - 版权信息
/************************************************
*公司：楠迪科技 
*作者: Benn.zhu
*创建时间 2019/6/5 17:57:37
*版本: 0.0.1
*描述:
*
*更新历史:
*
***********************************************/
#endregion
namespace CommLib
{
    public  class DirUtil
    {
        public static string GetCurrentDir()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}
