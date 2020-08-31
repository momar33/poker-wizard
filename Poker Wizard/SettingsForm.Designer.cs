namespace Poker_Wizard
{
    partial class SettingsForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Bounties");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Blinds");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Round Length");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Starting Chips");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Rebuys");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Results Folder");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Game Locations");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Save Settings");
            this.btnSettingsApply = new System.Windows.Forms.Button();
            this.btnSettingsCancel = new System.Windows.Forms.Button();
            this.btnSettingsOK = new System.Windows.Forms.Button();
            this.gbBounties = new System.Windows.Forms.GroupBox();
            this.rbOnElimination = new System.Windows.Forms.RadioButton();
            this.rbOnRebuy = new System.Windows.Forms.RadioButton();
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.tcSettings = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gbBlinds = new System.Windows.Forms.GroupBox();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.rbAVISTA = new System.Windows.Forms.RadioButton();
            this.rbPDC = new System.Windows.Forms.RadioButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.nudMaxRoundLength = new System.Windows.Forms.NumericUpDown();
            this.nudRoundLength = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.gbRoundLengthType = new System.Windows.Forms.GroupBox();
            this.rbPerPlayer = new System.Windows.Forms.RadioButton();
            this.rbPerRound = new System.Windows.Forms.RadioButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.nudStartingChips = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.nudLastRebuyRound = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudBuyinCost = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tbSaveFolder = new System.Windows.Forms.TextBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnRemoveLocation = new System.Windows.Forms.Button();
            this.btnAddLocation = new System.Windows.Forms.Button();
            this.tbNewLocation = new System.Windows.Forms.TextBox();
            this.lbExistingLocations = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.tbSettingsName = new System.Windows.Forms.TextBox();
            this.tvSettings = new System.Windows.Forms.TreeView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.fbdSaveFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.gbBounties.SuspendLayout();
            this.tcSettings.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbBlinds.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxRoundLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoundLength)).BeginInit();
            this.gbRoundLengthType.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartingChips)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLastRebuyRound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBuyinCost)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettingsApply
            // 
            this.btnSettingsApply.Location = new System.Drawing.Point(492, 358);
            this.btnSettingsApply.Name = "btnSettingsApply";
            this.btnSettingsApply.Size = new System.Drawing.Size(75, 23);
            this.btnSettingsApply.TabIndex = 0;
            this.btnSettingsApply.Text = "Apply";
            this.btnSettingsApply.UseVisualStyleBackColor = true;
            // 
            // btnSettingsCancel
            // 
            this.btnSettingsCancel.Location = new System.Drawing.Point(411, 358);
            this.btnSettingsCancel.Name = "btnSettingsCancel";
            this.btnSettingsCancel.Size = new System.Drawing.Size(75, 23);
            this.btnSettingsCancel.TabIndex = 0;
            this.btnSettingsCancel.Text = "Cancel";
            this.btnSettingsCancel.UseVisualStyleBackColor = true;
            this.btnSettingsCancel.Click += new System.EventHandler(this.BtnSettingsCancel_Click);
            // 
            // btnSettingsOK
            // 
            this.btnSettingsOK.Location = new System.Drawing.Point(330, 358);
            this.btnSettingsOK.Name = "btnSettingsOK";
            this.btnSettingsOK.Size = new System.Drawing.Size(75, 23);
            this.btnSettingsOK.TabIndex = 0;
            this.btnSettingsOK.Text = "OK";
            this.btnSettingsOK.UseVisualStyleBackColor = true;
            // 
            // gbBounties
            // 
            this.gbBounties.Controls.Add(this.rbOnElimination);
            this.gbBounties.Controls.Add(this.rbOnRebuy);
            this.gbBounties.Controls.Add(this.rbNone);
            this.gbBounties.Location = new System.Drawing.Point(11, 3);
            this.gbBounties.Name = "gbBounties";
            this.gbBounties.Size = new System.Drawing.Size(244, 38);
            this.gbBounties.TabIndex = 3;
            this.gbBounties.TabStop = false;
            this.gbBounties.Text = "Bounties";
            // 
            // rbOnElimination
            // 
            this.rbOnElimination.AutoSize = true;
            this.rbOnElimination.Location = new System.Drawing.Point(146, 15);
            this.rbOnElimination.Name = "rbOnElimination";
            this.rbOnElimination.Size = new System.Drawing.Size(92, 17);
            this.rbOnElimination.TabIndex = 2;
            this.rbOnElimination.Text = "On Elimination";
            this.rbOnElimination.UseVisualStyleBackColor = true;
            this.rbOnElimination.CheckedChanged += new System.EventHandler(this.GbBounty_CheckChanged);
            // 
            // rbOnRebuy
            // 
            this.rbOnRebuy.AutoSize = true;
            this.rbOnRebuy.Location = new System.Drawing.Point(64, 15);
            this.rbOnRebuy.Name = "rbOnRebuy";
            this.rbOnRebuy.Size = new System.Drawing.Size(76, 17);
            this.rbOnRebuy.TabIndex = 1;
            this.rbOnRebuy.Text = "On Re-buy";
            this.rbOnRebuy.UseVisualStyleBackColor = true;
            this.rbOnRebuy.CheckedChanged += new System.EventHandler(this.GbBounty_CheckChanged);
            // 
            // rbNone
            // 
            this.rbNone.AutoSize = true;
            this.rbNone.Checked = true;
            this.rbNone.Location = new System.Drawing.Point(7, 15);
            this.rbNone.Name = "rbNone";
            this.rbNone.Size = new System.Drawing.Size(51, 17);
            this.rbNone.TabIndex = 0;
            this.rbNone.TabStop = true;
            this.rbNone.Text = "None";
            this.rbNone.UseVisualStyleBackColor = true;
            this.rbNone.CheckedChanged += new System.EventHandler(this.GbBounty_CheckChanged);
            // 
            // tcSettings
            // 
            this.tcSettings.Controls.Add(this.tabPage1);
            this.tcSettings.Controls.Add(this.tabPage2);
            this.tcSettings.Controls.Add(this.tabPage3);
            this.tcSettings.Controls.Add(this.tabPage4);
            this.tcSettings.Controls.Add(this.tabPage5);
            this.tcSettings.Controls.Add(this.tabPage6);
            this.tcSettings.Controls.Add(this.tabPage7);
            this.tcSettings.Controls.Add(this.tabPage8);
            this.tcSettings.Location = new System.Drawing.Point(3, 3);
            this.tcSettings.Name = "tcSettings";
            this.tcSettings.SelectedIndex = 0;
            this.tcSettings.Size = new System.Drawing.Size(433, 337);
            this.tcSettings.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(425, 311);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.gbBounties);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 305);
            this.panel1.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(425, 311);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.gbBlinds);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(419, 305);
            this.panel2.TabIndex = 0;
            // 
            // gbBlinds
            // 
            this.gbBlinds.Controls.Add(this.rbCustom);
            this.gbBlinds.Controls.Add(this.rbAVISTA);
            this.gbBlinds.Controls.Add(this.rbPDC);
            this.gbBlinds.Location = new System.Drawing.Point(3, 3);
            this.gbBlinds.Name = "gbBlinds";
            this.gbBlinds.Size = new System.Drawing.Size(244, 38);
            this.gbBlinds.TabIndex = 5;
            this.gbBlinds.TabStop = false;
            this.gbBlinds.Text = "Blinds";
            // 
            // rbCustom
            // 
            this.rbCustom.AutoSize = true;
            this.rbCustom.Location = new System.Drawing.Point(146, 15);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(60, 17);
            this.rbCustom.TabIndex = 2;
            this.rbCustom.Text = "Custom";
            this.rbCustom.UseVisualStyleBackColor = true;
            this.rbCustom.Visible = false;
            this.rbCustom.CheckedChanged += new System.EventHandler(this.GbBlinds_CheckChanged);
            // 
            // rbAVISTA
            // 
            this.rbAVISTA.AutoSize = true;
            this.rbAVISTA.Location = new System.Drawing.Point(64, 15);
            this.rbAVISTA.Name = "rbAVISTA";
            this.rbAVISTA.Size = new System.Drawing.Size(63, 17);
            this.rbAVISTA.TabIndex = 1;
            this.rbAVISTA.Text = "AVISTA";
            this.rbAVISTA.UseVisualStyleBackColor = true;
            this.rbAVISTA.CheckedChanged += new System.EventHandler(this.GbBlinds_CheckChanged);
            // 
            // rbPDC
            // 
            this.rbPDC.AutoSize = true;
            this.rbPDC.Checked = true;
            this.rbPDC.Location = new System.Drawing.Point(7, 15);
            this.rbPDC.Name = "rbPDC";
            this.rbPDC.Size = new System.Drawing.Size(47, 17);
            this.rbPDC.TabIndex = 0;
            this.rbPDC.TabStop = true;
            this.rbPDC.Text = "PDC";
            this.rbPDC.UseVisualStyleBackColor = true;
            this.rbPDC.CheckedChanged += new System.EventHandler(this.GbBlinds_CheckChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(425, 311);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.nudMaxRoundLength);
            this.panel4.Controls.Add(this.nudRoundLength);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.gbRoundLengthType);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(419, 305);
            this.panel4.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Max Round Length in Minutes";
            // 
            // nudMaxRoundLength
            // 
            this.nudMaxRoundLength.Location = new System.Drawing.Point(11, 125);
            this.nudMaxRoundLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxRoundLength.Name = "nudMaxRoundLength";
            this.nudMaxRoundLength.Size = new System.Drawing.Size(120, 20);
            this.nudMaxRoundLength.TabIndex = 8;
            this.nudMaxRoundLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudRoundLength
            // 
            this.nudRoundLength.Location = new System.Drawing.Point(11, 25);
            this.nudRoundLength.Name = "nudRoundLength";
            this.nudRoundLength.Size = new System.Drawing.Size(120, 20);
            this.nudRoundLength.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Round Length in Minutes:";
            // 
            // gbRoundLengthType
            // 
            this.gbRoundLengthType.Controls.Add(this.rbPerPlayer);
            this.gbRoundLengthType.Controls.Add(this.rbPerRound);
            this.gbRoundLengthType.Location = new System.Drawing.Point(11, 51);
            this.gbRoundLengthType.Name = "gbRoundLengthType";
            this.gbRoundLengthType.Size = new System.Drawing.Size(220, 38);
            this.gbRoundLengthType.TabIndex = 4;
            this.gbRoundLengthType.TabStop = false;
            // 
            // rbPerPlayer
            // 
            this.rbPerPlayer.AutoSize = true;
            this.rbPerPlayer.Location = new System.Drawing.Point(89, 15);
            this.rbPerPlayer.Name = "rbPerPlayer";
            this.rbPerPlayer.Size = new System.Drawing.Size(127, 17);
            this.rbPerPlayer.TabIndex = 1;
            this.rbPerPlayer.Text = "Per Player Per Round";
            this.rbPerPlayer.UseVisualStyleBackColor = true;
            // 
            // rbPerRound
            // 
            this.rbPerRound.AutoSize = true;
            this.rbPerRound.Checked = true;
            this.rbPerRound.Location = new System.Drawing.Point(7, 15);
            this.rbPerRound.Name = "rbPerRound";
            this.rbPerRound.Size = new System.Drawing.Size(76, 17);
            this.rbPerRound.TabIndex = 0;
            this.rbPerRound.TabStop = true;
            this.rbPerRound.Text = "Per Round";
            this.rbPerRound.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel5);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(425, 311);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.nudStartingChips);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(10);
            this.panel5.Size = new System.Drawing.Size(419, 305);
            this.panel5.TabIndex = 7;
            // 
            // nudStartingChips
            // 
            this.nudStartingChips.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudStartingChips.Location = new System.Drawing.Point(16, 27);
            this.nudStartingChips.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudStartingChips.Name = "nudStartingChips";
            this.nudStartingChips.Size = new System.Drawing.Size(120, 20);
            this.nudStartingChips.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Starting Chips:";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.panel6);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(425, 311);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.nudLastRebuyRound);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.nudBuyinCost);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(10);
            this.panel6.Size = new System.Drawing.Size(419, 305);
            this.panel6.TabIndex = 7;
            // 
            // nudLastRebuyRound
            // 
            this.nudLastRebuyRound.Location = new System.Drawing.Point(19, 81);
            this.nudLastRebuyRound.Name = "nudLastRebuyRound";
            this.nudLastRebuyRound.Size = new System.Drawing.Size(54, 20);
            this.nudLastRebuyRound.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(209, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Last Rebuy Round (Set to 0 for no rebuys):";
            // 
            // nudBuyinCost
            // 
            this.nudBuyinCost.Location = new System.Drawing.Point(16, 27);
            this.nudBuyinCost.Name = "nudBuyinCost";
            this.nudBuyinCost.Size = new System.Drawing.Size(57, 20);
            this.nudBuyinCost.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Buyin Cost:";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.panel7);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(425, 311);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.btnBrowse);
            this.panel7.Controls.Add(this.tbSaveFolder);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(419, 305);
            this.panel7.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Results Directory:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(323, 40);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // tbSaveFolder
            // 
            this.tbSaveFolder.Location = new System.Drawing.Point(20, 40);
            this.tbSaveFolder.Name = "tbSaveFolder";
            this.tbSaveFolder.Size = new System.Drawing.Size(297, 20);
            this.tbSaveFolder.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.panel8);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(425, 311);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "tabPage7";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.btnRemoveLocation);
            this.panel8.Controls.Add(this.btnAddLocation);
            this.panel8.Controls.Add(this.tbNewLocation);
            this.panel8.Controls.Add(this.lbExistingLocations);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(3, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(419, 305);
            this.panel8.TabIndex = 4;
            // 
            // btnRemoveLocation
            // 
            this.btnRemoveLocation.Location = new System.Drawing.Point(21, 192);
            this.btnRemoveLocation.Name = "btnRemoveLocation";
            this.btnRemoveLocation.Size = new System.Drawing.Size(106, 23);
            this.btnRemoveLocation.TabIndex = 4;
            this.btnRemoveLocation.Text = "Remove Selected";
            this.btnRemoveLocation.UseVisualStyleBackColor = true;
            this.btnRemoveLocation.Click += new System.EventHandler(this.BtnRemoveLocation_Click);
            // 
            // btnAddLocation
            // 
            this.btnAddLocation.Location = new System.Drawing.Point(21, 153);
            this.btnAddLocation.Name = "btnAddLocation";
            this.btnAddLocation.Size = new System.Drawing.Size(106, 23);
            this.btnAddLocation.TabIndex = 1;
            this.btnAddLocation.Text = "Add Location";
            this.btnAddLocation.UseVisualStyleBackColor = true;
            this.btnAddLocation.Click += new System.EventHandler(this.BtnAddLocation_Click);
            // 
            // tbNewLocation
            // 
            this.tbNewLocation.Location = new System.Drawing.Point(133, 155);
            this.tbNewLocation.Name = "tbNewLocation";
            this.tbNewLocation.Size = new System.Drawing.Size(132, 20);
            this.tbNewLocation.TabIndex = 3;
            this.tbNewLocation.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbNewLocation_KeyUp);
            // 
            // lbExistingLocations
            // 
            this.lbExistingLocations.FormattingEnabled = true;
            this.lbExistingLocations.Location = new System.Drawing.Point(21, 46);
            this.lbExistingLocations.Name = "lbExistingLocations";
            this.lbExistingLocations.Size = new System.Drawing.Size(135, 82);
            this.lbExistingLocations.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Existing Locations";
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.panel9);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(425, 311);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "tabPage8";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label3);
            this.panel9.Controls.Add(this.btnSaveSettings);
            this.panel9.Controls.Add(this.tbSettingsName);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(3, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(419, 305);
            this.panel9.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Settings Name:";
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(17, 60);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(100, 23);
            this.btnSaveSettings.TabIndex = 1;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.BtnSaveSettings_Click);
            // 
            // tbSettingsName
            // 
            this.tbSettingsName.Location = new System.Drawing.Point(17, 33);
            this.tbSettingsName.Name = "tbSettingsName";
            this.tbSettingsName.Size = new System.Drawing.Size(189, 20);
            this.tbSettingsName.TabIndex = 0;
            // 
            // tvSettings
            // 
            this.tvSettings.Location = new System.Drawing.Point(12, 12);
            this.tvSettings.Name = "tvSettings";
            treeNode1.Name = "Node0";
            treeNode1.Tag = "0";
            treeNode1.Text = "Bounties";
            treeNode2.Name = "Node1";
            treeNode2.Tag = "1";
            treeNode2.Text = "Blinds";
            treeNode3.Name = "Node2";
            treeNode3.Tag = "2";
            treeNode3.Text = "Round Length";
            treeNode4.Name = "Node3";
            treeNode4.Tag = "3";
            treeNode4.Text = "Starting Chips";
            treeNode5.Name = "Node4";
            treeNode5.Tag = "4";
            treeNode5.Text = "Rebuys";
            treeNode6.Name = "Node5";
            treeNode6.Tag = "5";
            treeNode6.Text = "Results Folder";
            treeNode7.Name = "Node6";
            treeNode7.Tag = "6";
            treeNode7.Text = "Game Locations";
            treeNode8.Name = "Node8";
            treeNode8.Tag = "7";
            treeNode8.Text = "Save Settings";
            this.tvSettings.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
            this.tvSettings.Size = new System.Drawing.Size(121, 337);
            this.tvSettings.TabIndex = 6;
            this.tvSettings.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvSettings_AfterSelect);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tcSettings);
            this.panel3.Location = new System.Drawing.Point(139, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(433, 337);
            this.panel3.TabIndex = 7;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 390);
            this.Controls.Add(this.btnSettingsOK);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.tvSettings);
            this.Controls.Add(this.btnSettingsApply);
            this.Controls.Add(this.btnSettingsCancel);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.gbBounties.ResumeLayout(false);
            this.gbBounties.PerformLayout();
            this.tcSettings.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.gbBlinds.ResumeLayout(false);
            this.gbBlinds.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxRoundLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoundLength)).EndInit();
            this.gbRoundLengthType.ResumeLayout(false);
            this.gbRoundLengthType.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartingChips)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLastRebuyRound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBuyinCost)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSettingsApply;
        private System.Windows.Forms.Button btnSettingsCancel;
        private System.Windows.Forms.Button btnSettingsOK;
        private System.Windows.Forms.GroupBox gbBounties;
        private System.Windows.Forms.RadioButton rbOnElimination;
        private System.Windows.Forms.RadioButton rbOnRebuy;
        private System.Windows.Forms.RadioButton rbNone;
        private System.Windows.Forms.TabControl tcSettings;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView tvSettings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox gbBlinds;
        private System.Windows.Forms.RadioButton rbCustom;
        private System.Windows.Forms.RadioButton rbAVISTA;
        private System.Windows.Forms.RadioButton rbPDC;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TextBox tbNewLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddLocation;
        private System.Windows.Forms.ListBox lbExistingLocations;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnRemoveLocation;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox tbSaveFolder;
        private System.Windows.Forms.FolderBrowserDialog fbdSaveFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.TextBox tbSettingsName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbRoundLengthType;
        private System.Windows.Forms.RadioButton rbPerPlayer;
        private System.Windows.Forms.RadioButton rbPerRound;
        private System.Windows.Forms.NumericUpDown nudRoundLength;
        private System.Windows.Forms.NumericUpDown nudStartingChips;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudLastRebuyRound;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudBuyinCost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudMaxRoundLength;
    }
}