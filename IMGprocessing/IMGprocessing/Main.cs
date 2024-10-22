using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;
using System.IO;


namespace IMGprocessing
{
    public partial class Main : Form
    {
        enum TOOL_OPTION
        {
            EMPTY,
            BLOB,
        }

        Bitmap imgInput;
        Bitmap imgOutput;
        Mat imgInput_MatBgr;
        Mat imgInput_MatHsv;
        Mat imgOutput_Mat;

        Graphics grp;
        System.Drawing.Point P1_IMG;
        System.Drawing.Point P2_IMG;
        System.Drawing.Point P1_Display;
        System.Drawing.Point P2_Display;

        public Main()
        {
            InitializeComponent();
            grp = ptb_Display1.CreateGraphics();
            // Read Path, khởi tạo log
            ClsDefine.PATH_ROOT_APP = Application.StartupPath + "\\APP";
            ClsDefine.PATH_TOOL_PMALIGN_PATTEN = Application.StartupPath + @"\APP\Patten.bmp";
            if (Directory.Exists(ClsDefine.PATH_ROOT_APP) == false)
                Directory.CreateDirectory(ClsDefine.PATH_ROOT_APP);
            if (Directory.Exists(ClsDefine.PATH_LOG) == false)
                Directory.CreateDirectory(ClsDefine.PATH_LOG);
            ClsLog.LOG.Sequence(string.Format("Start APP {0}", ClsDefine._VERSION_));
            imgInput_MatHsv = new Mat();
        }


