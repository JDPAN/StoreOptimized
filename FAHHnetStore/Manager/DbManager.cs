using FAHHnetStore.DB;
using FAHHnetStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAHHnetStore.Manager
{
    public class DbManager
    {
        /// <summary>
        /// 根据工单号wo 获取项号信息wi
        /// </summary>
        /// <param name="wo"></param>
        /// <returns></returns>
        public IEnumerable<string> GetWiInfoByWo(string wo)
        {
            using (var db = new FAHHnetDbContext())
            {
                var records = db.Database.SqlQuery<string>($"select DISTINCT wi from wois where wo='{wo}'");
                if (!records.Any())
                {
                    return null;
                }
                return records.ToList();
            }
        }

        /// <summary>
        /// 根据添加工单号wo 项号wi 获取发料信息
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public List<wois> GetWoisByAddData(List<OrderModel> models)
        {
            using (var db = new FAHHnetDbContext())
            {
                List<wois> list = new List<wois>(); ;
                foreach (var item in models)
                {
                    var records = db.Database.SqlQuery<wois>($"select wo,wi,bn,bn_qty,bi,pn,qty,isu,description as pndes from wois where wo='{item.wo}' and wi='{item.wi}'");
                    if (records.Any())
                    {
                        list.AddRange(records.ToList());
                    }
                }
                return list;
            }
        }

        /// <summary>
        /// 获取工单所有料号库存
        /// </summary>
        /// <returns></returns>
        public List<pt_onhand> GetPt_Onhands(List<string> pns)
        {
            using (var db = new FAHHnetDbContext())
            {
                var records = db.Database.SqlQuery<pt_onhand>($"select pn,locate,onhand,whs from pt_onhand where pn in ('{string.Join("','", pns)}') and whs in ('SW','MG','PT')");
                if (!records.Any())
                {
                    return null;
                }
                return records.ToList();
            }
        }
    }
}
