using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

#region - 版权信息
/************************************************
*公司：楠迪科技 
*作者: Benn.zhu
*创建时间 2019/6/2 16:33:20
*版本: 0.0.1
*描述:
*
*更新历史:
*
***********************************************/
#endregion
namespace CommLib
{
    public  class FileUtil
    {
        public static string ReadFile(string filepath)
        {
            string fileContext = "";
            if(File.Exists(filepath))
            {
                FileStream fs = new FileStream(filepath,FileMode.Open);
                if (fs.CanRead)
                {
                    StreamReader sr = new StreamReader(fs);
                    fileContext = sr.ReadToEnd();
                    sr.Close();
                }
                fs.Close();
            }
            return fileContext;

        }


        public static bool WriteToFile(string path,string fileContext)
        {
            bool rel = false;

            FileStream fs = new FileStream(path, FileMode.Create);
            if(fs.CanWrite)
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(fileContext);
                sw.Close();
                rel = true;
            }
            fs.Close();
            return rel;
        }
    }
}