        //=========================== EVENT FILE ===========================//
        #region FILE
        private void InputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                imgInput = new Bitmap(openfile.FileName);
                imgInput_MatBgr = imgInput.ToMat();
                Cv2.CvtColor(imgInput_MatBgr, imgInput_MatHsv, ColorConversionCodes.BGR2HSV);
                ptb_Display1.Image = imgInput;
                ClsIni.WriteValue(ClsDefine.PATH_INI, ClsNameConfig.SECTION_IMAGE, ClsNameConfig.KEY_IMAGE_INPUT, openfile.FileName);
            }
        }

        private void Btn_LoadImgInput_Click(object sender, EventArgs e)
        {
            string filePath = ClsIni.ReadValue_str(ClsDefine.PATH_INI, ClsNameConfig.SECTION_IMAGE, ClsNameConfig.KEY_IMAGE_INPUT, "");
            imgInput = new Bitmap(filePath);
            imgInput_MatBgr = imgInput.ToMat();
            Cv2.CvtColor(imgInput_MatBgr, imgInput_MatHsv, ColorConversionCodes.BGR2HSV);
            ptb_Display1.Image = imgInput;
        }

        private void Btn_LoadImgOutput_Click(object sender, EventArgs e)
        {
            string filePath = ClsIni.ReadValue_str(ClsDefine.PATH_INI, ClsNameConfig.SECTION_IMAGE, ClsNameConfig.KEY_IMAGE_OUTPUT, "");
            imgOutput = new Bitmap(filePath);
            ptb_Display2.Image = imgOutput;
        }

        private void OutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                imgOutput = new Bitmap(openfile.FileName);
                ptb_Display2.Image = imgOutput;
                ClsIni.WriteValue(ClsDefine.PATH_INI, ClsNameConfig.SECTION_IMAGE, ClsNameConfig.KEY_IMAGE_OUTPUT, openfile.FileName);
            }
        }

        private void ClearImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ptb_Display1.Image = null;
            ptb_Display2.Image = null;
        }

        private void ImageOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "PNG Image|*.png|Bitmap Image|*bmp";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                ptb_Display2.Image.Save(saveFile.FileName);
            }
        }
        private void ImageInputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "PNG Image|*.png|Bitmap Image|*bmp";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                ptb_Display2.Image.Save(saveFile.FileName);
            }
        }
        #endregion
        //=========================== EVENT IMAGE PROCESS ===========================//
        // CÁC PROCESS CƠ BẢN NHƯ ROTATION - MEAN - GAUS - CANNY
        #region IMAGE Process
        private void GreyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imgOutput = ImageProcess.ConvertGrey(imgInput);
            ptb_Display2.Image = imgOutput;
        }

        private void MedianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imgOutput = ImageProcess.MedianFilter(imgInput, Convert.ToInt32(txt_K.Text));
            ptb_Display2.Image = imgOutput;
        }

        private void GaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imgOutput = ImageProcess.GaussianFilter(imgInput, Convert.ToInt32(txt_K.Text));
            ptb_Display2.Image = imgOutput;
        }

        private void SubtructToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int results = 0;
            ptb_Display1.Image = null;
            ptb_Display2.Image = ImageProcess.CompareImage(imgInput, imgOutput, ref results);
            MessageBox.Show(results.ToString());
        }

        private void BilateralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imgOutput = ImageProcess.BilateralFilter(imgInput, Convert.ToInt32(txt_K.Text), 0.5, 0.5);
            ptb_Display2.Image = imgOutput;
        }

        private void CannyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imgOutput = ImageProcess.Canny(imgInput);
            ptb_Display2.Image = imgOutput;
        }

        private void InputToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            imgInput = ImageProcess.Rotation(imgInput, Convert.ToDouble(txt_K.Text));
            ptb_Display1.Image = imgInput;
        }

        private void OutputToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            imgOutput = ImageProcess.Rotation(imgInput, Convert.ToDouble(txt_K.Text));
            ptb_Display2.Image = imgOutput;
        }

        private void iMGCaliperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imgOutput = ImageProcess.Calibper_Process(imgInput);
            ptb_Display2.Image = imgOutput;
        }

        private void sumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap img_1 = new Bitmap(@"D:\VISION\CODE MAU\GhepAnh\GhepAnh\bin\Debug\1.png");
            Bitmap img_2 = new Bitmap(@"D:\VISION\CODE MAU\GhepAnh\GhepAnh\bin\Debug\2.png");
            ptb_Display1.Image = img_1;
            imgOutput = ImageProcess.Merge_2Image(img_1, img_2);
            ptb_Display2.Image = imgOutput;
        }
        #endregion

        //=========================== EVENT TOOL VISION: PMALIGN ,.... ===========================//
        // BAO GỒM CÁC TOOL VISION NHƯ FINDLINE, PMALIGN, BLOB (CÁC TOOL CHIA THÀNH CÁC FRM RIÊNG)
        #region TOOL_VISION
        private void pMAlignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Pattem frm = new Frm_Pattem();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void bLOBToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion TOOL_VISION

        //=========================== EVENT TOOL AI ML DL ,.... ===========================//
        // BAO GỒM CÁC TOOL LIÊN QUAN ĐẾN AI
        #region TOOL_AI
        private void sVMToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_LearnML frm = new Frm_LearnML();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
        #endregion TOOL_AI


        //=========================== EVENT MOUSE - PICTURE ===========================//
        #region EVENT MOUSE PICTURE
        private void Ptb_Display1_MouseDown(object sender, MouseEventArgs e)
        {
            if (ptb_Display1.Image == null) return;
        }

        private void Ptb_Display1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (ptb_Display1.Image == null) return;
                P2_IMG = Convert_PosDisplay_To_PosIMG(imgInput, ptb_Display1, new System.Drawing.Point(e.X, e.Y));
                Vec3b pixelValue = imgInput_MatBgr.At<Vec3b>(P2_IMG.Y, P2_IMG.X);
                Vec3b pixelValue_Hsv = imgInput_MatHsv.At<Vec3b>(P2_IMG.Y, P2_IMG.X);
                int grayValue = (int)(0.3 * pixelValue.Item2 + 0.59 * pixelValue.Item1 + 0.11 * pixelValue.Item0);
                lb_PosDisplay_1.Text = string.Format("{0}  :  {1} - Grey= {2} (R:{3} G:{4} B:{5}) (H:{6} S:{7} V:{8})",
                    P2_IMG.X, P2_IMG.Y, grayValue, pixelValue.Item2, pixelValue.Item1, pixelValue.Item0, pixelValue_Hsv.Item0, pixelValue_Hsv.Item1, pixelValue_Hsv.Item2);
            }
            catch (Exception)
            { }
        }

        private void Ptb_Display1_MouseUp(object sender, MouseEventArgs e)
        { }

        private void ptb_Display1_Click(object sender, EventArgs e)
        {
            ShowLog_input(lb_PosDisplay_1.Text);
        }

        private void btn_ClearLogInput_Click(object sender, EventArgs e)
        {
            lv_LogInput.Items.Clear();
        }

        #endregion EVENT MOUSE PICTURE


        //=========================== TẤT CẢ CÁC HÀM ===========================//
        #region FUNTION 
        private Rectangle DrawRectangleAnyDirection(Graphics _grp, Pen _pen, System.Drawing.Point pt1, System.Drawing.Point pt2)
        {
            Rectangle rect;
            int[] arr_X = new int[] { pt1.X, pt2.X }; Array.Sort(arr_X);
            int[] arr_Y = new int[] { pt1.Y, pt2.Y }; Array.Sort(arr_Y);
            rect = new Rectangle(arr_X[0], arr_Y[0], arr_X[1] - arr_X[0], arr_Y[1] - arr_Y[0]);
            _grp.DrawRectangle(_pen, rect);
            return rect;
        }

        private System.Drawing.Point Convert_PosDisplay_To_PosIMG(Bitmap _img, PictureBox _ptb, System.Drawing.Point _point_Display)
        {
            int offsetX = 0;
            int offsetY = 0;
            double scale = (double)_img.Height / _ptb.ClientRectangle.Height;
            double s2 = (double)_img.Width / _ptb.ClientRectangle.Width;
            if (s2 > scale)
            {
                scale = s2;
                int picH = (int)(_img.Height / scale);
                offsetY = (_ptb.Height - picH) / 2;
            }
            else
            {
                int picW = (int)(_img.Width / scale);
                offsetX = (_ptb.Width - picW) / 2;
            }
            int X_IMG = (int)((_point_Display.X - offsetX) * scale);
            int Y_IMG = (int)((_point_Display.Y - offsetY) * scale);
            if (X_IMG < 0 || Y_IMG < 0 || X_IMG > _img.Width || Y_IMG > _img.Height) X_IMG = Y_IMG = 0;
            return new System.Drawing.Point(X_IMG, Y_IMG);
        }

        private System.Drawing.Point Convert_PosIMG_To_PosDisplay(Bitmap _img, PictureBox _ptb, System.Drawing.Point _point_Img)
        {
            int offsetX = 0;
            int offsetY = 0;
            double scale = (double)_img.Height / _ptb.ClientRectangle.Height;
            double s2 = (double)_img.Width / _ptb.ClientRectangle.Width;
            if (s2 > scale)
            {
                scale = s2;
                int picH = (int)(_img.Height / scale);
                offsetY = (_ptb.Height - picH) / 2;
            }
            else
            {
                int picW = (int)(_img.Width / scale);
                offsetX = (_ptb.Width - picW) / 2;
            }
            int X_DISPLAY = (int)((_point_Img.X / scale) + offsetX);
            int Y_DISPLAY = (int)((_point_Img.Y / scale) + offsetY);
            return new System.Drawing.Point(X_DISPLAY, Y_DISPLAY);
        }

        public void ShowLog_input(string log)
        {
            try
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = log;
                lv_LogInput.GridLines = true;
                lv_LogInput.Items.Add(lvi);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



















        #endregion FUNTION

        private void cNNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_CNN frm = new Frm_CNN();
            frm.ShowDialog();
        }
    }
}
