
namespace IMGprocessing
{
    partial class Frm_LearnML
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lst_imagePathIn = new System.Windows.Forms.ListBox();
            this.btn_loadFolderImgIn = new System.Windows.Forms.Button();
            this.btn_AddLabel = new System.Windows.Forms.Button();
            this.txt_AddLabel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ClearLabel = new System.Windows.Forms.Button();
            this.lv_LogInput = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_ExportFeature = new System.Windows.Forms.Button();
            this.btn_Train = new System.Windows.Forms.Button();
            this.btn_LoadModel = new System.Windows.Forms.Button();
            this.lst_imagePathOut = new System.Windows.Forms.ListBox();
            this.btn_loadFolderImgOut = new System.Windows.Forms.Button();
            this.lb_Predict = new System.Windows.Forms.Label();
            this.lv_LogOutput = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_Predict = new System.Windows.Forms.Button();
            this.txt_NameModel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ccb_TypeModel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ccb_TypeFeature = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(212, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(657, 564);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(883, 15);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(615, 564);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // lst_imagePathIn
            // 
            this.lst_imagePathIn.FormattingEnabled = true;
            this.lst_imagePathIn.ItemHeight = 16;
            this.lst_imagePathIn.Location = new System.Drawing.Point(16, 15);
            this.lst_imagePathIn.Margin = new System.Windows.Forms.Padding(4);
            this.lst_imagePathIn.Name = "lst_imagePathIn";
            this.lst_imagePathIn.Size = new System.Drawing.Size(181, 564);
            this.lst_imagePathIn.TabIndex = 24;
            this.lst_imagePathIn.SelectedIndexChanged += new System.EventHandler(this.listBoxImagePath_SelectedIndexChanged);
            // 
            // btn_loadFolderImgIn
            // 
            this.btn_loadFolderImgIn.Location = new System.Drawing.Point(16, 598);
            this.btn_loadFolderImgIn.Margin = new System.Windows.Forms.Padding(4);
            this.btn_loadFolderImgIn.Name = "btn_loadFolderImgIn";
            this.btn_loadFolderImgIn.Size = new System.Drawing.Size(183, 34);
            this.btn_loadFolderImgIn.TabIndex = 25;
            this.btn_loadFolderImgIn.Text = "Load Image";
            this.btn_loadFolderImgIn.UseVisualStyleBackColor = true;
            this.btn_loadFolderImgIn.Click += new System.EventHandler(this.btn_loadFolderImg_Click);
            // 
            // btn_AddLabel
            // 
            this.btn_AddLabel.Location = new System.Drawing.Point(327, 598);
            this.btn_AddLabel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_AddLabel.Name = "btn_AddLabel";
            this.btn_AddLabel.Size = new System.Drawing.Size(103, 34);
            this.btn_AddLabel.TabIndex = 1;
            this.btn_AddLabel.Text = "Add Nhãn";
            this.btn_AddLabel.UseVisualStyleBackColor = true;
            this.btn_AddLabel.Click += new System.EventHandler(this.btn_AddLabel_Click);
            // 
            // txt_AddLabel
            // 
            this.txt_AddLabel.Location = new System.Drawing.Point(488, 604);
            this.txt_AddLabel.Margin = new System.Windows.Forms.Padding(4);
            this.txt_AddLabel.Name = "txt_AddLabel";
            this.txt_AddLabel.Size = new System.Drawing.Size(143, 22);
            this.txt_AddLabel.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(436, 608);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Nhãn";
            // 
            // btn_ClearLabel
            // 
            this.btn_ClearLabel.Location = new System.Drawing.Point(212, 598);
            this.btn_ClearLabel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ClearLabel.Name = "btn_ClearLabel";
            this.btn_ClearLabel.Size = new System.Drawing.Size(109, 34);
            this.btn_ClearLabel.TabIndex = 1;
            this.btn_ClearLabel.Text = "CLear Nhãn";
            this.btn_ClearLabel.UseVisualStyleBackColor = true;
            // 
            // lv_LogInput
            // 
            this.lv_LogInput.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lv_LogInput.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1});
            this.lv_LogInput.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_LogInput.HideSelection = false;
            this.lv_LogInput.Location = new System.Drawing.Point(17, 638);
            this.lv_LogInput.Margin = new System.Windows.Forms.Padding(5);
            this.lv_LogInput.Name = "lv_LogInput";
            this.lv_LogInput.Size = new System.Drawing.Size(614, 164);
            this.lv_LogInput.TabIndex = 28;
            this.lv_LogInput.UseCompatibleStateImageBehavior = false;
            this.lv_LogInput.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Label";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Path";
            this.columnHeader1.Width = 1500;
            // 
            // btn_ExportFeature
            // 
            this.btn_ExportFeature.Location = new System.Drawing.Point(1195, 597);
            this.btn_ExportFeature.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ExportFeature.Name = "btn_ExportFeature";
            this.btn_ExportFeature.Size = new System.Drawing.Size(168, 28);
            this.btn_ExportFeature.TabIndex = 1;
            this.btn_ExportFeature.Text = "Export Feature";
            this.btn_ExportFeature.UseVisualStyleBackColor = true;
            this.btn_ExportFeature.Click += new System.EventHandler(this.btn_ExportFeature_Click);
            // 
            // btn_Train
            // 
            this.btn_Train.Location = new System.Drawing.Point(779, 767);
            this.btn_Train.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Train.Name = "btn_Train";
            this.btn_Train.Size = new System.Drawing.Size(218, 35);
            this.btn_Train.TabIndex = 1;
            this.btn_Train.Text = "TRAIN";
            this.btn_Train.UseVisualStyleBackColor = true;
            this.btn_Train.Click += new System.EventHandler(this.btn_Train_Click);
            // 
            // btn_LoadModel
            // 
            this.btn_LoadModel.Location = new System.Drawing.Point(1507, 639);
            this.btn_LoadModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_LoadModel.Name = "btn_LoadModel";
            this.btn_LoadModel.Size = new System.Drawing.Size(181, 33);
            this.btn_LoadModel.TabIndex = 1;
            this.btn_LoadModel.Text = "LOAD MODEL";
            this.btn_LoadModel.UseVisualStyleBackColor = true;
            this.btn_LoadModel.Click += new System.EventHandler(this.btn_LoadModel_Click);
            // 
            // lst_imagePathOut
            // 
            this.lst_imagePathOut.FormattingEnabled = true;
            this.lst_imagePathOut.ItemHeight = 16;
            this.lst_imagePathOut.Location = new System.Drawing.Point(1505, 15);
            this.lst_imagePathOut.Margin = new System.Windows.Forms.Padding(4);
            this.lst_imagePathOut.Name = "lst_imagePathOut";
            this.lst_imagePathOut.Size = new System.Drawing.Size(181, 564);
            this.lst_imagePathOut.TabIndex = 24;
            this.lst_imagePathOut.SelectedIndexChanged += new System.EventHandler(this.lst_imagePathOut_SelectedIndexChanged);
            // 
            // btn_loadFolderImgOut
            // 
            this.btn_loadFolderImgOut.Location = new System.Drawing.Point(1505, 598);
            this.btn_loadFolderImgOut.Margin = new System.Windows.Forms.Padding(4);
            this.btn_loadFolderImgOut.Name = "btn_loadFolderImgOut";
            this.btn_loadFolderImgOut.Size = new System.Drawing.Size(183, 34);
            this.btn_loadFolderImgOut.TabIndex = 25;
            this.btn_loadFolderImgOut.Text = "Load Image";
            this.btn_loadFolderImgOut.UseVisualStyleBackColor = true;
            this.btn_loadFolderImgOut.Click += new System.EventHandler(this.btn_loadFolderImgOut_Click);
            // 
            // lb_Predict
            // 
            this.lb_Predict.AutoSize = true;
            this.lb_Predict.Location = new System.Drawing.Point(1075, 607);
            this.lb_Predict.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Predict.Name = "lb_Predict";
            this.lb_Predict.Size = new System.Drawing.Size(42, 17);
            this.lb_Predict.TabIndex = 27;
            this.lb_Predict.Text = "Nhãn";
            // 
            // lv_LogOutput
            // 
            this.lv_LogOutput.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lv_LogOutput.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lv_LogOutput.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_LogOutput.HideSelection = false;
            this.lv_LogOutput.Location = new System.Drawing.Point(1049, 638);
            this.lv_LogOutput.Margin = new System.Windows.Forms.Padding(5);
            this.lv_LogOutput.Name = "lv_LogOutput";
            this.lv_LogOutput.Size = new System.Drawing.Size(449, 164);
            this.lv_LogOutput.TabIndex = 28;
            this.lv_LogOutput.UseCompatibleStateImageBehavior = false;
            this.lv_LogOutput.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Model";
            this.columnHeader3.Width = 192;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "accuracy";
            this.columnHeader4.Width = 300;
            // 
            // btn_Predict
            // 
            this.btn_Predict.Location = new System.Drawing.Point(1507, 677);
            this.btn_Predict.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Predict.Name = "btn_Predict";
            this.btn_Predict.Size = new System.Drawing.Size(181, 33);
            this.btn_Predict.TabIndex = 1;
            this.btn_Predict.Text = "PREDICT";
            this.btn_Predict.UseVisualStyleBackColor = true;
            this.btn_Predict.Click += new System.EventHandler(this.btn_Predict_Click);
            // 
            // txt_NameModel
            // 
            this.txt_NameModel.Location = new System.Drawing.Point(841, 734);
            this.txt_NameModel.Margin = new System.Windows.Forms.Padding(4);
            this.txt_NameModel.Name = "txt_NameModel";
            this.txt_NameModel.Size = new System.Drawing.Size(156, 22);
            this.txt_NameModel.TabIndex = 26;
            this.txt_NameModel.Text = "svm_model";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(776, 737);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 21);
            this.label2.TabIndex = 27;
            this.label2.Text = "Path";
            // 
            // ccb_TypeModel
            // 
            this.ccb_TypeModel.FormattingEnabled = true;
            this.ccb_TypeModel.Items.AddRange(new object[] {
            "SVM",
            "KNN",
            "CNN"});
            this.ccb_TypeModel.Location = new System.Drawing.Point(842, 625);
            this.ccb_TypeModel.Name = "ccb_TypeModel";
            this.ccb_TypeModel.Size = new System.Drawing.Size(155, 24);
            this.ccb_TypeModel.TabIndex = 29;
            this.ccb_TypeModel.Text = "SVM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(776, 628);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 21);
            this.label3.TabIndex = 27;
            this.label3.Text = "Model";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(776, 667);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 21);
            this.label4.TabIndex = 27;
            this.label4.Text = "Feature";
            // 
            // ccb_TypeFeature
            // 
            this.ccb_TypeFeature.FormattingEnabled = true;
            this.ccb_TypeFeature.Items.AddRange(new object[] {
            "HOG",
            "LBP",
            "SURF",
            "MEAN"});
            this.ccb_TypeFeature.Location = new System.Drawing.Point(842, 664);
            this.ccb_TypeFeature.Name = "ccb_TypeFeature";
            this.ccb_TypeFeature.Size = new System.Drawing.Size(155, 24);
            this.ccb_TypeFeature.TabIndex = 29;
            this.ccb_TypeFeature.Text = "HOG";
            // 
            // Frm_LearnML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1847, 806);
            this.Controls.Add(this.ccb_TypeFeature);
            this.Controls.Add(this.ccb_TypeModel);
            this.Controls.Add(this.lv_LogOutput);
            this.Controls.Add(this.lv_LogInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb_Predict);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_NameModel);
            this.Controls.Add(this.txt_AddLabel);
            this.Controls.Add(this.btn_loadFolderImgOut);
            this.Controls.Add(this.btn_loadFolderImgIn);
            this.Controls.Add(this.lst_imagePathOut);
            this.Controls.Add(this.lst_imagePathIn);
            this.Controls.Add(this.btn_ClearLabel);
            this.Controls.Add(this.btn_Predict);
            this.Controls.Add(this.btn_LoadModel);
            this.Controls.Add(this.btn_Train);
            this.Controls.Add(this.btn_ExportFeature);
            this.Controls.Add(this.btn_AddLabel);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Frm_LearnML";
            this.Text = "Frm_LearnML";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ListBox lst_imagePathIn;
        private System.Windows.Forms.Button btn_loadFolderImgIn;
        private System.Windows.Forms.Button btn_AddLabel;
        private System.Windows.Forms.TextBox txt_AddLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ClearLabel;
        private System.Windows.Forms.ListView lv_LogInput;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btn_ExportFeature;
        private System.Windows.Forms.Button btn_Train;
        private System.Windows.Forms.Button btn_LoadModel;
        private System.Windows.Forms.ListBox lst_imagePathOut;
        private System.Windows.Forms.Button btn_loadFolderImgOut;
        private System.Windows.Forms.Label lb_Predict;
        private System.Windows.Forms.ListView lv_LogOutput;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btn_Predict;
        private System.Windows.Forms.TextBox txt_NameModel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ccb_TypeModel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ccb_TypeFeature;
    }
}