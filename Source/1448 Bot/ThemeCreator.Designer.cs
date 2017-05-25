namespace _1448_Bot
{
    partial class ThemeCreator
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblBg = new System.Windows.Forms.Label();
            this.colDialogue = new System.Windows.Forms.ColorDialog();
            this.numMainR = new System.Windows.Forms.NumericUpDown();
            this.numMainG = new System.Windows.Forms.NumericUpDown();
            this.numMainB = new System.Windows.Forms.NumericUpDown();
            this.btnMainBG = new System.Windows.Forms.Button();
            this.btnMainFG = new System.Windows.Forms.Button();
            this.numForeB = new System.Windows.Forms.NumericUpDown();
            this.numForeG = new System.Windows.Forms.NumericUpDown();
            this.numForeR = new System.Windows.Forms.NumericUpDown();
            this.lblFore = new System.Windows.Forms.Label();
            this.btnTxtFG = new System.Windows.Forms.Button();
            this.numTxtFGB = new System.Windows.Forms.NumericUpDown();
            this.numTxtFGG = new System.Windows.Forms.NumericUpDown();
            this.numTxtFGR = new System.Windows.Forms.NumericUpDown();
            this.lblFGTxt = new System.Windows.Forms.Label();
            this.btnTxtBG = new System.Windows.Forms.Button();
            this.numTxtBGB = new System.Windows.Forms.NumericUpDown();
            this.numTxtBGG = new System.Windows.Forms.NumericUpDown();
            this.numTxtBGR = new System.Windows.Forms.NumericUpDown();
            this.lblBGTxt = new System.Windows.Forms.Label();
            this.btnBtnFG = new System.Windows.Forms.Button();
            this.numBtnFGB = new System.Windows.Forms.NumericUpDown();
            this.numBtnFGG = new System.Windows.Forms.NumericUpDown();
            this.numBtnFGR = new System.Windows.Forms.NumericUpDown();
            this.lblBtnFG = new System.Windows.Forms.Label();
            this.btnBtnBG = new System.Windows.Forms.Button();
            this.numBtnBGB = new System.Windows.Forms.NumericUpDown();
            this.numBtnBGG = new System.Windows.Forms.NumericUpDown();
            this.numBtnBGR = new System.Windows.Forms.NumericUpDown();
            this.lblBtnBG = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            this.panMain = new System.Windows.Forms.Panel();
            this.lblPreFg = new System.Windows.Forms.Label();
            this.panTxt = new System.Windows.Forms.Panel();
            this.lblPreFgTxt = new System.Windows.Forms.Label();
            this.panBtn = new System.Windows.Forms.Panel();
            this.lblPreFgBtn = new System.Windows.Forms.Label();
            this.comGodmode = new System.Windows.Forms.ComboBox();
            this.lblGod = new System.Windows.Forms.Label();
            this.picGod = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numMainR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMainG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMainB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numForeB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numForeG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numForeR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTxtFGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTxtFGG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTxtFGR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTxtBGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTxtBGG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTxtBGR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBtnFGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBtnFGG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBtnFGR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBtnBGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBtnBGG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBtnBGR)).BeginInit();
            this.panMain.SuspendLayout();
            this.panTxt.SuspendLayout();
            this.panBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGod)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(111, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(166, 20);
            this.txtName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(67, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            // 
            // lblBg
            // 
            this.lblBg.AutoSize = true;
            this.lblBg.Location = new System.Drawing.Point(12, 40);
            this.lblBg.Name = "lblBg";
            this.lblBg.Size = new System.Drawing.Size(93, 13);
            this.lblBg.TabIndex = 2;
            this.lblBg.Text = "Main background:";
            // 
            // numMainR
            // 
            this.numMainR.BackColor = System.Drawing.SystemColors.Window;
            this.numMainR.ForeColor = System.Drawing.Color.Red;
            this.numMainR.Location = new System.Drawing.Point(111, 38);
            this.numMainR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numMainR.Name = "numMainR";
            this.numMainR.Size = new System.Drawing.Size(38, 20);
            this.numMainR.TabIndex = 3;
            this.numMainR.Tag = "mainbg";
            this.numMainR.ValueChanged += new System.EventHandler(this.UpdateColour);
            // 
            // numMainG
            // 
            this.numMainG.ForeColor = System.Drawing.Color.Green;
            this.numMainG.Location = new System.Drawing.Point(155, 38);
            this.numMainG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numMainG.Name = "numMainG";
            this.numMainG.Size = new System.Drawing.Size(38, 20);
            this.numMainG.TabIndex = 4;
            this.numMainG.Tag = "mainbg";
            this.numMainG.ValueChanged += new System.EventHandler(this.UpdateColour);
            // 
            // numMainB
            // 
            this.numMainB.ForeColor = System.Drawing.Color.Blue;
            this.numMainB.Location = new System.Drawing.Point(199, 38);
            this.numMainB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numMainB.Name = "numMainB";
            this.numMainB.Size = new System.Drawing.Size(38, 20);
            this.numMainB.TabIndex = 5;
            this.numMainB.Tag = "mainbg";
            this.numMainB.ValueChanged += new System.EventHandler(this.UpdateColour);
            // 
            // btnMainBG
            // 
            this.btnMainBG.Location = new System.Drawing.Point(243, 38);
            this.btnMainBG.Name = "btnMainBG";
            this.btnMainBG.Size = new System.Drawing.Size(34, 20);
            this.btnMainBG.TabIndex = 6;
            this.btnMainBG.Text = "...";
            this.btnMainBG.UseVisualStyleBackColor = true;
            this.btnMainBG.Click += new System.EventHandler(this.btnMainBG_Click);
            // 
            // btnMainFG
            // 
            this.btnMainFG.Location = new System.Drawing.Point(243, 64);
            this.btnMainFG.Name = "btnMainFG";
            this.btnMainFG.Size = new System.Drawing.Size(34, 20);
            this.btnMainFG.TabIndex = 11;
            this.btnMainFG.Text = "...";
            this.btnMainFG.UseVisualStyleBackColor = true;
            this.btnMainFG.Click += new System.EventHandler(this.btnMainFG_Click);
            // 
            // numForeB
            // 
            this.numForeB.ForeColor = System.Drawing.Color.Blue;
            this.numForeB.Location = new System.Drawing.Point(199, 64);
            this.numForeB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numForeB.Name = "numForeB";
            this.numForeB.Size = new System.Drawing.Size(38, 20);
            this.numForeB.TabIndex = 10;
            this.numForeB.Tag = "mainfg";
            this.numForeB.ValueChanged += new System.EventHandler(this.UpdateColour);
            // 
            // numForeG
            // 
            this.numForeG.ForeColor = System.Drawing.Color.Green;
            this.numForeG.Location = new System.Drawing.Point(155, 64);
            this.numForeG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numForeG.Name = "numForeG";
            this.numForeG.Size = new System.Drawing.Size(38, 20);
            this.numForeG.TabIndex = 9;
            this.numForeG.Tag = "mainfg";
            this.numForeG.ValueChanged += new System.EventHandler(this.UpdateColour);
            // 
            // numForeR
            // 
            this.numForeR.BackColor = System.Drawing.SystemColors.Window;
            this.numForeR.ForeColor = System.Drawing.Color.Red;
            this.numForeR.Location = new System.Drawing.Point(111, 64);
            this.numForeR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numForeR.Name = "numForeR";
            this.numForeR.Size = new System.Drawing.Size(38, 20);
            this.numForeR.TabIndex = 8;
            this.numForeR.Tag = "mainfg";
            this.numForeR.ValueChanged += new System.EventHandler(this.UpdateColour);
            // 
            // lblFore
            // 
            this.lblFore.AutoSize = true;
            this.lblFore.Location = new System.Drawing.Point(18, 66);
            this.lblFore.Name = "lblFore";
            this.lblFore.Size = new System.Drawing.Size(87, 13);
            this.lblFore.TabIndex = 7;
            this.lblFore.Text = "Main foreground:";
            // 
            // btnTxtFG
            // 
            this.btnTxtFG.Location = new System.Drawing.Point(243, 116);
            this.btnTxtFG.Name = "btnTxtFG";
            this.btnTxtFG.Size = new System.Drawing.Size(34, 20);
            this.btnTxtFG.TabIndex = 21;
            this.btnTxtFG.Text = "...";
            this.btnTxtFG.UseVisualStyleBackColor = true;
            this.btnTxtFG.Click += new System.EventHandler(this.btnTxtFG_Click);
            // 
            // numTxtFGB
            // 
            this.numTxtFGB.ForeColor = System.Drawing.Color.Blue;
            this.numTxtFGB.Location = new System.Drawing.Point(199, 116);
            this.numTxtFGB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numTxtFGB.Name = "numTxtFGB";
            this.numTxtFGB.Size = new System.Drawing.Size(38, 20);
            this.numTxtFGB.TabIndex = 20;
            this.numTxtFGB.Tag = "txtfg";
            this.numTxtFGB.ValueChanged += new System.EventHandler(this.UpdateColour);
            // 
            // numTxtFGG
            // 
            this.numTxtFGG.ForeColor = System.Drawing.Color.Green;
            this.numTxtFGG.Location = new System.Drawing.Point(155, 116);
            this.numTxtFGG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numTxtFGG.Name = "numTxtFGG";
            this.numTxtFGG.Size = new System.Drawing.Size(38, 20);
            this.numTxtFGG.TabIndex = 19;
            this.numTxtFGG.Tag = "txtfg";
            this.numTxtFGG.ValueChanged += new System.EventHandler(this.UpdateColour);
            // 
            // numTxtFGR
            // 
            this.numTxtFGR.BackColor = System.Drawing.SystemColors.Window;
            this.numTxtFGR.ForeColor = System.Drawing.Color.Red;
            this.numTxtFGR.Location = new System.Drawing.Point(111, 116);
            this.numTxtFGR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numTxtFGR.Name = "numTxtFGR";
            this.numTxtFGR.Size = new System.Drawing.Size(38, 20);
            this.numTxtFGR.TabIndex = 18;
            this.numTxtFGR.Tag = "txtfg";
            this.numTxtFGR.ValueChanged += new System.EventHandler(this.UpdateColour);
            // 
            // lblFGTxt
            // 
            this.lblFGTxt.AutoSize = true;
            this.lblFGTxt.Location = new System.Drawing.Point(40, 120);
            this.lblFGTxt.Name = "lblFGTxt";
            this.lblFGTxt.Size = new System.Drawing.Size(65, 13);
            this.lblFGTxt.TabIndex = 17;
            this.lblFGTxt.Text = "Textbox FG:";
            // 
            // btnTxtBG
            // 
            this.btnTxtBG.Location = new System.Drawing.Point(243, 90);
            this.btnTxtBG.Name = "btnTxtBG";
            this.btnTxtBG.Size = new System.Drawing.Size(34, 20);
            this.btnTxtBG.TabIndex = 16;
            this.btnTxtBG.Text = "...";
            this.btnTxtBG.UseVisualStyleBackColor = true;
            this.btnTxtBG.Click += new System.EventHandler(this.btnTxtBG_Click);
            // 
            // numTxtBGB
            // 
            this.numTxtBGB.ForeColor = System.Drawing.Color.Blue;
            this.numTxtBGB.Location = new System.Drawing.Point(199, 90);
            this.numTxtBGB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numTxtBGB.Name = "numTxtBGB";
            this.numTxtBGB.Size = new System.Drawing.Size(38, 20);
            this.numTxtBGB.TabIndex = 15;
            this.numTxtBGB.Tag = "txtbg";
            this.numTxtBGB.ValueChanged += new System.EventHandler(this.UpdateColour);
            // 
            // numTxtBGG
            // 
            this.numTxtBGG.ForeColor = System.Drawing.Color.Green;
            this.numTxtBGG.Location = new System.Drawing.Point(155, 90);
            this.numTxtBGG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numTxtBGG.Name = "numTxtBGG";
            this.numTxtBGG.Size = new System.Drawing.Size(38, 20);
            this.numTxtBGG.TabIndex = 14;
            this.numTxtBGG.Tag = "txtbg";
            this.numTxtBGG.ValueChanged += new System.EventHandler(this.UpdateColour);
            // 
            // numTxtBGR
            // 
            this.numTxtBGR.BackColor = System.Drawing.SystemColors.Window;
            this.numTxtBGR.ForeColor = System.Drawing.Color.Red;
            this.numTxtBGR.Location = new System.Drawing.Point(111, 90);
            this.numTxtBGR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numTxtBGR.Name = "numTxtBGR";
            this.numTxtBGR.Size = new System.Drawing.Size(38, 20);
            this.numTxtBGR.TabIndex = 13;
            this.numTxtBGR.Tag = "txtbg";
            this.numTxtBGR.ValueChanged += new System.EventHandler(this.UpdateColour);
            // 
            // lblBGTxt
            // 
            this.lblBGTxt.AutoSize = true;
            this.lblBGTxt.Location = new System.Drawing.Point(39, 92);
            this.lblBGTxt.Name = "lblBGTxt";
            this.lblBGTxt.Size = new System.Drawing.Size(66, 13);
            this.lblBGTxt.TabIndex = 12;
            this.lblBGTxt.Text = "Textbox BG:";
            // 
            // btnBtnFG
            // 
            this.btnBtnFG.Location = new System.Drawing.Point(243, 168);
            this.btnBtnFG.Name = "btnBtnFG";
            this.btnBtnFG.Size = new System.Drawing.Size(34, 20);
            this.btnBtnFG.TabIndex = 31;
            this.btnBtnFG.Text = "...";
            this.btnBtnFG.UseVisualStyleBackColor = true;
            this.btnBtnFG.Click += new System.EventHandler(this.btnBtnFG_Click);
            // 
            // numBtnFGB
            // 
            this.numBtnFGB.ForeColor = System.Drawing.Color.Blue;
            this.numBtnFGB.Location = new System.Drawing.Point(199, 168);
            this.numBtnFGB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numBtnFGB.Name = "numBtnFGB";
            this.numBtnFGB.Size = new System.Drawing.Size(38, 20);
            this.numBtnFGB.TabIndex = 30;
            this.numBtnFGB.Tag = "btnfg";
            this.numBtnFGB.ValueChanged += new System.EventHandler(this.UpdateColour);
            // 
            // numBtnFGG
            // 
            this.numBtnFGG.ForeColor = System.Drawing.Color.Green;
            this.numBtnFGG.Location = new System.Drawing.Point(155, 168);
            this.numBtnFGG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numBtnFGG.Name = "numBtnFGG";
            this.numBtnFGG.Size = new System.Drawing.Size(38, 20);
            this.numBtnFGG.TabIndex = 29;
            this.numBtnFGG.Tag = "btnfg";
            this.numBtnFGG.ValueChanged += new System.EventHandler(this.UpdateColour);
            // 
            // numBtnFGR
            // 
            this.numBtnFGR.BackColor = System.Drawing.SystemColors.Window;
            this.numBtnFGR.ForeColor = System.Drawing.Color.Red;
            this.numBtnFGR.Location = new System.Drawing.Point(111, 168);
            this.numBtnFGR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numBtnFGR.Name = "numBtnFGR";
            this.numBtnFGR.Size = new System.Drawing.Size(38, 20);
            this.numBtnFGR.TabIndex = 28;
            this.numBtnFGR.Tag = "btnfg";
            this.numBtnFGR.ValueChanged += new System.EventHandler(this.UpdateColour);
            // 
            // lblBtnFG
            // 
            this.lblBtnFG.AutoSize = true;
            this.lblBtnFG.Location = new System.Drawing.Point(47, 172);
            this.lblBtnFG.Name = "lblBtnFG";
            this.lblBtnFG.Size = new System.Drawing.Size(58, 13);
            this.lblBtnFG.TabIndex = 27;
            this.lblBtnFG.Text = "Button FG:";
            // 
            // btnBtnBG
            // 
            this.btnBtnBG.Location = new System.Drawing.Point(243, 140);
            this.btnBtnBG.Name = "btnBtnBG";
            this.btnBtnBG.Size = new System.Drawing.Size(34, 22);
            this.btnBtnBG.TabIndex = 26;
            this.btnBtnBG.Text = "...";
            this.btnBtnBG.UseVisualStyleBackColor = true;
            this.btnBtnBG.Click += new System.EventHandler(this.btnBtnBG_Click);
            // 
            // numBtnBGB
            // 
            this.numBtnBGB.ForeColor = System.Drawing.Color.Blue;
            this.numBtnBGB.Location = new System.Drawing.Point(199, 142);
            this.numBtnBGB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numBtnBGB.Name = "numBtnBGB";
            this.numBtnBGB.Size = new System.Drawing.Size(38, 20);
            this.numBtnBGB.TabIndex = 25;
            this.numBtnBGB.Tag = "btnbg";
            this.numBtnBGB.ValueChanged += new System.EventHandler(this.UpdateColour);
            // 
            // numBtnBGG
            // 
            this.numBtnBGG.ForeColor = System.Drawing.Color.Green;
            this.numBtnBGG.Location = new System.Drawing.Point(155, 142);
            this.numBtnBGG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numBtnBGG.Name = "numBtnBGG";
            this.numBtnBGG.Size = new System.Drawing.Size(38, 20);
            this.numBtnBGG.TabIndex = 24;
            this.numBtnBGG.Tag = "btnbg";
            this.numBtnBGG.ValueChanged += new System.EventHandler(this.UpdateColour);
            // 
            // numBtnBGR
            // 
            this.numBtnBGR.BackColor = System.Drawing.SystemColors.Window;
            this.numBtnBGR.ForeColor = System.Drawing.Color.Red;
            this.numBtnBGR.Location = new System.Drawing.Point(111, 142);
            this.numBtnBGR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numBtnBGR.Name = "numBtnBGR";
            this.numBtnBGR.Size = new System.Drawing.Size(38, 20);
            this.numBtnBGR.TabIndex = 23;
            this.numBtnBGR.Tag = "btnbg";
            this.numBtnBGR.ValueChanged += new System.EventHandler(this.UpdateColour);
            // 
            // lblBtnBG
            // 
            this.lblBtnBG.AutoSize = true;
            this.lblBtnBG.Location = new System.Drawing.Point(46, 145);
            this.lblBtnBG.Name = "lblBtnBG";
            this.lblBtnBG.Size = new System.Drawing.Size(59, 13);
            this.lblBtnBG.TabIndex = 22;
            this.lblBtnBG.Text = "Button BG:";
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(202, 227);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.TabIndex = 32;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // panMain
            // 
            this.panMain.BackColor = System.Drawing.Color.Black;
            this.panMain.Controls.Add(this.lblPreFg);
            this.panMain.Location = new System.Drawing.Point(284, 38);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(51, 46);
            this.panMain.TabIndex = 33;
            // 
            // lblPreFg
            // 
            this.lblPreFg.AutoSize = true;
            this.lblPreFg.Location = new System.Drawing.Point(3, 7);
            this.lblPreFg.Name = "lblPreFg";
            this.lblPreFg.Size = new System.Drawing.Size(28, 13);
            this.lblPreFg.TabIndex = 0;
            this.lblPreFg.Text = "Text";
            // 
            // panTxt
            // 
            this.panTxt.BackColor = System.Drawing.Color.Black;
            this.panTxt.Controls.Add(this.lblPreFgTxt);
            this.panTxt.Location = new System.Drawing.Point(284, 90);
            this.panTxt.Name = "panTxt";
            this.panTxt.Size = new System.Drawing.Size(51, 46);
            this.panTxt.TabIndex = 34;
            // 
            // lblPreFgTxt
            // 
            this.lblPreFgTxt.AutoSize = true;
            this.lblPreFgTxt.Location = new System.Drawing.Point(3, 7);
            this.lblPreFgTxt.Name = "lblPreFgTxt";
            this.lblPreFgTxt.Size = new System.Drawing.Size(28, 13);
            this.lblPreFgTxt.TabIndex = 1;
            this.lblPreFgTxt.Text = "Text";
            // 
            // panBtn
            // 
            this.panBtn.BackColor = System.Drawing.Color.Black;
            this.panBtn.Controls.Add(this.lblPreFgBtn);
            this.panBtn.Location = new System.Drawing.Point(284, 142);
            this.panBtn.Name = "panBtn";
            this.panBtn.Size = new System.Drawing.Size(51, 46);
            this.panBtn.TabIndex = 35;
            // 
            // lblPreFgBtn
            // 
            this.lblPreFgBtn.AutoSize = true;
            this.lblPreFgBtn.Location = new System.Drawing.Point(3, 7);
            this.lblPreFgBtn.Name = "lblPreFgBtn";
            this.lblPreFgBtn.Size = new System.Drawing.Size(28, 13);
            this.lblPreFgBtn.TabIndex = 1;
            this.lblPreFgBtn.Text = "Text";
            // 
            // comGodmode
            // 
            this.comGodmode.FormattingEnabled = true;
            this.comGodmode.Items.AddRange(new object[] {
            "White",
            "Red",
            "Pink",
            "Cyan",
            "Gold"});
            this.comGodmode.Location = new System.Drawing.Point(111, 200);
            this.comGodmode.Name = "comGodmode";
            this.comGodmode.Size = new System.Drawing.Size(166, 21);
            this.comGodmode.TabIndex = 36;
            this.comGodmode.SelectedIndexChanged += new System.EventHandler(this.comGodmode_SelectedIndexChanged);
            // 
            // lblGod
            // 
            this.lblGod.AutoSize = true;
            this.lblGod.Location = new System.Drawing.Point(25, 203);
            this.lblGod.Name = "lblGod";
            this.lblGod.Size = new System.Drawing.Size(80, 13);
            this.lblGod.TabIndex = 37;
            this.lblGod.Text = "Godmode aura:";
            // 
            // picGod
            // 
            this.picGod.BackColor = System.Drawing.Color.Black;
            this.picGod.ImageLocation = "";
            this.picGod.Location = new System.Drawing.Point(290, 194);
            this.picGod.Name = "picGod";
            this.picGod.Size = new System.Drawing.Size(32, 32);
            this.picGod.TabIndex = 38;
            this.picGod.TabStop = false;
            // 
            // ThemeCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 262);
            this.Controls.Add(this.picGod);
            this.Controls.Add(this.lblGod);
            this.Controls.Add(this.comGodmode);
            this.Controls.Add(this.panBtn);
            this.Controls.Add(this.panTxt);
            this.Controls.Add(this.panMain);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnBtnFG);
            this.Controls.Add(this.numBtnFGB);
            this.Controls.Add(this.numBtnFGG);
            this.Controls.Add(this.numBtnFGR);
            this.Controls.Add(this.lblBtnFG);
            this.Controls.Add(this.btnBtnBG);
            this.Controls.Add(this.numBtnBGB);
            this.Controls.Add(this.numBtnBGG);
            this.Controls.Add(this.numBtnBGR);
            this.Controls.Add(this.lblBtnBG);
            this.Controls.Add(this.btnTxtFG);
            this.Controls.Add(this.numTxtFGB);
            this.Controls.Add(this.numTxtFGG);
            this.Controls.Add(this.numTxtFGR);
            this.Controls.Add(this.lblFGTxt);
            this.Controls.Add(this.btnTxtBG);
            this.Controls.Add(this.numTxtBGB);
            this.Controls.Add(this.numTxtBGG);
            this.Controls.Add(this.numTxtBGR);
            this.Controls.Add(this.lblBGTxt);
            this.Controls.Add(this.btnMainFG);
            this.Controls.Add(this.numForeB);
            this.Controls.Add(this.numForeG);
            this.Controls.Add(this.numForeR);
            this.Controls.Add(this.lblFore);
            this.Controls.Add(this.btnMainBG);
            this.Controls.Add(this.numMainB);
            this.Controls.Add(this.numMainG);
            this.Controls.Add(this.numMainR);
            this.Controls.Add(this.lblBg);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThemeCreator";
            this.Text = "Create a new theme";
            this.Load += new System.EventHandler(this.ThemeCreator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numMainR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMainG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMainB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numForeB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numForeG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numForeR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTxtFGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTxtFGG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTxtFGR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTxtBGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTxtBGG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTxtBGR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBtnFGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBtnFGG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBtnFGR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBtnBGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBtnBGG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBtnBGR)).EndInit();
            this.panMain.ResumeLayout(false);
            this.panMain.PerformLayout();
            this.panTxt.ResumeLayout(false);
            this.panTxt.PerformLayout();
            this.panBtn.ResumeLayout(false);
            this.panBtn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblBg;
        private System.Windows.Forms.ColorDialog colDialogue;
        private System.Windows.Forms.NumericUpDown numMainR;
        private System.Windows.Forms.NumericUpDown numMainG;
        private System.Windows.Forms.NumericUpDown numMainB;
        private System.Windows.Forms.Button btnMainBG;
        private System.Windows.Forms.Button btnMainFG;
        private System.Windows.Forms.NumericUpDown numForeB;
        private System.Windows.Forms.NumericUpDown numForeG;
        private System.Windows.Forms.NumericUpDown numForeR;
        private System.Windows.Forms.Label lblFore;
        private System.Windows.Forms.Button btnTxtFG;
        private System.Windows.Forms.NumericUpDown numTxtFGB;
        private System.Windows.Forms.NumericUpDown numTxtFGG;
        private System.Windows.Forms.NumericUpDown numTxtFGR;
        private System.Windows.Forms.Label lblFGTxt;
        private System.Windows.Forms.Button btnTxtBG;
        private System.Windows.Forms.NumericUpDown numTxtBGB;
        private System.Windows.Forms.NumericUpDown numTxtBGG;
        private System.Windows.Forms.NumericUpDown numTxtBGR;
        private System.Windows.Forms.Label lblBGTxt;
        private System.Windows.Forms.Button btnBtnFG;
        private System.Windows.Forms.NumericUpDown numBtnFGB;
        private System.Windows.Forms.NumericUpDown numBtnFGG;
        private System.Windows.Forms.NumericUpDown numBtnFGR;
        private System.Windows.Forms.Label lblBtnFG;
        private System.Windows.Forms.Button btnBtnBG;
        private System.Windows.Forms.NumericUpDown numBtnBGB;
        private System.Windows.Forms.NumericUpDown numBtnBGG;
        private System.Windows.Forms.NumericUpDown numBtnBGR;
        private System.Windows.Forms.Label lblBtnBG;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Panel panMain;
        private System.Windows.Forms.Label lblPreFg;
        private System.Windows.Forms.Panel panTxt;
        private System.Windows.Forms.Label lblPreFgTxt;
        private System.Windows.Forms.Panel panBtn;
        private System.Windows.Forms.Label lblPreFgBtn;
        private System.Windows.Forms.ComboBox comGodmode;
        private System.Windows.Forms.Label lblGod;
        private System.Windows.Forms.PictureBox picGod;
    }
}
