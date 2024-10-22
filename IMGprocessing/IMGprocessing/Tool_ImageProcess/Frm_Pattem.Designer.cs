
namespace IMGprocessing
{
    partial class Frm_Pattem
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
            this.btn_ManualPattern = new System.Windows.Forms.Button();
            this.btn_LoadImage = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_SetTemplate = new System.Windows.Forms.Button();
            this.btn_Test = new System.Windows.Forms.Button();
            this.lb_Result = new System.Windows.Forms.Label();
            this.btn_Blob = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_SpectArea = new System.Windows.Forms.TextBox();
            this.btn_Calib = new System.Windows.Forms.Button();
            this.lb_KichThuoc = new System.Windows.Forms.Label();
            this.lb_doCS = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(5, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(639, 535);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // btn_ManualPattern
            // 
            this.btn_ManualPattern.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ManualPattern.Location = new System.Drawing.Point(192, 670);
            this.btn_ManualPattern.Name = "btn_ManualPattern";
            this.btn_ManualPattern.Size = new System.Drawing.Size(178, 55);
            this.btn_ManualPattern.TabIndex = 1;
            this.btn_ManualPattern.Text = "Align (template)";
            this.btn_ManualPattern.UseVisualStyleBackColor = true;
            this.btn_ManualPattern.Click += new System.EventHandler(this.btn_ManualPattern_Click);
            // 
            // btn_LoadImage
            // 
            this.btn_LoadImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LoadImage.Location = new System.Drawing.Point(5, 610);
            this.btn_LoadImage.Name = "btn_LoadImage";
            this.btn_LoadImage.Size = new System.Drawing.Size(148, 55);
            this.btn_LoadImage.TabIndex = 1;
            this.btn_LoadImage.Text = "Load Image";
            this.btn_LoadImage.UseVisualStyleBackColor = true;
            this.btn_LoadImage.Click += new System.EventHandler(this.btn_LoadImage_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(650, 69);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(639, 535);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // btn_SetTemplate
            // 
            this.btn_SetTemplate.Location = new System.Drawing.Point(192, 610);
            this.btn_SetTemplate.Name = "btn_SetTemplate";
            this.btn_SetTemplate.Size = new System.Drawing.Size(178, 54);
            this.btn_SetTemplate.TabIndex = 3;
            this.btn_SetTemplate.Text = "Set Template";
            this.btn_SetTemplate.UseVisualStyleBackColor = true;
            this.btn_SetTemplate.Click += new System.EventHandler(this.btn_SetTemplate_Click);
            // 
            // btn_Test
            // 
            this.btn_Test.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Test.Location = new System.Drawing.Point(394, 670);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(160, 55);
            this.btn_Test.TabIndex = 1;
            this.btn_Test.Text = "Align (Countour)";
            this.btn_Test.UseVisualStyleBackColor = true;
            this.btn_Test.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // lb_Result
            // 
            this.lb_Result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Result.Location = new System.Drawing.Point(5, 9);
            this.lb_Result.Name = "lb_Result";
            this.lb_Result.Size = new System.Drawing.Size(639, 57);
            this.lb_Result.TabIndex = 4;
            this.lb_Result.Text = "RESULT";
            this.lb_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Blob
            // 
            this.btn_Blob.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Blob.Location = new System.Drawing.Point(599, 670);
            this.btn_Blob.Name = "btn_Blob";
            this.btn_Blob.Size = new System.Drawing.Size(178, 55);
            this.btn_Blob.TabIndex = 1;
            this.btn_Blob.Text = "BLOB";
            this.btn_Blob.UseVisualStyleBackColor = true;
            this.btn_Blob.Click += new System.EventHandler(this.btn_Blob_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(596, 629);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Spect Area";
            // 
            // txt_SpectArea
            // 
            this.txt_SpectArea.Location = new System.Drawing.Point(694, 626);
            this.txt_SpectArea.Name = "txt_SpectArea";
            this.txt_SpectArea.Size = new System.Drawing.Size(83, 22);
            this.txt_SpectArea.TabIndex = 6;
            this.txt_SpectArea.Text = "100";
            // 
            // btn_Calib
            // 
            this.btn_Calib.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Calib.Location = new System.Drawing.Point(5, 671);
            this.btn_Calib.Name = "btn_Calib";
            this.btn_Calib.Size = new System.Drawing.Size(148, 55);
            this.btn_Calib.TabIndex = 1;
            this.btn_Calib.Text = "Calibration";
            this.btn_Calib.UseVisualStyleBackColor = true;
            this.btn_Calib.Click += new System.EventHandler(this.btn_Calib_Click);
            // 
            // lb_KichThuoc
            // 
            this.lb_KichThuoc.AutoSize = true;
            this.lb_KichThuoc.Location = new System.Drawing.Point(810, 626);
            this.lb_KichThuoc.Name = "lb_KichThuoc";
            this.lb_KichThuoc.Size = new System.Drawing.Size(35, 17);
            this.lb_KichThuoc.TabIndex = 7;
            this.lb_KichThuoc.Text = "Size";
            // 
            // lb_doCS
            // 
            this.lb_doCS.AutoSize = true;
            this.lb_doCS.Location = new System.Drawing.Point(810, 670);
            this.lb_doCS.Name = "lb_doCS";
            this.lb_doCS.Size = new System.Drawing.Size(35, 17);
            this.lb_doCS.TabIndex = 7;
            this.lb_doCS.Text = "Size";
            // 
            // Frm_Pattem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1336, 736);
            this.Controls.Add(this.lb_doCS);
            this.Controls.Add(this.lb_KichThuoc);
            this.Controls.Add(this.txt_SpectArea);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_Result);
            this.Controls.Add(this.btn_SetTemplate);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btn_LoadImage);
            this.Controls.Add(this.btn_Blob);
            this.Controls.Add(this.btn_Test);
            this.Controls.Add(this.btn_Calib);
            this.Controls.Add(this.btn_ManualPattern);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Frm_Pattem";
            this.Text = "Frm_Pattem";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_ManualPattern;
        private System.Windows.Forms.Button btn_LoadImage;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn_SetTemplate;
        private System.Windows.Forms.Button btn_Test;
        private System.Windows.Forms.Label lb_Result;
        private System.Windows.Forms.Button btn_Blob;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_SpectArea;
        private System.Windows.Forms.Button btn_Calib;
        private System.Windows.Forms.Label lb_KichThuoc;
        private System.Windows.Forms.Label lb_doCS;
    }
}