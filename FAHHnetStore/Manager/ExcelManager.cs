using FAHHnetStore.Model;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAHHnetStore.Manager
{
    /// <summary>
    /// 导出Excel工具类-EPPLUS
    /// </summary>
    public class ExcelManager
    {
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="alloclist"></param>
        /// <param name="pnSumList"></param>
        public string ToExcel(List<SendAllocModel> alloclist, List<StoreSum> pnSumList)
        {
            string sWebRootFolder = ConfigurationManager.AppSettings["SaveExcelAddr"];
            if (Directory.Exists(sWebRootFolder))
            {

            }
            else
            {
                Directory.CreateDirectory(sWebRootFolder);
            }

            string sFileName = string.Format("发料分配表_{0}.xlsx", DateTime.Now.ToString("yyyyMMdd_HHmmss"));
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            file.Delete();
            using (ExcelPackage package = new ExcelPackage(file))
            {
                //添加allocsheet
                ExcelWorksheet allocsheet = package.Workbook.Worksheets.Add("发料分配");

                //添加表头
                allocsheet.Cells[1, 1].Value = "工单号";
                allocsheet.Cells[1, 2].Value = "项号";
                allocsheet.Cells[1, 3].Value = "物料号";
                allocsheet.Cells[1, 4].Value = "物料描述";
                allocsheet.Cells[1, 5].Value = "需求数量";
                allocsheet.Cells[1, 6].Value = "SW发料数量";
                allocsheet.Cells[1, 7].Value = "MG发料数量";
                allocsheet.Cells[1, 8].Value = "PT发料数量";
                allocsheet.Cells[1, 9].Value = "总发料数量";

                for (int i = 2; i <= alloclist.Count + 1; i++)
                {
                    //自动列宽
                    allocsheet.Cells.AutoFitColumns();
                    allocsheet.Cells["A" + i].Value = alloclist[i - 2].wo;
                    allocsheet.Cells["B" + i].Value = alloclist[i - 2].wi;
                    allocsheet.Cells["C" + i].Value = alloclist[i - 2].pn;
                    allocsheet.Cells["D" + i].Value = alloclist[i - 2].pndes;
                    allocsheet.Cells["E" + i].Value = alloclist[i - 2].qty;
                    allocsheet.Cells["F" + i].Value = alloclist[i - 2].swisu;
                    allocsheet.Cells["G" + i].Value = alloclist[i - 2].mgisu;
                    allocsheet.Cells["H" + i].Value = alloclist[i - 2].ptisu;
                    allocsheet.Cells["I" + i].Value = alloclist[i - 2].totalisu;
                    if (alloclist[i - 2].qty > alloclist[i - 2].totalisu)
                    {
                        allocsheet.Row(i).Style.Font.Color.SetColor(Color.Red);
                    }
                }
                //var allocborder = allocsheet.Cells.Style.Border;
                //allocborder.Bottom.Style = allocborder.Top.Style = allocborder.Left.Style = allocborder.Right.Style = ExcelBorderStyle.Thin;

                //添加allocsheet
                ExcelWorksheet sumsheet = package.Workbook.Worksheets.Add("发料汇总");

                //添加表头
                sumsheet.Cells[1, 1].Value = "物料号";
                sumsheet.Cells[1, 2].Value = "物料描述";
                sumsheet.Cells[1, 3].Value = "需求数量";
                sumsheet.Cells[1, 4].Value = "SW库存";
                sumsheet.Cells[1, 5].Value = "SW发料数量";
                sumsheet.Cells[1, 6].Value = "MG库存";
                sumsheet.Cells[1, 7].Value = "MG发料数量";
                sumsheet.Cells[1, 8].Value = "PT库存";
                sumsheet.Cells[1, 9].Value = "PT发料数量";
                sumsheet.Cells[1, 10].Value = "总发料数量";

                for (int i = 2; i <= pnSumList.Count + 1; i++)
                {
                    //自动列宽
                    sumsheet.Cells.AutoFitColumns();
                    sumsheet.Cells["A" + i].Value = pnSumList[i - 2].pn;
                    sumsheet.Cells["B" + i].Value = pnSumList[i - 2].pndes;
                    sumsheet.Cells["C" + i].Value = pnSumList[i - 2].qty;
                    sumsheet.Cells["D" + i].Value = pnSumList[i - 2].sw_onhand;
                    sumsheet.Cells["E" + i].Value = pnSumList[i - 2].swisu;
                    sumsheet.Cells["F" + i].Value = pnSumList[i - 2].mg_onhand;
                    sumsheet.Cells["G" + i].Value = pnSumList[i - 2].mgisu;
                    sumsheet.Cells["H" + i].Value = pnSumList[i - 2].pt_onhand;
                    sumsheet.Cells["I" + i].Value = pnSumList[i - 2].ptisu;
                    sumsheet.Cells["J" + i].Value = pnSumList[i - 2].totalisu;
                    if (pnSumList[i - 2].qty > pnSumList[i - 2].totalisu)
                    {
                        sumsheet.Row(i).Style.Font.Color.SetColor(Color.Red);
                    }
                }
                //var sumborder = sumsheet.Cells.Style.Border;
                //sumborder.Bottom.Style = sumborder.Top.Style = sumborder.Left.Style = sumborder.Right.Style = ExcelBorderStyle.Thin;
                //sumborder.Bottom.Color.SetColor(Color.Black);
                //sumborder.Top.Color.SetColor(Color.Black);
                //sumborder.Left.Color.SetColor(Color.Black);
                //sumborder.Right.Color.SetColor(Color.Black);
   

                package.Save();
                return sWebRootFolder + sFileName;
            }
            //return File(sFileName, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
        }
    }
}