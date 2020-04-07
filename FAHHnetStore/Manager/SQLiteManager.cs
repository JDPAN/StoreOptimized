using CommLib.Db;
using FAHHnetStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAHHnetStore.Manager
{
    public class SQLiteManager
    {
        /// <summary>
        /// 新增或更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(Pn_Unit model)
        {
            SQLiteDbHelper sqlite = new SQLiteDbHelper();
            //查询是否有此数据，有则更新
            string where = string.Format("pn='{0}'", model.pn);
            var isHave = sqlite.QeryByWhere<Pn_Unit>(where, new string[] { "*" });
            int row = 0;
            if (isHave != null)
            {
                row = sqlite.Edit(model, where, new string[] { "minUnit" });

            }
            else
            {
                row = sqlite.Add(model);
            }
            sqlite.Dispose();
            return row > 0 ? true : false;
        }

        /// <summary>
        /// 查询所有列表
        /// </summary>
        /// <returns></returns>
        public List<Pn_Unit> GetAllList()
        {
            SQLiteDbHelper sqlite = new SQLiteDbHelper();
            string where = string.Format("id>0 order by id desc");
            var list = sqlite.QueryMultiByWhere<Pn_Unit>(where);
            sqlite.Dispose();
            return list;
        }

        /// <summary>
        /// 按料号查询单个实体
        /// </summary>
        /// <param name="pn"></param>
        /// <returns></returns>
        public List<Pn_Unit> Get(string pn)
        {
            SQLiteDbHelper sqlite = new SQLiteDbHelper();
            string where = string.Format("pn='{0}'", pn);
            var isHave = sqlite.QeryByWhere<Pn_Unit>(where, new string[] { "*" });
            sqlite.Dispose();
            if (isHave == null)
            {
                return null;
            }
            else
            {
                List<Pn_Unit> list = new List<Pn_Unit>();
                list.Add(isHave);
                return list;
            }

        }

        /// <summary>
        /// 多料号查询实体列表
        /// </summary>
        /// <returns></returns>
        public List<Pn_Unit> GetListByPns(List<string> pns)
        {
            SQLiteDbHelper sqlite = new SQLiteDbHelper();
            string where = string.Format("pn in ('{0}')", string.Join("','", pns));
            var list = sqlite.QueryMultiByWhere<Pn_Unit>(where);
            sqlite.Dispose();
            return list;
        }

        /// <summary>
        /// 删除料号最小包装
        /// </summary>
        /// <param name="pn"></param>
        /// <returns></returns>
        public bool DelPnUnit(string pn)
        {
            SQLiteDbHelper sqlite = new SQLiteDbHelper();
            string tablename = "pn_unit";
            string where = string.Format("pn='{0}'", pn);
            int row = sqlite.Delete(tablename, where);
            sqlite.Dispose();
            if (row > 0)
                return true;
            else
                return false;
        }


    }
}
