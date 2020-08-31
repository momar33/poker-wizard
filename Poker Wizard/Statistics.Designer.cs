using System.Windows.Forms;

namespace Poker_Wizard
{
    partial class FrmStatistics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlStatistics = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControlType = new System.Windows.Forms.TabControl();
            this.tabPremade = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMinGamesPlayedPremade = new System.Windows.Forms.Label();
            this.dtpEndPremade = new System.Windows.Forms.DateTimePicker();
            this.lblDateRangePremade = new System.Windows.Forms.Label();
            this.dtpStartPremade = new System.Windows.Forms.DateTimePicker();
            this.tbMinGamesPlayedPremade = new System.Windows.Forms.TextBox();
            this.btnSubmitPremade = new System.Windows.Forms.Button();
            this.cbDropLowest = new System.Windows.Forms.CheckBox();
            this.tabCustom = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMinGamesPlayed = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.gbGraphTable = new System.Windows.Forms.GroupBox();
            this.rbTable = new System.Windows.Forms.RadioButton();
            this.rbGraph = new System.Windows.Forms.RadioButton();
            this.gbIndividualGroup = new System.Windows.Forms.GroupBox();
            this.rbGroup = new System.Windows.Forms.RadioButton();
            this.rbIndividual = new System.Windows.Forms.RadioButton();
            this.lblLocation = new System.Windows.Forms.Label();
            this.cbLocation = new System.Windows.Forms.ComboBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblPlayerOrGroup = new System.Windows.Forms.Label();
            this.tbMinGamesPlayed = new System.Windows.Forms.TextBox();
            this.lbNames = new System.Windows.Forms.ListBox();
            this.btnSubmitCustom = new System.Windows.Forms.Button();
            this.pnlData = new System.Windows.Forms.Panel();
            this.tabControlCustom = new System.Windows.Forms.TabControl();
            this.tabControlPremade = new System.Windows.Forms.TabControl();
            this.pnlStatistics.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControlType.SuspendLayout();
            this.tabPremade.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabCustom.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gbGraphTable.SuspendLayout();
            this.gbIndividualGroup.SuspendLayout();
            this.pnlData.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlStatistics
            // 
            this.pnlStatistics.Controls.Add(this.tableLayoutPanel1);
            this.pnlStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatistics.Location = new System.Drawing.Point(0, 0);
            this.pnlStatistics.Name = "pnlStatistics";
            this.pnlStatistics.Size = new System.Drawing.Size(1234, 561);
            this.pnlStatistics.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tabControlType, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlData, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1234, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tabControlType
            // 
            this.tabControlType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlType.Controls.Add(this.tabPremade);
            this.tabControlType.Controls.Add(this.tabCustom);
            this.tabControlType.Location = new System.Drawing.Point(3, 3);
            this.tabControlType.Name = "tabControlType";
            this.tabControlType.SelectedIndex = 0;
            this.tabControlType.Size = new System.Drawing.Size(194, 555);
            this.tabControlType.TabIndex = 1;
            this.tabControlType.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControlType_Selected);
            this.tabControlType.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TabControlType_KeyUp);
            // 
            // tabPremade
            // 
            this.tabPremade.Controls.Add(this.tableLayoutPanel3);
            this.tabPremade.Location = new System.Drawing.Point(4, 22);
            this.tabPremade.Name = "tabPremade";
            this.tabPremade.Padding = new System.Windows.Forms.Padding(3);
            this.tabPremade.Size = new System.Drawing.Size(186, 529);
            this.tabPremade.TabIndex = 0;
            this.tabPremade.Text = "Premade";
            this.tabPremade.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.lblMinGamesPlayedPremade, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.dtpEndPremade, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblDateRangePremade, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.dtpStartPremade, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tbMinGamesPlayedPremade, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.btnSubmitPremade, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.cbDropLowest, 0, 5);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(180, 523);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // lblMinGamesPlayedPremade
            // 
            this.lblMinGamesPlayedPremade.AutoSize = true;
            this.lblMinGamesPlayedPremade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMinGamesPlayedPremade.Location = new System.Drawing.Point(5, 80);
            this.lblMinGamesPlayedPremade.Margin = new System.Windows.Forms.Padding(5);
            this.lblMinGamesPlayedPremade.Name = "lblMinGamesPlayedPremade";
            this.lblMinGamesPlayedPremade.Size = new System.Drawing.Size(170, 15);
            this.lblMinGamesPlayedPremade.TabIndex = 8;
            this.lblMinGamesPlayedPremade.Text = "Min Games Played";
            this.lblMinGamesPlayedPremade.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dtpEndPremade
            // 
            this.dtpEndPremade.CustomFormat = "MM/dd/yyyy";
            this.dtpEndPremade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpEndPremade.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndPremade.Location = new System.Drawing.Point(3, 53);
            this.dtpEndPremade.Name = "dtpEndPremade";
            this.dtpEndPremade.Size = new System.Drawing.Size(174, 20);
            this.dtpEndPremade.TabIndex = 3;
            // 
            // lblDateRangePremade
            // 
            this.lblDateRangePremade.AutoSize = true;
            this.lblDateRangePremade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDateRangePremade.Location = new System.Drawing.Point(5, 5);
            this.lblDateRangePremade.Margin = new System.Windows.Forms.Padding(5);
            this.lblDateRangePremade.Name = "lblDateRangePremade";
            this.lblDateRangePremade.Size = new System.Drawing.Size(170, 15);
            this.lblDateRangePremade.TabIndex = 5;
            this.lblDateRangePremade.Text = "Date Range";
            this.lblDateRangePremade.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dtpStartPremade
            // 
            this.dtpStartPremade.CustomFormat = "MM/dd/yyyy";
            this.dtpStartPremade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpStartPremade.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartPremade.Location = new System.Drawing.Point(3, 28);
            this.dtpStartPremade.Name = "dtpStartPremade";
            this.dtpStartPremade.Size = new System.Drawing.Size(174, 20);
            this.dtpStartPremade.TabIndex = 2;
            this.dtpStartPremade.Value = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            // 
            // tbMinGamesPlayedPremade
            // 
            this.tbMinGamesPlayedPremade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMinGamesPlayedPremade.Location = new System.Drawing.Point(3, 103);
            this.tbMinGamesPlayedPremade.Name = "tbMinGamesPlayedPremade";
            this.tbMinGamesPlayedPremade.Size = new System.Drawing.Size(174, 20);
            this.tbMinGamesPlayedPremade.TabIndex = 4;
            this.tbMinGamesPlayedPremade.Text = "1";
            this.tbMinGamesPlayedPremade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbMinGamesPlayedPremade_KeyPress);
            // 
            // btnSubmitPremade
            // 
            this.btnSubmitPremade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSubmitPremade.Location = new System.Drawing.Point(3, 158);
            this.btnSubmitPremade.Name = "btnSubmitPremade";
            this.btnSubmitPremade.Size = new System.Drawing.Size(174, 24);
            this.btnSubmitPremade.TabIndex = 6;
            this.btnSubmitPremade.Text = "Submit";
            this.btnSubmitPremade.UseVisualStyleBackColor = true;
            this.btnSubmitPremade.Click += new System.EventHandler(this.BtnSubmitPremade_Click);
            // 
            // cbDropLowest
            // 
            this.cbDropLowest.AutoSize = true;
            this.cbDropLowest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDropLowest.Location = new System.Drawing.Point(10, 128);
            this.cbDropLowest.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.cbDropLowest.Name = "cbDropLowest";
            this.cbDropLowest.Size = new System.Drawing.Size(167, 24);
            this.cbDropLowest.TabIndex = 5;
            this.cbDropLowest.Text = "Drop Lowest 2 Games";
            this.cbDropLowest.UseVisualStyleBackColor = true;
            // 
            // tabCustom
            // 
            this.tabCustom.Controls.Add(this.tableLayoutPanel2);
            this.tabCustom.Controls.Add(this.btnSubmitCustom);
            this.tabCustom.Location = new System.Drawing.Point(4, 22);
            this.tabCustom.Name = "tabCustom";
            this.tabCustom.Padding = new System.Windows.Forms.Padding(3);
            this.tabCustom.Size = new System.Drawing.Size(186, 529);
            this.tabCustom.TabIndex = 1;
            this.tabCustom.Text = "Custom";
            this.tabCustom.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lblMinGamesPlayed, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.dtpEnd, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.lblDateRange, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.gbGraphTable, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.gbIndividualGroup, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblLocation, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cbLocation, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.dtpStart, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.lblPlayerOrGroup, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.tbMinGamesPlayed, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.lbNames, 0, 10);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 11;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(180, 500);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblMinGamesPlayed
            // 
            this.lblMinGamesPlayed.AutoSize = true;
            this.lblMinGamesPlayed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMinGamesPlayed.Location = new System.Drawing.Point(5, 250);
            this.lblMinGamesPlayed.Margin = new System.Windows.Forms.Padding(5);
            this.lblMinGamesPlayed.Name = "lblMinGamesPlayed";
            this.lblMinGamesPlayed.Size = new System.Drawing.Size(170, 15);
            this.lblMinGamesPlayed.TabIndex = 8;
            this.lblMinGamesPlayed.Text = "Min Games Played";
            this.lblMinGamesPlayed.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "MM/dd/yyyy";
            this.dtpEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(3, 223);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(174, 20);
            this.dtpEnd.TabIndex = 4;
            // 
            // lblDateRange
            // 
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDateRange.Location = new System.Drawing.Point(5, 175);
            this.lblDateRange.Margin = new System.Windows.Forms.Padding(5);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(170, 15);
            this.lblDateRange.TabIndex = 5;
            this.lblDateRange.Text = "Date Range";
            this.lblDateRange.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // gbGraphTable
            // 
            this.gbGraphTable.Controls.Add(this.rbTable);
            this.gbGraphTable.Controls.Add(this.rbGraph);
            this.gbGraphTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbGraphTable.Enabled = false;
            this.gbGraphTable.Location = new System.Drawing.Point(3, 63);
            this.gbGraphTable.Name = "gbGraphTable";
            this.gbGraphTable.Size = new System.Drawing.Size(174, 54);
            this.gbGraphTable.TabIndex = 1;
            this.gbGraphTable.TabStop = false;
            // 
            // rbTable
            // 
            this.rbTable.AutoSize = true;
            this.rbTable.Checked = true;
            this.rbTable.Location = new System.Drawing.Point(12, 33);
            this.rbTable.Name = "rbTable";
            this.rbTable.Size = new System.Drawing.Size(52, 17);
            this.rbTable.TabIndex = 1;
            this.rbTable.TabStop = true;
            this.rbTable.Text = "Table";
            this.rbTable.UseVisualStyleBackColor = true;
            // 
            // rbGraph
            // 
            this.rbGraph.AutoSize = true;
            this.rbGraph.Location = new System.Drawing.Point(12, 11);
            this.rbGraph.Name = "rbGraph";
            this.rbGraph.Size = new System.Drawing.Size(54, 17);
            this.rbGraph.TabIndex = 0;
            this.rbGraph.TabStop = true;
            this.rbGraph.Text = "Graph";
            this.rbGraph.UseVisualStyleBackColor = true;
            // 
            // gbIndividualGroup
            // 
            this.gbIndividualGroup.Controls.Add(this.rbGroup);
            this.gbIndividualGroup.Controls.Add(this.rbIndividual);
            this.gbIndividualGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbIndividualGroup.Location = new System.Drawing.Point(3, 3);
            this.gbIndividualGroup.Name = "gbIndividualGroup";
            this.gbIndividualGroup.Size = new System.Drawing.Size(174, 54);
            this.gbIndividualGroup.TabIndex = 0;
            this.gbIndividualGroup.TabStop = false;
            // 
            // rbGroup
            // 
            this.rbGroup.AutoSize = true;
            this.rbGroup.Location = new System.Drawing.Point(12, 33);
            this.rbGroup.Name = "rbGroup";
            this.rbGroup.Size = new System.Drawing.Size(54, 17);
            this.rbGroup.TabIndex = 1;
            this.rbGroup.TabStop = true;
            this.rbGroup.Text = "Group";
            this.rbGroup.UseVisualStyleBackColor = true;
            this.rbGroup.CheckedChanged += new System.EventHandler(this.RbGroup_CheckedChanged);
            // 
            // rbIndividual
            // 
            this.rbIndividual.AutoSize = true;
            this.rbIndividual.Checked = true;
            this.rbIndividual.Location = new System.Drawing.Point(12, 11);
            this.rbIndividual.Name = "rbIndividual";
            this.rbIndividual.Size = new System.Drawing.Size(70, 17);
            this.rbIndividual.TabIndex = 0;
            this.rbIndividual.TabStop = true;
            this.rbIndividual.Text = "Individual";
            this.rbIndividual.UseVisualStyleBackColor = true;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLocation.Location = new System.Drawing.Point(5, 125);
            this.lblLocation.Margin = new System.Windows.Forms.Padding(5);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(170, 15);
            this.lblLocation.TabIndex = 3;
            this.lblLocation.Text = "Location";
            this.lblLocation.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cbLocation
            // 
            this.cbLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbLocation.FormattingEnabled = true;
            this.cbLocation.Location = new System.Drawing.Point(3, 148);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(174, 21);
            this.cbLocation.TabIndex = 2;
            this.cbLocation.Text = "All";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "MM/dd/yyyy";
            this.dtpStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(3, 198);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(174, 20);
            this.dtpStart.TabIndex = 3;
            this.dtpStart.Value = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            // 
            // lblPlayerOrGroup
            // 
            this.lblPlayerOrGroup.AutoSize = true;
            this.lblPlayerOrGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlayerOrGroup.Location = new System.Drawing.Point(5, 300);
            this.lblPlayerOrGroup.Margin = new System.Windows.Forms.Padding(5);
            this.lblPlayerOrGroup.Name = "lblPlayerOrGroup";
            this.lblPlayerOrGroup.Size = new System.Drawing.Size(170, 15);
            this.lblPlayerOrGroup.TabIndex = 2;
            this.lblPlayerOrGroup.Text = "Player or Group";
            this.lblPlayerOrGroup.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbMinGamesPlayed
            // 
            this.tbMinGamesPlayed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMinGamesPlayed.Enabled = false;
            this.tbMinGamesPlayed.Location = new System.Drawing.Point(3, 273);
            this.tbMinGamesPlayed.Name = "tbMinGamesPlayed";
            this.tbMinGamesPlayed.Size = new System.Drawing.Size(174, 20);
            this.tbMinGamesPlayed.TabIndex = 5;
            this.tbMinGamesPlayed.Text = "1";
            this.tbMinGamesPlayed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbMinGamesPlayed_KeyPress);
            // 
            // lbNames
            // 
            this.lbNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNames.FormattingEnabled = true;
            this.lbNames.Location = new System.Drawing.Point(3, 323);
            this.lbNames.Name = "lbNames";
            this.lbNames.Size = new System.Drawing.Size(174, 174);
            this.lbNames.TabIndex = 6;
            // 
            // btnSubmitCustom
            // 
            this.btnSubmitCustom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSubmitCustom.Location = new System.Drawing.Point(3, 503);
            this.btnSubmitCustom.Name = "btnSubmitCustom";
            this.btnSubmitCustom.Size = new System.Drawing.Size(180, 23);
            this.btnSubmitCustom.TabIndex = 11;
            this.btnSubmitCustom.Text = "Submit";
            this.btnSubmitCustom.UseVisualStyleBackColor = true;
            this.btnSubmitCustom.Click += new System.EventHandler(this.BtnSubmitCustom_Click);
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.tabControlCustom);
            this.pnlData.Controls.Add(this.tabControlPremade);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(203, 3);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(1028, 555);
            this.pnlData.TabIndex = 3;
            // 
            // tabControlCustom
            // 
            this.tabControlCustom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlCustom.ItemSize = new System.Drawing.Size(200, 18);
            this.tabControlCustom.Location = new System.Drawing.Point(0, 0);
            this.tabControlCustom.Name = "tabControlCustom";
            this.tabControlCustom.SelectedIndex = 0;
            this.tabControlCustom.Size = new System.Drawing.Size(1028, 555);
            this.tabControlCustom.TabIndex = 7;
            this.tabControlCustom.Visible = false;
            this.tabControlCustom.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TabControlCustom_MouseUp);
            // 
            // tabControlPremade
            // 
            this.tabControlPremade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPremade.Location = new System.Drawing.Point(0, 0);
            this.tabControlPremade.Name = "tabControlPremade";
            this.tabControlPremade.SelectedIndex = 0;
            this.tabControlPremade.Size = new System.Drawing.Size(1028, 555);
            this.tabControlPremade.TabIndex = 7;
            // 
            // FrmStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 561);
            this.Controls.Add(this.pnlStatistics);
            this.Name = "FrmStatistics";
            this.Text = "Statistics";
            this.Load += new System.EventHandler(this.FrmStatistics_Load);
            this.pnlStatistics.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControlType.ResumeLayout(false);
            this.tabPremade.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tabCustom.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.gbGraphTable.ResumeLayout(false);
            this.gbGraphTable.PerformLayout();
            this.gbIndividualGroup.ResumeLayout(false);
            this.gbIndividualGroup.PerformLayout();
            this.pnlData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlStatistics;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControlPremade;
        private System.Windows.Forms.TabControl tabControlType;
        private System.Windows.Forms.TabPage tabPremade;
        private System.Windows.Forms.TabPage tabCustom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblMinGamesPlayed;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.GroupBox gbGraphTable;
        private System.Windows.Forms.RadioButton rbTable;
        private System.Windows.Forms.RadioButton rbGraph;
        private System.Windows.Forms.GroupBox gbIndividualGroup;
        private System.Windows.Forms.RadioButton rbGroup;
        private System.Windows.Forms.RadioButton rbIndividual;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.ComboBox cbLocation;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblPlayerOrGroup;
        private System.Windows.Forms.TextBox tbMinGamesPlayed;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.ListBox lbNames;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblMinGamesPlayedPremade;
        private System.Windows.Forms.DateTimePicker dtpEndPremade;
        private System.Windows.Forms.Label lblDateRangePremade;
        private System.Windows.Forms.DateTimePicker dtpStartPremade;
        private System.Windows.Forms.TextBox tbMinGamesPlayedPremade;
        private System.Windows.Forms.Button btnSubmitPremade;
        private System.Windows.Forms.Button btnSubmitCustom;
        private System.Windows.Forms.TabControl tabControlCustom;
        private System.Windows.Forms.CheckBox cbDropLowest;
    }
}