namespace IMGprocessing
{
    partial class Main
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
            this.menu_Main = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageProcessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subtructToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bilateralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cannyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.outputToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iMGCaliperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pMAlignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bLOBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sVMToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comunicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cCIEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ePlcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rS232ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rS485ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ptb_Display1 = new System.Windows.Forms.PictureBox();
            this.ptb_Display2 = new System.Windows.Forms.PictureBox();
            this.txt_K = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_LoadImgInput = new System.Windows.Forms.Button();
            this.btn_LoadImgOutput = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_ClearLogInput = new System.Windows.Forms.Button();
            this.lv_LogInput = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lb_PosDisplay_1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cNNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Display1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Display2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu_Main
            // 
            this.menu_Main.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_Main.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.imageProcessingToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.mLToolStripMenuItem,
            this.dLToolStripMenuItem,
            this.comunicationToolStripMenuItem});
            this.menu_Main.Location = new System.Drawing.Point(0, 0);
            this.menu_Main.Name = "menu_Main";
            this.menu_Main.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menu_Main.Size = new System.Drawing.Size(1924, 31);
            this.menu_Main.TabIndex = 0;
            this.menu_Main.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageToolStripMenuItem,
            this.clearImageToolStripMenuItem,
            this.saveImageToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(49, 27);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inputToolStripMenuItem,
            this.outputToolStripMenuItem});
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(189, 28);
            this.openImageToolStripMenuItem.Text = "Open Image";
            // 
            // inputToolStripMenuItem
            // 
            this.inputToolStripMenuItem.Name = "inputToolStripMenuItem";
            this.inputToolStripMenuItem.Size = new System.Drawing.Size(149, 28);
            this.inputToolStripMenuItem.Text = "Input";
            this.inputToolStripMenuItem.Click += new System.EventHandler(this.InputToolStripMenuItem_Click);
            // 
            // outputToolStripMenuItem
            // 
            this.outputToolStripMenuItem.Name = "outputToolStripMenuItem";
            this.outputToolStripMenuItem.Size = new System.Drawing.Size(149, 28);
            this.outputToolStripMenuItem.Text = "Output";
            this.outputToolStripMenuItem.Click += new System.EventHandler(this.OutputToolStripMenuItem_Click);
            // 
            // clearImageToolStripMenuItem
            // 
            this.clearImageToolStripMenuItem.Name = "clearImageToolStripMenuItem";
            this.clearImageToolStripMenuItem.Size = new System.Drawing.Size(189, 28);
            this.clearImageToolStripMenuItem.Text = "Clear Image";
            this.clearImageToolStripMenuItem.Click += new System.EventHandler(this.ClearImageToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageInputToolStripMenuItem,
            this.imageOutputToolStripMenuItem});
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(189, 28);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            // 
            // imageInputToolStripMenuItem
            // 
            this.imageInputToolStripMenuItem.Name = "imageInputToolStripMenuItem";
            this.imageInputToolStripMenuItem.Size = new System.Drawing.Size(202, 28);
            this.imageInputToolStripMenuItem.Text = "Image Input";
            this.imageInputToolStripMenuItem.Click += new System.EventHandler(this.ImageInputToolStripMenuItem_Click);
            // 
            // imageOutputToolStripMenuItem
            // 
            this.imageOutputToolStripMenuItem.Name = "imageOutputToolStripMenuItem";
            this.imageOutputToolStripMenuItem.Size = new System.Drawing.Size(202, 28);
            this.imageOutputToolStripMenuItem.Text = "Image Output";
            this.imageOutputToolStripMenuItem.Click += new System.EventHandler(this.ImageOutputToolStripMenuItem_Click);
            // 
            // imageProcessingToolStripMenuItem
            // 
            this.imageProcessingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.greyToolStripMenuItem,
            this.medianToolStripMenuItem,
            this.gaussianToolStripMenuItem,
            this.subtructToolStripMenuItem,
            this.bilateralToolStripMenuItem,
            this.cannyToolStripMenuItem,
            this.rotationToolStripMenuItem,
            this.sumToolStripMenuItem,
            this.iMGCaliperToolStripMenuItem});
            this.imageProcessingToolStripMenuItem.Name = "imageProcessingToolStripMenuItem";
            this.imageProcessingToolStripMenuItem.Size = new System.Drawing.Size(158, 27);
            this.imageProcessingToolStripMenuItem.Text = "Image processing";
            // 
            // greyToolStripMenuItem
            // 
            this.greyToolStripMenuItem.Name = "greyToolStripMenuItem";
            this.greyToolStripMenuItem.Size = new System.Drawing.Size(184, 28);
            this.greyToolStripMenuItem.Text = "Grey";
            this.greyToolStripMenuItem.Click += new System.EventHandler(this.GreyToolStripMenuItem_Click);
            // 
            // medianToolStripMenuItem
            // 
            this.medianToolStripMenuItem.Name = "medianToolStripMenuItem";
            this.medianToolStripMenuItem.Size = new System.Drawing.Size(184, 28);
            this.medianToolStripMenuItem.Text = "Median";
            this.medianToolStripMenuItem.Click += new System.EventHandler(this.MedianToolStripMenuItem_Click);
            // 
            // gaussianToolStripMenuItem
            // 
            this.gaussianToolStripMenuItem.Name = "gaussianToolStripMenuItem";
            this.gaussianToolStripMenuItem.Size = new System.Drawing.Size(184, 28);
            this.gaussianToolStripMenuItem.Text = "Gaussian";
            this.gaussianToolStripMenuItem.Click += new System.EventHandler(this.GaussianToolStripMenuItem_Click);
            // 
            // subtructToolStripMenuItem
            // 
            this.subtructToolStripMenuItem.Name = "subtructToolStripMenuItem";
            this.subtructToolStripMenuItem.Size = new System.Drawing.Size(184, 28);
            this.subtructToolStripMenuItem.Text = "Subtruct";
            this.subtructToolStripMenuItem.Click += new System.EventHandler(this.SubtructToolStripMenuItem_Click);
            // 
            // bilateralToolStripMenuItem
            // 
            this.bilateralToolStripMenuItem.Name = "bilateralToolStripMenuItem";
            this.bilateralToolStripMenuItem.Size = new System.Drawing.Size(184, 28);
            this.bilateralToolStripMenuItem.Text = "Bilateral";
            this.bilateralToolStripMenuItem.Click += new System.EventHandler(this.BilateralToolStripMenuItem_Click);
            // 
            // cannyToolStripMenuItem
            // 
            this.cannyToolStripMenuItem.Name = "cannyToolStripMenuItem";
            this.cannyToolStripMenuItem.Size = new System.Drawing.Size(184, 28);
            this.cannyToolStripMenuItem.Text = "Canny";
            this.cannyToolStripMenuItem.Click += new System.EventHandler(this.CannyToolStripMenuItem_Click);
            // 
            // rotationToolStripMenuItem
            // 
            this.rotationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inputToolStripMenuItem1,
            this.outputToolStripMenuItem1});
            this.rotationToolStripMenuItem.Name = "rotationToolStripMenuItem";
            this.rotationToolStripMenuItem.Size = new System.Drawing.Size(184, 28);
            this.rotationToolStripMenuItem.Text = "Rotation";
            // 
            // inputToolStripMenuItem1
            // 
            this.inputToolStripMenuItem1.Name = "inputToolStripMenuItem1";
            this.inputToolStripMenuItem1.Size = new System.Drawing.Size(149, 28);
            this.inputToolStripMenuItem1.Text = "Input";
            this.inputToolStripMenuItem1.Click += new System.EventHandler(this.InputToolStripMenuItem1_Click);
            // 
            // outputToolStripMenuItem1
            // 
            this.outputToolStripMenuItem1.Name = "outputToolStripMenuItem1";
            this.outputToolStripMenuItem1.Size = new System.Drawing.Size(149, 28);
            this.outputToolStripMenuItem1.Text = "Output";
            this.outputToolStripMenuItem1.Click += new System.EventHandler(this.OutputToolStripMenuItem1_Click);
            // 
            // sumToolStripMenuItem
            // 
            this.sumToolStripMenuItem.Name = "sumToolStripMenuItem";
            this.sumToolStripMenuItem.Size = new System.Drawing.Size(184, 28);
            this.sumToolStripMenuItem.Text = "Sum";
            this.sumToolStripMenuItem.Click += new System.EventHandler(this.sumToolStripMenuItem_Click);
            // 
            // iMGCaliperToolStripMenuItem
            // 
            this.iMGCaliperToolStripMenuItem.Name = "iMGCaliperToolStripMenuItem";
            this.iMGCaliperToolStripMenuItem.Size = new System.Drawing.Size(184, 28);
            this.iMGCaliperToolStripMenuItem.Text = "IMG Caliper";
            this.iMGCaliperToolStripMenuItem.Click += new System.EventHandler(this.iMGCaliperToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pMAlignToolStripMenuItem,
            this.bLOBToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(55, 27);
            this.settingToolStripMenuItem.Text = "Tool";
            // 
            // pMAlignToolStripMenuItem
            // 
            this.pMAlignToolStripMenuItem.Name = "pMAlignToolStripMenuItem";
            this.pMAlignToolStripMenuItem.Size = new System.Drawing.Size(158, 28);
            this.pMAlignToolStripMenuItem.Text = "PMAlign";
            this.pMAlignToolStripMenuItem.Click += new System.EventHandler(this.pMAlignToolStripMenuItem_Click);
            // 
            // bLOBToolStripMenuItem
            // 
            this.bLOBToolStripMenuItem.Name = "bLOBToolStripMenuItem";
            this.bLOBToolStripMenuItem.Size = new System.Drawing.Size(158, 28);
            this.bLOBToolStripMenuItem.Text = "BLOB";
            this.bLOBToolStripMenuItem.Click += new System.EventHandler(this.bLOBToolStripMenuItem_Click);
            // 
            // mLToolStripMenuItem
            // 
            this.mLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sVMToolStripMenuItem1});
            this.mLToolStripMenuItem.Name = "mLToolStripMenuItem";
            this.mLToolStripMenuItem.Size = new System.Drawing.Size(47, 27);
            this.mLToolStripMenuItem.Text = "ML";
            // 
            // sVMToolStripMenuItem1
            // 
            this.sVMToolStripMenuItem1.Name = "sVMToolStripMenuItem1";
            this.sVMToolStripMenuItem1.Size = new System.Drawing.Size(129, 28);
            this.sVMToolStripMenuItem1.Text = "SVM";
            this.sVMToolStripMenuItem1.Click += new System.EventHandler(this.sVMToolStripMenuItem1_Click);
            // 
            // dLToolStripMenuItem
            // 
            this.dLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cNNToolStripMenuItem});
            this.dLToolStripMenuItem.Name = "dLToolStripMenuItem";
            this.dLToolStripMenuItem.Size = new System.Drawing.Size(44, 27);
            this.dLToolStripMenuItem.Text = "DL";
            // 
            // comunicationToolStripMenuItem
            // 
            this.comunicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cCIEToolStripMenuItem,
            this.ePlcToolStripMenuItem,
            this.rS232ToolStripMenuItem,
            this.rS485ToolStripMenuItem});
            this.comunicationToolStripMenuItem.Name = "comunicationToolStripMenuItem";
            this.comunicationToolStripMenuItem.Size = new System.Drawing.Size(146, 27);
            this.comunicationToolStripMenuItem.Text = "Communication";
            // 
            // cCIEToolStripMenuItem
            // 
            this.cCIEToolStripMenuItem.Name = "cCIEToolStripMenuItem";
            this.cCIEToolStripMenuItem.Size = new System.Drawing.Size(140, 28);
            this.cCIEToolStripMenuItem.Text = "CCIE";
            // 
            // ePlcToolStripMenuItem
            // 
            this.ePlcToolStripMenuItem.Name = "ePlcToolStripMenuItem";
            this.ePlcToolStripMenuItem.Size = new System.Drawing.Size(140, 28);
            this.ePlcToolStripMenuItem.Text = "E_Plc";
            // 
            // rS232ToolStripMenuItem
            // 
            this.rS232ToolStripMenuItem.Name = "rS232ToolStripMenuItem";
            this.rS232ToolStripMenuItem.Size = new System.Drawing.Size(140, 28);
            this.rS232ToolStripMenuItem.Text = "RS232";
            // 
            // rS485ToolStripMenuItem
            // 
            this.rS485ToolStripMenuItem.Name = "rS485ToolStripMenuItem";
            this.rS485ToolStripMenuItem.Size = new System.Drawing.Size(140, 28);
            this.rS485ToolStripMenuItem.Text = "RS485";
            // 
            // ptb_Display1
            // 
            this.ptb_Display1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptb_Display1.Location = new System.Drawing.Point(8, 23);
            this.ptb_Display1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ptb_Display1.Name = "ptb_Display1";
            this.ptb_Display1.Size = new System.Drawing.Size(774, 563);
            this.ptb_Display1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptb_Display1.TabIndex = 1;
            this.ptb_Display1.TabStop = false;
            this.ptb_Display1.Click += new System.EventHandler(this.ptb_Display1_Click);
            this.ptb_Display1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Ptb_Display1_MouseDown);
            this.ptb_Display1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Ptb_Display1_MouseMove);
            this.ptb_Display1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Ptb_Display1_MouseUp);
            // 
            // ptb_Display2
            // 
            this.ptb_Display2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptb_Display2.Location = new System.Drawing.Point(8, 23);
            this.ptb_Display2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ptb_Display2.Name = "ptb_Display2";
            this.ptb_Display2.Size = new System.Drawing.Size(621, 563);
            this.ptb_Display2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptb_Display2.TabIndex = 1;
            this.ptb_Display2.TabStop = false;
            // 
            // txt_K
            // 
            this.txt_K.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_K.Location = new System.Drawing.Point(279, 597);
            this.txt_K.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_K.Multiline = true;
            this.txt_K.Name = "txt_K";
            this.txt_K.Size = new System.Drawing.Size(132, 24);
            this.txt_K.TabIndex = 0;
            this.txt_K.Text = "3";
            this.txt_K.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(185, 602);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Hệ số K";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_LoadImgInput
            // 
            this.btn_LoadImgInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LoadImgInput.Location = new System.Drawing.Point(752, 690);
            this.btn_LoadImgInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_LoadImgInput.Name = "btn_LoadImgInput";
            this.btn_LoadImgInput.Size = new System.Drawing.Size(153, 39);
            this.btn_LoadImgInput.TabIndex = 3;
            this.btn_LoadImgInput.Text = "Load Input";
            this.btn_LoadImgInput.UseVisualStyleBackColor = true;
            this.btn_LoadImgInput.Click += new System.EventHandler(this.Btn_LoadImgInput_Click);
            // 
            // btn_LoadImgOutput
            // 
            this.btn_LoadImgOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LoadImgOutput.Location = new System.Drawing.Point(9, 591);
            this.btn_LoadImgOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_LoadImgOutput.Name = "btn_LoadImgOutput";
            this.btn_LoadImgOutput.Size = new System.Drawing.Size(153, 37);
            this.btn_LoadImgOutput.TabIndex = 4;
            this.btn_LoadImgOutput.Text = "Load Output";
            this.btn_LoadImgOutput.UseVisualStyleBackColor = true;
            this.btn_LoadImgOutput.Click += new System.EventHandler(this.Btn_LoadImgOutput_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.btn_ClearLogInput);
            this.groupBox1.Controls.Add(this.lv_LogInput);
            this.groupBox1.Controls.Add(this.ptb_Display1);
            this.groupBox1.Controls.Add(this.btn_LoadImgInput);
            this.groupBox1.Controls.Add(this.lb_PosDisplay_1);
            this.groupBox1.Location = new System.Drawing.Point(16, 34);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1083, 820);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "INPUT";
            // 
            // btn_ClearLogInput
            // 
            this.btn_ClearLogInput.Location = new System.Drawing.Point(731, 628);
            this.btn_ClearLogInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_ClearLogInput.Name = "btn_ClearLogInput";
            this.btn_ClearLogInput.Size = new System.Drawing.Size(52, 38);
            this.btn_ClearLogInput.TabIndex = 5;
            this.btn_ClearLogInput.Text = "Clear";
            this.btn_ClearLogInput.UseVisualStyleBackColor = true;
            this.btn_ClearLogInput.Click += new System.EventHandler(this.btn_ClearLogInput_Click);
            // 
            // lv_LogInput
            // 
            this.lv_LogInput.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lv_LogInput.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lv_LogInput.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_LogInput.HideSelection = false;
            this.lv_LogInput.Location = new System.Drawing.Point(9, 628);
            this.lv_LogInput.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lv_LogInput.Name = "lv_LogInput";
            this.lv_LogInput.Size = new System.Drawing.Size(711, 182);
            this.lv_LogInput.TabIndex = 4;
            this.lv_LogInput.UseCompatibleStateImageBehavior = false;
            this.lv_LogInput.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "LOG";
            this.columnHeader2.Width = 1500;
            // 
            // lb_PosDisplay_1
            // 
            this.lb_PosDisplay_1.AutoSize = true;
            this.lb_PosDisplay_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_PosDisplay_1.Location = new System.Drawing.Point(11, 597);
            this.lb_PosDisplay_1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lb_PosDisplay_1.Name = "lb_PosDisplay_1";
            this.lb_PosDisplay_1.Size = new System.Drawing.Size(55, 20);
            this.lb_PosDisplay_1.TabIndex = 1;
            this.lb_PosDisplay_1.Text = "X  ;  Y";
            this.lb_PosDisplay_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox2.Controls.Add(this.ptb_Display2);
            this.groupBox2.Controls.Add(this.txt_K);
            this.groupBox2.Controls.Add(this.btn_LoadImgOutput);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(1107, 34);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(639, 820);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "OUTPUT";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(1753, 34);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(197, 820);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "MENU";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "TOOL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cNNToolStripMenuItem
            // 
            this.cNNToolStripMenuItem.Name = "cNNToolStripMenuItem";
            this.cNNToolStripMenuItem.Size = new System.Drawing.Size(224, 28);
            this.cNNToolStripMenuItem.Text = "CNN";
            this.cNNToolStripMenuItem.Click += new System.EventHandler(this.cNNToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 857);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menu_Main);
            this.MainMenuStrip = this.menu_Main;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Main";
            this.Text = "IMAGE PROCESS";
            this.menu_Main.ResumeLayout(false);
            this.menu_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Display1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Display2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu_Main;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.PictureBox ptb_Display1;
        private System.Windows.Forms.PictureBox ptb_Display2;
        private System.Windows.Forms.ToolStripMenuItem imageInputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageOutputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageProcessingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medianToolStripMenuItem;
        private System.Windows.Forms.TextBox txt_K;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem gaussianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subtructToolStripMenuItem;
        private System.Windows.Forms.Button btn_LoadImgInput;
        private System.Windows.Forms.Button btn_LoadImgOutput;
        private System.Windows.Forms.ToolStripMenuItem bilateralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cannyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pMAlignToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem outputToolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_PosDisplay_1;
        private System.Windows.Forms.ToolStripMenuItem bLOBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iMGCaliperToolStripMenuItem;
        private System.Windows.Forms.ListView lv_LogInput;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btn_ClearLogInput;
        private System.Windows.Forms.ToolStripMenuItem mLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comunicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cCIEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ePlcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rS232ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rS485ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sVMToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cNNToolStripMenuItem;
    }
}

