﻿namespace FAHHnetStore
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.OrderNoLabel = new System.Windows.Forms.Label();
            this.OrderNoText = new System.Windows.Forms.TextBox();
            this.wi_label = new System.Windows.Forms.Label();
            this.button_SelectOrderNo = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.button_calculate = new System.Windows.Forms.Button();
            this.btn_ToAllocExcel = new System.Windows.Forms.Button();
            this.bt_reset = new System.Windows.Forms.Button();
            this.comboBox_wi = new UserControlDLL.ComCheckBoxList();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgv_Sum = new System.Windows.Forms.DataGridView();
            this.pnDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pndesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sw_onhand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mg_onhand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pt_onhand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalisudataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storeSumBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgv_sendalloclist = new System.Windows.Forms.DataGridView();
            this.wo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pndes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.swisu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mgisu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ptisu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalisu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sendAllocModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_addorder = new System.Windows.Forms.DataGridView();
            this.woDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_pnUqty = new System.Windows.Forms.DataGridView();
            this.pnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnUnitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.bt_delPnUnit = new System.Windows.Forms.Button();
            this.bt_clear = new System.Windows.Forms.Button();
            this.button_AddPnQty = new System.Windows.Forms.Button();
            this.button_FindPnUqty = new System.Windows.Forms.Button();
            this.textBox_uQty = new System.Windows.Forms.TextBox();
            this.textBox_PN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_State = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Sum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeSumBindingSource)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sendalloclist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sendAllocModelBindingSource)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_addorder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderModelBindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pnUqty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnUnitBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(1564, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 199F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 319F));
            this.tableLayoutPanel1.Controls.Add(this.OrderNoLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.OrderNoText, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.wi_label, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_SelectOrderNo, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_add, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_calculate, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_ToAllocExcel, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.bt_reset, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_wi, 4, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1505, 71);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // OrderNoLabel
            // 
            this.OrderNoLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.OrderNoLabel.AutoSize = true;
            this.OrderNoLabel.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OrderNoLabel.Location = new System.Drawing.Point(21, 24);
            this.OrderNoLabel.Margin = new System.Windows.Forms.Padding(5);
            this.OrderNoLabel.Name = "OrderNoLabel";
            this.OrderNoLabel.Size = new System.Drawing.Size(98, 22);
            this.OrderNoLabel.TabIndex = 2;
            this.OrderNoLabel.Text = "工单号：";
            this.OrderNoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OrderNoText
            // 
            this.OrderNoText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.OrderNoText.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OrderNoText.Location = new System.Drawing.Point(127, 21);
            this.OrderNoText.Name = "OrderNoText";
            this.OrderNoText.Size = new System.Drawing.Size(180, 29);
            this.OrderNoText.TabIndex = 1;
            // 
            // wi_label
            // 
            this.wi_label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.wi_label.AutoSize = true;
            this.wi_label.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wi_label.Location = new System.Drawing.Point(421, 24);
            this.wi_label.Name = "wi_label";
            this.wi_label.Size = new System.Drawing.Size(76, 22);
            this.wi_label.TabIndex = 4;
            this.wi_label.Text = "项号：";
            this.wi_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_SelectOrderNo
            // 
            this.button_SelectOrderNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_SelectOrderNo.Location = new System.Drawing.Point(313, 21);
            this.button_SelectOrderNo.Name = "button_SelectOrderNo";
            this.button_SelectOrderNo.Size = new System.Drawing.Size(82, 29);
            this.button_SelectOrderNo.TabIndex = 3;
            this.button_SelectOrderNo.Text = "获取项号";
            this.button_SelectOrderNo.UseVisualStyleBackColor = true;
            this.button_SelectOrderNo.Click += new System.EventHandler(this.button_SelectOrderNo_Click);
            // 
            // button_add
            // 
            this.button_add.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_add.Location = new System.Drawing.Point(703, 21);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(79, 29);
            this.button_add.TabIndex = 0;
            this.button_add.Text = "添加";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_calculate
            // 
            this.button_calculate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_calculate.Location = new System.Drawing.Point(790, 3);
            this.button_calculate.Name = "button_calculate";
            this.button_calculate.Size = new System.Drawing.Size(155, 65);
            this.button_calculate.TabIndex = 6;
            this.button_calculate.Text = "发料分配运算";
            this.button_calculate.UseVisualStyleBackColor = true;
            this.button_calculate.Click += new System.EventHandler(this.button_calculate_Click);
            // 
            // btn_ToAllocExcel
            // 
            this.btn_ToAllocExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ToAllocExcel.Location = new System.Drawing.Point(951, 3);
            this.btn_ToAllocExcel.Name = "btn_ToAllocExcel";
            this.btn_ToAllocExcel.Size = new System.Drawing.Size(133, 65);
            this.btn_ToAllocExcel.TabIndex = 7;
            this.btn_ToAllocExcel.Text = "导出发料Excel";
            this.btn_ToAllocExcel.UseVisualStyleBackColor = true;
            this.btn_ToAllocExcel.Click += new System.EventHandler(this.btn_ToAllocExcel_Click);
            // 
            // bt_reset
            // 
            this.bt_reset.Location = new System.Drawing.Point(1090, 3);
            this.bt_reset.Name = "bt_reset";
            this.bt_reset.Size = new System.Drawing.Size(133, 65);
            this.bt_reset.TabIndex = 9;
            this.bt_reset.Text = "复位";
            this.bt_reset.UseVisualStyleBackColor = true;
            this.bt_reset.Click += new System.EventHandler(this.bt_reset_Click);
            // 
            // comboBox_wi
            // 
            this.comboBox_wi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox_wi.DataSource = null;
            this.comboBox_wi.Location = new System.Drawing.Point(504, 23);
            this.comboBox_wi.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_wi.Name = "comboBox_wi";
            this.comboBox_wi.Size = new System.Drawing.Size(191, 25);
            this.comboBox_wi.TabIndex = 10;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabPage2.Controls.Add(this.dgv_Sum);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1556, 635);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "发料汇总";
            // 
            // dgv_Sum
            // 
            this.dgv_Sum.AllowUserToAddRows = false;
            this.dgv_Sum.AllowUserToDeleteRows = false;
            this.dgv_Sum.AutoGenerateColumns = false;
            this.dgv_Sum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Sum.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pnDataGridViewTextBoxColumn1,
            this.pndesDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.sw_onhand,
            this.dataGridViewTextBoxColumn1,
            this.mg_onhand,
            this.dataGridViewTextBoxColumn2,
            this.pt_onhand,
            this.dataGridViewTextBoxColumn3,
            this.totalisudataGridViewTextBoxColumn4});
            this.dgv_Sum.DataSource = this.storeSumBindingSource;
            this.dgv_Sum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Sum.Location = new System.Drawing.Point(0, 0);
            this.dgv_Sum.Name = "dgv_Sum";
            this.dgv_Sum.ReadOnly = true;
            this.dgv_Sum.RowTemplate.Height = 23;
            this.dgv_Sum.Size = new System.Drawing.Size(1556, 635);
            this.dgv_Sum.TabIndex = 0;
            this.dgv_Sum.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgv_Sum_RowPrePaint);
            // 
            // pnDataGridViewTextBoxColumn1
            // 
            this.pnDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pnDataGridViewTextBoxColumn1.DataPropertyName = "pn";
            this.pnDataGridViewTextBoxColumn1.HeaderText = "料号";
            this.pnDataGridViewTextBoxColumn1.Name = "pnDataGridViewTextBoxColumn1";
            this.pnDataGridViewTextBoxColumn1.ReadOnly = true;
            this.pnDataGridViewTextBoxColumn1.Width = 79;
            // 
            // pndesDataGridViewTextBoxColumn
            // 
            this.pndesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.pndesDataGridViewTextBoxColumn.DataPropertyName = "pndes";
            this.pndesDataGridViewTextBoxColumn.HeaderText = "物料描述";
            this.pndesDataGridViewTextBoxColumn.Name = "pndesDataGridViewTextBoxColumn";
            this.pndesDataGridViewTextBoxColumn.ReadOnly = true;
            this.pndesDataGridViewTextBoxColumn.Width = 123;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "qty";
            this.qtyDataGridViewTextBoxColumn.HeaderText = "需求数量";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtyDataGridViewTextBoxColumn.Width = 123;
            // 
            // sw_onhand
            // 
            this.sw_onhand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sw_onhand.DataPropertyName = "sw_onhand";
            this.sw_onhand.HeaderText = "SW库存";
            this.sw_onhand.Name = "sw_onhand";
            this.sw_onhand.ReadOnly = true;
            this.sw_onhand.Width = 101;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "swisu";
            this.dataGridViewTextBoxColumn1.HeaderText = "SW发料数量";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 145;
            // 
            // mg_onhand
            // 
            this.mg_onhand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.mg_onhand.DataPropertyName = "mg_onhand";
            this.mg_onhand.HeaderText = "MG库存";
            this.mg_onhand.Name = "mg_onhand";
            this.mg_onhand.ReadOnly = true;
            this.mg_onhand.Width = 101;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "mgisu";
            this.dataGridViewTextBoxColumn2.HeaderText = "MG发料数量";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 145;
            // 
            // pt_onhand
            // 
            this.pt_onhand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pt_onhand.DataPropertyName = "pt_onhand";
            this.pt_onhand.HeaderText = "PT库存";
            this.pt_onhand.Name = "pt_onhand";
            this.pt_onhand.ReadOnly = true;
            this.pt_onhand.Width = 101;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ptisu";
            this.dataGridViewTextBoxColumn3.HeaderText = "PT发料数量";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 145;
            // 
            // totalisudataGridViewTextBoxColumn4
            // 
            this.totalisudataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.totalisudataGridViewTextBoxColumn4.DataPropertyName = "totalisu";
            this.totalisudataGridViewTextBoxColumn4.HeaderText = "总发料数量";
            this.totalisudataGridViewTextBoxColumn4.Name = "totalisudataGridViewTextBoxColumn4";
            this.totalisudataGridViewTextBoxColumn4.ReadOnly = true;
            this.totalisudataGridViewTextBoxColumn4.Width = 145;
            // 
            // storeSumBindingSource
            // 
            this.storeSumBindingSource.DataSource = typeof(FAHHnetStore.Model.StoreSum);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabPage3.Controls.Add(this.panel5);
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Controls.Add(this.dgv_addorder);
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1556, 635);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "工单汇总";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgv_sendalloclist);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(286, 36);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1270, 599);
            this.panel5.TabIndex = 3;
            // 
            // dgv_sendalloclist
            // 
            this.dgv_sendalloclist.AllowUserToAddRows = false;
            this.dgv_sendalloclist.AllowUserToDeleteRows = false;
            this.dgv_sendalloclist.AutoGenerateColumns = false;
            this.dgv_sendalloclist.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_sendalloclist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sendalloclist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.wo,
            this.wi,
            this.pn,
            this.pndes,
            this.qty,
            this.swisu,
            this.mgisu,
            this.ptisu,
            this.totalisu});
            this.dgv_sendalloclist.DataSource = this.sendAllocModelBindingSource;
            this.dgv_sendalloclist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_sendalloclist.Location = new System.Drawing.Point(0, 0);
            this.dgv_sendalloclist.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.dgv_sendalloclist.Name = "dgv_sendalloclist";
            this.dgv_sendalloclist.ReadOnly = true;
            this.dgv_sendalloclist.RowTemplate.Height = 23;
            this.dgv_sendalloclist.Size = new System.Drawing.Size(1270, 599);
            this.dgv_sendalloclist.TabIndex = 2;
            this.dgv_sendalloclist.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgv_sendalloclist_RowPrePaint);
            // 
            // wo
            // 
            this.wo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.wo.DataPropertyName = "wo";
            this.wo.HeaderText = "工单号";
            this.wo.Name = "wo";
            this.wo.ReadOnly = true;
            this.wo.Width = 101;
            // 
            // wi
            // 
            this.wi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.wi.DataPropertyName = "wi";
            this.wi.HeaderText = "项号";
            this.wi.Name = "wi";
            this.wi.ReadOnly = true;
            this.wi.Width = 79;
            // 
            // pn
            // 
            this.pn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pn.DataPropertyName = "pn";
            this.pn.HeaderText = "物料号";
            this.pn.Name = "pn";
            this.pn.ReadOnly = true;
            this.pn.Width = 101;
            // 
            // pndes
            // 
            this.pndes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.pndes.DataPropertyName = "pndes";
            this.pndes.HeaderText = "物料描述";
            this.pndes.Name = "pndes";
            this.pndes.ReadOnly = true;
            this.pndes.Width = 123;
            // 
            // qty
            // 
            this.qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.qty.DataPropertyName = "qty";
            this.qty.HeaderText = "需求数量";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            this.qty.Width = 123;
            // 
            // swisu
            // 
            this.swisu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.swisu.DataPropertyName = "swisu";
            this.swisu.HeaderText = "SW发料数量";
            this.swisu.Name = "swisu";
            this.swisu.ReadOnly = true;
            this.swisu.Width = 145;
            // 
            // mgisu
            // 
            this.mgisu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.mgisu.DataPropertyName = "mgisu";
            this.mgisu.HeaderText = "MG发料数量";
            this.mgisu.Name = "mgisu";
            this.mgisu.ReadOnly = true;
            this.mgisu.Width = 145;
            // 
            // ptisu
            // 
            this.ptisu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ptisu.DataPropertyName = "ptisu";
            this.ptisu.HeaderText = "PT发料数量";
            this.ptisu.Name = "ptisu";
            this.ptisu.ReadOnly = true;
            this.ptisu.Width = 145;
            // 
            // totalisu
            // 
            this.totalisu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.totalisu.DataPropertyName = "totalisu";
            this.totalisu.HeaderText = "总发料数量";
            this.totalisu.Name = "totalisu";
            this.totalisu.ReadOnly = true;
            this.totalisu.Width = 145;
            // 
            // sendAllocModelBindingSource
            // 
            this.sendAllocModelBindingSource.DataSource = typeof(FAHHnetStore.Model.SendAllocModel);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(286, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1270, 36);
            this.panel4.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(573, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 28);
            this.label3.TabIndex = 3;
            this.label3.Text = "发料分配表";
            // 
            // dgv_addorder
            // 
            this.dgv_addorder.AllowUserToAddRows = false;
            this.dgv_addorder.AutoGenerateColumns = false;
            this.dgv_addorder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_addorder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_addorder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.woDataGridViewTextBoxColumn,
            this.wiDataGridViewTextBoxColumn});
            this.dgv_addorder.DataSource = this.orderModelBindingSource;
            this.dgv_addorder.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgv_addorder.Location = new System.Drawing.Point(0, 0);
            this.dgv_addorder.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.dgv_addorder.Name = "dgv_addorder";
            this.dgv_addorder.ReadOnly = true;
            this.dgv_addorder.RowTemplate.Height = 23;
            this.dgv_addorder.Size = new System.Drawing.Size(286, 635);
            this.dgv_addorder.TabIndex = 0;
            // 
            // woDataGridViewTextBoxColumn
            // 
            this.woDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.woDataGridViewTextBoxColumn.DataPropertyName = "wo";
            this.woDataGridViewTextBoxColumn.HeaderText = "工单号";
            this.woDataGridViewTextBoxColumn.Name = "woDataGridViewTextBoxColumn";
            this.woDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // wiDataGridViewTextBoxColumn
            // 
            this.wiDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.wiDataGridViewTextBoxColumn.DataPropertyName = "wi";
            this.wiDataGridViewTextBoxColumn.HeaderText = "项号";
            this.wiDataGridViewTextBoxColumn.Name = "wiDataGridViewTextBoxColumn";
            this.wiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderModelBindingSource
            // 
            this.orderModelBindingSource.DataSource = typeof(FAHHnetStore.Model.OrderModel);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(10, 110);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1564, 670);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1556, 635);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "添加物料最小包装";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_pnUqty);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(472, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1081, 629);
            this.panel3.TabIndex = 1;
            // 
            // dgv_pnUqty
            // 
            this.dgv_pnUqty.AllowUserToAddRows = false;
            this.dgv_pnUqty.AllowUserToDeleteRows = false;
            this.dgv_pnUqty.AutoGenerateColumns = false;
            this.dgv_pnUqty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_pnUqty.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pnDataGridViewTextBoxColumn,
            this.minUnitDataGridViewTextBoxColumn});
            this.dgv_pnUqty.DataSource = this.pnUnitBindingSource;
            this.dgv_pnUqty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_pnUqty.Location = new System.Drawing.Point(0, 0);
            this.dgv_pnUqty.Name = "dgv_pnUqty";
            this.dgv_pnUqty.ReadOnly = true;
            this.dgv_pnUqty.RowTemplate.Height = 23;
            this.dgv_pnUqty.Size = new System.Drawing.Size(1081, 629);
            this.dgv_pnUqty.TabIndex = 0;
            // 
            // pnDataGridViewTextBoxColumn
            // 
            this.pnDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pnDataGridViewTextBoxColumn.DataPropertyName = "pn";
            this.pnDataGridViewTextBoxColumn.HeaderText = "料号";
            this.pnDataGridViewTextBoxColumn.Name = "pnDataGridViewTextBoxColumn";
            this.pnDataGridViewTextBoxColumn.ReadOnly = true;
            this.pnDataGridViewTextBoxColumn.Width = 73;
            // 
            // minUnitDataGridViewTextBoxColumn
            // 
            this.minUnitDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.minUnitDataGridViewTextBoxColumn.DataPropertyName = "minUnit";
            this.minUnitDataGridViewTextBoxColumn.HeaderText = "最小包装数量";
            this.minUnitDataGridViewTextBoxColumn.Name = "minUnitDataGridViewTextBoxColumn";
            this.minUnitDataGridViewTextBoxColumn.ReadOnly = true;
            this.minUnitDataGridViewTextBoxColumn.Width = 113;
            // 
            // pnUnitBindingSource
            // 
            this.pnUnitBindingSource.DataSource = typeof(FAHHnetStore.Model.Pn_Unit);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bt_delPnUnit);
            this.panel2.Controls.Add(this.bt_clear);
            this.panel2.Controls.Add(this.button_AddPnQty);
            this.panel2.Controls.Add(this.button_FindPnUqty);
            this.panel2.Controls.Add(this.textBox_uQty);
            this.panel2.Controls.Add(this.textBox_PN);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(469, 629);
            this.panel2.TabIndex = 0;
            // 
            // bt_delPnUnit
            // 
            this.bt_delPnUnit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_delPnUnit.Location = new System.Drawing.Point(400, 43);
            this.bt_delPnUnit.Name = "bt_delPnUnit";
            this.bt_delPnUnit.Size = new System.Drawing.Size(63, 32);
            this.bt_delPnUnit.TabIndex = 7;
            this.bt_delPnUnit.Text = "删除";
            this.bt_delPnUnit.UseVisualStyleBackColor = true;
            this.bt_delPnUnit.Click += new System.EventHandler(this.bt_delPnUnit_Click);
            // 
            // bt_clear
            // 
            this.bt_clear.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_clear.Location = new System.Drawing.Point(334, 43);
            this.bt_clear.Name = "bt_clear";
            this.bt_clear.Size = new System.Drawing.Size(59, 32);
            this.bt_clear.TabIndex = 6;
            this.bt_clear.Text = "清空";
            this.bt_clear.UseVisualStyleBackColor = true;
            this.bt_clear.Click += new System.EventHandler(this.bt_clear_Click);
            // 
            // button_AddPnQty
            // 
            this.button_AddPnQty.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_AddPnQty.Location = new System.Drawing.Point(125, 148);
            this.button_AddPnQty.Name = "button_AddPnQty";
            this.button_AddPnQty.Size = new System.Drawing.Size(143, 77);
            this.button_AddPnQty.TabIndex = 5;
            this.button_AddPnQty.Text = "添加/更新";
            this.button_AddPnQty.UseVisualStyleBackColor = true;
            this.button_AddPnQty.Click += new System.EventHandler(this.button_AddPnQty_Click);
            // 
            // button_FindPnUqty
            // 
            this.button_FindPnUqty.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_FindPnUqty.Location = new System.Drawing.Point(274, 43);
            this.button_FindPnUqty.Name = "button_FindPnUqty";
            this.button_FindPnUqty.Size = new System.Drawing.Size(54, 32);
            this.button_FindPnUqty.TabIndex = 4;
            this.button_FindPnUqty.Text = "查询";
            this.button_FindPnUqty.UseVisualStyleBackColor = true;
            this.button_FindPnUqty.Click += new System.EventHandler(this.button_FindPnUqty_Click);
            // 
            // textBox_uQty
            // 
            this.textBox_uQty.Location = new System.Drawing.Point(125, 100);
            this.textBox_uQty.Name = "textBox_uQty";
            this.textBox_uQty.Size = new System.Drawing.Size(143, 32);
            this.textBox_uQty.TabIndex = 3;
            // 
            // textBox_PN
            // 
            this.textBox_PN.Location = new System.Drawing.Point(125, 43);
            this.textBox_PN.Name = "textBox_PN";
            this.textBox_PN.Size = new System.Drawing.Size(143, 32);
            this.textBox_PN.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "单位数量：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "PN：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label_State);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(10, 780);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1564, 21);
            this.panel1.TabIndex = 2;
            // 
            // label_State
            // 
            this.label_State.AutoSize = true;
            this.label_State.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_State.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_State.Location = new System.Drawing.Point(0, 9);
            this.label_State.Name = "label_State";
            this.label_State.Size = new System.Drawing.Size(29, 12);
            this.label_State.TabIndex = 0;
            this.label_State.Text = "就续";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1584, 811);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1366, 768);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "FAHHnetStore";
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Sum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeSumBindingSource)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sendalloclist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sendAllocModelBindingSource)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_addorder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderModelBindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pnUqty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnUnitBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox OrderNoText;
        private System.Windows.Forms.Label OrderNoLabel;
        private System.Windows.Forms.Button button_SelectOrderNo;
        private System.Windows.Forms.Label wi_label;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgv_addorder;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_State;
        private System.Windows.Forms.Button button_calculate;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_AddPnQty;
        private System.Windows.Forms.Button button_FindPnUqty;
        private System.Windows.Forms.TextBox textBox_uQty;
        private System.Windows.Forms.TextBox textBox_PN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgv_pnUqty;
        private System.Windows.Forms.Button bt_clear;
        private System.Windows.Forms.Button bt_delPnUnit;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgv_sendalloclist;
        private System.Windows.Forms.BindingSource orderModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn woDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wiDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource pnUnitBindingSource;
        private System.Windows.Forms.Button btn_ToAllocExcel;
        private System.Windows.Forms.DataGridView dgv_Sum;
        private System.Windows.Forms.BindingSource sendAllocModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn wo;
        private System.Windows.Forms.DataGridViewTextBoxColumn wi;
        private System.Windows.Forms.DataGridViewTextBoxColumn pn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pndes;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn swisu;
        private System.Windows.Forms.DataGridViewTextBoxColumn mgisu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ptisu;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalisu;
        private System.Windows.Forms.BindingSource storeSumBindingSource;
        private System.Windows.Forms.Button bt_reset;
        private System.Windows.Forms.DataGridViewTextBoxColumn pnDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pndesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sw_onhand;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mg_onhand;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn pt_onhand;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalisudataGridViewTextBoxColumn4;
        private UserControlDLL.ComCheckBoxList comboBox_wi;
        private System.Windows.Forms.DataGridViewTextBoxColumn pnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn minUnitDataGridViewTextBoxColumn;
    }
}

