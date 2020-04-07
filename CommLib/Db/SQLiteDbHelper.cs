using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

#region - 版权信息
/************************************************
*公司：楠迪科技 
*作者: Benn.zhu
*创建时间 2019/7/23 19:18:03
*版本: 0.0.1
*描述:
*
*更新历史:
*
***********************************************/
#endregion
namespace CommLib.Db
{
    public class SQLiteDbHelper : IDisposable
    {
        #region 属性
        private SQLiteConnection conn;

        /// <summary>
        /// 常量；
        /// </summary>
        const string INSERT_TABLE_ITEM_VALUE = "insert into {0} ({1}) values ({2})";
        const string DELETE_TABLE_WHERE = "delete from {0} where {1}";
        const string UPDATE_TABLE_EDITITEM = "update {0} set {1}";
        const string UPDATE_TABLE_EDITITEM_WHERE = "update {0} set {1} where {2}";
        const string Query_ITEM_TABLE_WHERE = "select {0} from {1} where {2}";


        #endregion

        public SQLiteDbHelper(string dbfile = "")
        {
            conn = Open(dbfile);
        }

        private SQLiteConnection Open(string file)
        {
            var conn = SQLiteBaseRepository.SimpleDbConnection(file);
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        #region 方法

        /// <summary>
        /// 执行Sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteSql(string sql)
        {
            return conn.Execute(sql);
        }
        /// <summary>
        /// 1.1 新增实体；
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="model">实体</param>
        /// <param name="autoPrimaryKey">自增主键名称</param>
        /// <returns></returns>
        public int Add<T>(T model, string autoPrimaryKey = "id")
        {

            var insertSql = GetInsertSql<T>(model, autoPrimaryKey);
            return conn.Execute(insertSql);

        }
        /// <summary>
        /// 批量新增
        /// </summary>
        /// <typeparam name="T">实休类</typeparam>
        /// <param name="addData">实体数据列表</param>
        /// <param name="autoPrimaryKey">自增主键名称</param>
        /// <returns></returns>
        public int Adds<T>(List<T> models, string autoPrimaryKey = "id")
        {
            var type = typeof(T);
            int resultN = 0;
            var transaction = conn.BeginTransaction();
            try
            {
                models.ForEach(d =>
                {
                    var insertSql = GetInsertSql<T>(d);
                    resultN += conn.Execute(insertSql);
                });
                transaction.Commit();
            }
            catch (Exception)
            {
                resultN = 0;
                transaction.Rollback();
            }
            return resultN;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="where">删除条件</param>
        /// <returns></returns>
        public int Delete<T>(string where)
        {
            var type = typeof(T);
            string sqlStr = string.Format(DELETE_TABLE_WHERE, type.Name, where);
            return conn.Execute(sqlStr);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string tableName, string where)
        {
            string sqlStr = string.Format(DELETE_TABLE_WHERE, tableName, where);
            return conn.Execute(sqlStr);
        }
        /// <summary>
        /// 修改; 
        /// </summary>
        /// <typeparam name="T">实体 Type </typeparam>
        /// <param name="model">实体</param>
        /// <param name="where">修改条件</param>
        /// <param name="attrs">要修改的实休属性数组</param>
        /// <returns></returns>
        public int Edit<T>(T model, string where, params string[] attrs)
        {
            var sqlStr = GetUpdateSql<T>(model, where, attrs);
            return conn.Execute(sqlStr);
        }

        /// <summary>
        /// 根据条件查询单一实体;
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="where">查询条件；</param>
        /// <param name="attrs">要查询的字段(传入 * 为查询所有字段。)</param>
        /// <returns></returns>
        public T QeryByWhere<T>(string where, params string[] attrs)
        {
            Type type = typeof(T);

            string item = attrs.Length == 1 && attrs[0] == "*" ? "*" : string.Join(",", attrs);
            var sqlStr = string.Format(Query_ITEM_TABLE_WHERE, item, type.Name, where);
            return conn.Query<T>(sqlStr).FirstOrDefault();
        }

        /// <summary>
        /// 根据条件查询符合条件的所有实体;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<T> QueryMultiByWhere<T>(string where)
        {
            Type type = typeof(T);
            var sqlStr = string.Format(Query_ITEM_TABLE_WHERE, "*", type.Name, where);
            return conn.Query<T>(sqlStr).ToList();
        }

        /// <summary>
        /// 生成新增 sql 语句；
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="autoPrimaryKey"></param>
        /// <returns></returns>
        private string GetInsertSql<T>(T model, string autoPrimaryKey = "id")
        {
            Type t = typeof(T);
            var propertyInfo = t.GetProperties();
            var proDic = propertyInfo.Where(s => !s.Name.Equals(autoPrimaryKey, StringComparison.InvariantCultureIgnoreCase))
                .Select(s => new
                {
                    key = s.Name,
                    value = GetValue<T>(s, model)
                })
                .ToDictionary(s => s.key, s => s.value);
            proDic = proDic.Where(s => s.Value != "''").ToDictionary(s => s.Key, s => s.Value);
            var items = string.Join(",", proDic.Keys);
            var values = string.Join(",", proDic.Values);
            return string.Format(INSERT_TABLE_ITEM_VALUE, t.Name, items, values);
        }

        /// <summary>
        /// 获取属性值；
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="info">字段属性信息</param>
        /// <param name="model">实体</param>
        /// <returns></returns>
        private string GetValue<T>(PropertyInfo info, T model)
        {
            Type type = info.PropertyType;
            var tempStr = string.Empty;
            if (type == typeof(string))
            {
                tempStr = string.Format("'{0}'", info.GetValue(model));
                return tempStr;
            }
            if (type == typeof(DateTime))
            {
                tempStr = string.Format("'{0}'", ((DateTime)info.GetValue(model)).ToString("s"));
                return tempStr;
            }
            if (type.BaseType == typeof(Enum))
            {
                tempStr = string.Format("{0}", (int)info.GetValue(model));
                return tempStr;
            }
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                var types = type.GetGenericArguments();
                if (types[0] == typeof(DateTime))
                {
                    tempStr = string.Format("'{0}'", ((DateTime)info.GetValue(model)).ToString("s"));
                }
                tempStr = string.Format("'{0}'", info.GetValue(model));
                return tempStr;
            }
            tempStr = info.GetValue(model).ToString();
            return tempStr;
        }

        /// <summary>
        /// 生成更新 sql 语句；
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="pro"></param>
        /// <param name="attrs"></param>
        /// <returns></returns>
        private string GetUpdateSql<T>(T model, string where, params string[] attrs)
        {
            Type t = typeof(T);
            var propertyInfo = t.GetProperties();
            var updateInfo = propertyInfo
                .Where(s => attrs.Contains(s.Name))
                .Select(s =>
                {
                    if (s.PropertyType == typeof(string))
                    {
                        return string.Format("{0}='{1}'", s.Name, s.GetValue(model));
                    }
                    if (s.PropertyType == typeof(DateTime))
                    {
                        return string.Format("{0}='{1}'", s.Name, ((DateTime)s.GetValue(model)).ToString("s"));
                    }
                    if (s.PropertyType.BaseType == typeof(Enum))
                    {
                        return string.Format("{0}={1}", s.Name, (int)s.GetValue(model));

                    }
                    if (s.PropertyType.IsGenericType && s.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        Type[] types = s.PropertyType.GetGenericArguments();
                        if (types[0] == typeof(DateTime))
                        {
                            return string.Format("{0}='{1}'", s.Name, ((DateTime)s.GetValue(model)).ToString("s"));
                        }
                        return string.Format("{0}={1}", s.Name, s.GetValue(model));
                    }
                    return string.Format("{0}={1}", s.Name, s.GetValue(model));
                })
                .ToArray();
            var setStr = string.Join(",", updateInfo);
            var sqlStr = string.Format(UPDATE_TABLE_EDITITEM_WHERE, t.Name, setStr, where);
            return sqlStr;
        }

        public void Dispose()
        {
            conn.Close();
            conn.Dispose();
        }


        #endregion
    }


