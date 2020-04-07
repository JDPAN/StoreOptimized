using CommLib.Db;
using FAHHnetStore.Manager;
using FAHHnetStore.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FAHHnetStore
{
    public partial class Form1 : Form
    {
        DbManager db = new DbManager();
        StoreManager st = new StoreManager();
        SQLiteManager sqlite = new SQLiteManager();
        ExcelManager excel = new ExcelManager();

        public Form1()
        {
            InitializeComponent();
            //创建Sqlite数据库
            SQLiteBaseRepository.CreateDB("pn_UnitDb");
        }

        /// <summary>
        /// 添加工单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_add_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            var wi_list = comboBox_wi.GetSelectedItems();
            if (string.IsNullOrEmpty(OrderNoText.Text) || wi_list.Count == 0)
            {
                MessageBox.Show("工单号或项号不能为空！", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ///判定数据源是否中已有需要添加的项目，若有去重
                var bingdinglist = orderModelBindingSource.List;
                foreach (var wi in wi_list)
                {
                    OrderModel order = new OrderModel();
                    order.wo = OrderNoText.Text.Trim();
                    order.wi = wi;
                    if (bingdinglist.Contains(order))
                        continue;
                    bingdinglist.Add(order);
                }

                sendAllocModelBindingSource.DataSource = null;
                storeSumBindingSource.DataSource = null;
            }

        }

        /// <summary>
        /// 查询工单项号列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_SelectOrderNo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(OrderNoText.Text.Trim()))
            {
                MessageBox.Show("工单号不能为空！", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                label_State.Text = "查询中...";
                var wo = OrderNoText.Text.Trim();

                var list = db.GetWiInfoByWo(wo);
                if (list == null || list.Count() == 0)
                {
                    comboBox_wi.DataSource = null;
                    comboBox_wi.SetTextValue();
                    MessageBox.Show("未能获取该工单的项号列表！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    comboBox_wi.DataSource = list;
                    comboBox_wi.CancelSelectedItem();
                }
                label_State.Text = "就续";
            }
        }

        /// <summary>
        /// 发料运算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_calculate_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            sendAllocModelBindingSource.DataSource = null;
            storeSumBindingSource.DataSource = null;
            List<OrderModel> models = orderModelBindingSource.Cast<OrderModel>().ToList();
            if (models.Count == 0)
            {
                MessageBox.Show("工单数量为：0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            label_State.Text = "发料运算中...工单数量：" + models.Count;

            //发料集合
            var sendlist = db.GetWoisByAddData(models);

            //料号集合(去重)
            List<string> pns = sendlist.Select(x => x.pn).Distinct().ToList();
            //物料最小包装集合
            var minqtylist = sqlite.GetListByPns(pns);
            //库存集合
            var storelist = db.GetPt_Onhands(pns);

            //发料分配列表
            var alloclist = st.StoreAiFunc(sendlist, storelist, minqtylist);
            sendAllocModelBindingSource.DataSource = alloclist;
            //dgv_sendalloclist.DataSource = alloclist;
            label_State.Text = "运算完成...发料分配表记录数：" + alloclist.Count;
            //orderModelBindingSource.List.Clear();

            //发料汇总列表
            List<StoreSum> sumlist = st.StoreSumFunc(alloclist);
            //dgv_Sum.DataSource = alloclist;
            storeSumBindingSource.DataSource = sumlist;


        }

        /// <summary>
        /// 添加or更新物料最小包装数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_AddPnQty_Click(object sender, EventArgs e)
        {
            try
            {
                Pn_Unit pnUnit = new Pn_Unit()
                {
                    pn = textBox_PN.Text.Trim(),
                    minUnit = decimal.Parse(textBox_uQty.Text.Trim())
                };

                if (!string.IsNullOrEmpty(pnUnit.pn) && pnUnit.minUnit > 0)
                {
                    label_State.Text = "更新数据库中...";
                    if (!sqlite.Add(pnUnit))
                        MessageBox.Show("更新数据库失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    label_State.Text = "就续";
                }
                else
                {
                    MessageBox.Show("输入格式错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dgv_pnUqty.DataSource = sqlite.GetAllList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// 查找物料最小包装数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_FindPnUqty_Click(object sender, EventArgs e)
        {
            try
            {
                var pn = textBox_PN.Text.Trim();
                if (!string.IsNullOrEmpty(pn))
                {
                    label_State.Text = "查找中...";
                    var list = sqlite.Get(pn);
                    dgv_pnUqty.DataSource = list;
                    label_State.Text = "就续";
                    if (list == null)
                    {
                        MessageBox.Show("未找到此料号记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("输入格式错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// tabcontrol切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_State.Text = "加载界面数据中...";
            if (tabControl1.SelectedIndex == 0)
            {
                //添加工单页面
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                //工单汇总页面
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                //添加最小包装数量页面
                dgv_pnUqty.DataSource = sqlite.GetAllList();
            }
            label_State.Text = "就续";
        }

        /// <summary>
        /// 清空查询 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_clear_Click(object sender, EventArgs e)
        {
            textBox_PN.Text = null;
            textBox_uQty.Text = null;
            dgv_pnUqty.DataSource = sqlite.GetAllList();
        }

        /// <summary>
        /// 删除最小包装料号记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_delPnUnit_Click(object sender, EventArgs e)
        {
            string pn = textBox_PN.Text.Trim();
            if (!string.IsNullOrEmpty(pn))
            {
                if (sqlite.DelPnUnit(pn))
                {
                    label_State.Text = " PN：" + pn + "删除最小包装成功";
                    dgv_pnUqty.DataSource = sqlite.GetAllList();
                }
                else
                {
                    MessageBox.Show("删除失败，库无此料最小包装", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("料号为空，无法删除", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 发料分配表动态改变dgv行的颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_sendalloclist_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < dgv_sendalloclist.Rows.Count)
            {
                DataGridViewRow dgr = dgv_sendalloclist.Rows[e.RowIndex];
                try
                {
                    //总发料数量 小于需求数量  显示红色
                    if (decimal.Parse(dgr.Cells["totalisu"].Value.ToString()) < decimal.Parse(dgr.Cells["qty"].Value.ToString()))
                    {
                        dgr.DefaultCellStyle.ForeColor = Color.Red;
                        //dgr.Cells["totalisu"].Style.ForeColor = Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// 发料汇总表改变dgv行的颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Sum_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < dgv_Sum.Rows.Count)
            {
                DataGridViewRow dgr = dgv_Sum.Rows[e.RowIndex];
                try
                {
                    //总发料数量 小于需求数量  显示红色
                    if (decimal.Parse(dgr.Cells["totalisudataGridViewTextBoxColumn4"].Value.ToString()) < decimal.Parse(dgr.Cells["qtyDataGridViewTextBoxColumn"].Value.ToString()))
                    {
                        dgr.DefaultCellStyle.ForeColor = Color.Red;
                        //dgr.Cells["totalisu"].Style.ForeColor = Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// 导出发料分配表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ToAllocExcel_Click(object sender, EventArgs e)
        {
            List<SendAllocModel> alloclist = sendAllocModelBindingSource.Cast<SendAllocModel>().ToList();
            List<StoreSum> sumlist = storeSumBindingSource.Cast<StoreSum>().ToList();
            if (alloclist.Count > 0)
            {
                string path = excel.ToExcel(alloclist, sumlist);
                MessageBox.Show("路径：" + path, "导出成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("表格记录为空，无法导出！", "导出失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// 软件复位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_reset_Click(object sender, EventArgs e)
        {
            OrderNoText.Text = null;
            comboBox_wi.DataSource = null;
            comboBox_wi.SetTextValue();
            orderModelBindingSource.List.Clear();
            sendAllocModelBindingSource.DataSource = null;
            storeSumBindingSource.DataSource = null;
            tabControl1.SelectedIndex = 0;
        }
    }
}