    public class SQLiteBaseRepository
    {

        public static string connString = string.Empty;
        public static string DbFile
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pn_UnitDb.db");
            }
        }
        public static SQLiteConnection SimpleDbConnection(string dbFile)
        {
            if (string.IsNullOrEmpty(dbFile))
            {

                connString = string.Format("Data Source={0}", DbFile);
                return new SQLiteConnection(connString);
            }
            else
            {
                string connStr = string.Format("Data Source={0}", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dbFile));
                return new SQLiteConnection(connStr);
            }

        }


        /// <summary>
        /// 创建一个数据库文件。如果存在同名数据库文件，则会覆盖。
        /// </summary>
        /// <param name="dbName">数据库文件名。为null或空串时不创建。</param>
        /// <param name="password">（可选）数据库密码，默认为空。</param>
        /// <exception cref="Exception"></exception>
        public static string CreateDB(string dbName, string pass = "")
        {
            var path = string.Empty;
            if (!string.IsNullOrEmpty(dbName))
            {
                path = @".\" + dbName + ".db";
                try
                {
                    //判断文件是否存在
                    if(!File.Exists(path))
                    {
                        SQLiteConnection.CreateFile(path);
                        CreateNewTable(path, "pn_unit");
                    }

                    if (!string.IsNullOrEmpty(pass))
                    {
                        string connStr = string.Format("Data Source={0};Version={1}", dbName, 3);
                        using (SQLiteConnection connection = new SQLiteConnection(connStr))
                        {
                            connection.SetPassword(pass);
                            connString = string.Format("Data Source={0};Password={1};", dbName, pass);
                            connection.Close();
                        }
                    }
                }
                catch (Exception) { throw; }
            }
            return path;
        }

        /// <summary>
        /// 创建表
        /// </summary>
        /// <param name="dbPath">指定数据库文件</param>
        /// <param name="tableName">表名称</param>
        public static void CreateNewTable(string dbPath, string tableName)
        {
            if (!string.IsNullOrEmpty(dbPath) && !string.IsNullOrEmpty(tableName))
            {
                SQLiteDbHelper sqlite = new SQLiteDbHelper(dbPath);
                var sql= "CREATE TABLE " + tableName + "(id INTEGER PRIMARY KEY AUTOINCREMENT,pn varchar(50),minUnit decimal(20,4))";
                sqlite.ExecuteSql(sql);
                sqlite.Dispose();

                //using (SQLiteConnection sqliteConnection = new SQLiteConnection("data source=" + dbPath))
                //{
                //    if (sqliteConnection.State != System.Data.ConnectionState.Open)
                //    {
                //        sqliteConnection.Open();
                //        using (SQLiteCommand command = new SQLiteCommand())
                //        {
                //            command.Connection = sqliteConnection;

                //            //判断当前表是否存在
                //            command.CommandText = "SELECT COUNT(*) FROM sqlite_master where type='table' and name=" + "'" + tableName + "'" + ";";
                //            if (Convert.ToInt32(command.ExecuteScalar()) == 0)
                //            {
                //                command.CommandText = "CREATE TABLE " + tableName + "(pn varchar(50) PRIMARY KEY ,minUnit decimal(20,4))";
                //                command.ExecuteNonQuery();
                //            }
                //        }
                //    }
                //    sqliteConnection.Close();
                //}
            }
        }
    }
}
