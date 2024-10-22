using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.ML;
using OfficeOpenXml;
using WK.Libraries.BetterFolderBrowserNS;


namespace IMGprocessing
{
    public partial class Frm_LearnML : Form
    {
        public class DataTrain
        {
            public string Label;
            public string PathImg;
            public DataTrain(string _label, string _pathImage)
            {
                Label = _label;
                PathImg = _pathImage;
            }
        }

        const int SIZE_W = 128;
        const int SIZE_H = 64;
        const string PATH_TRAIN = "data_Train.txt";
        string PATH_MODEL = "svm_model.yml";

        SVM svm;
        KNearest knn;

        int indexLoadImg_IN = 0;
        Mat LoadImg_IN;
        string pathFolderImg_IN;

        int indexLoadImg_OUT = 0;
        Mat LoadImg_OUT;
        string pathFolderImg_OUT;

        string filePath_IMSRC = "data_block.xlsx";


        public struct Model_Type
        {
            public const string SVM = "SVM";
            public const string KNN = "KNN";
            public const string CNN = "CNN";
        }

        public struct Feature_Type
        {
            public const string HOG = "HOG";
            public const string MEAN = "MEAN";
            public const string LBP = "LBP";
            public const string SURF = "SURF";        
        }

        public Frm_LearnML()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }

        Mat PreImageAI(Mat _img)
        {
            if (_img != null)
            {
                Mat image = new Mat();
                Cv2.Resize(_img, image, new OpenCvSharp.Size(SIZE_W, SIZE_H));
                var hog = new HOGDescriptor();    // Khởi tạo đối tượng HOGDescriptor
                hog.WinSize = new OpenCvSharp.Size(SIZE_W, SIZE_H);  // Kích thước cửa sổ HOG
                float[] descriptors = hog.Compute(image);
                // Chuyển đặc trưng thành Mat để dự đoán
                Mat sampleMat = new Mat(1, descriptors.Length, MatType.CV_32FC1);
                for (int i = 0; i < sampleMat.Rows; i++)
                {
                    sampleMat.Set<byte>(0, i, (byte)descriptors[i]);
                }
                return sampleMat;
            }
            else
            {
                return null;
            }        
        }

        bool grabIamge_IN()
        {
            try
            {
                LoadImg_IN = new Mat(lst_imagePathIn.Items[indexLoadImg_IN].ToString(), ImreadModes.Grayscale);
                pictureBox1.Image = LoadImg_IN.ToBitmap();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        bool grabIamge_OUT()
        {
            try
            {
                LoadImg_OUT = new Mat(lst_imagePathOut.Items[indexLoadImg_OUT].ToString(), ImreadModes.Grayscale);
                if (svm != null)
                {
                    Mat sampleMat = PreImageAI(LoadImg_OUT);
                    // Dự đoán nhãn
                    int result = (int)svm.Predict(sampleMat);
                    lb_Predict.Text = lstDataTrain[result].Label;
                }

                pictureBox2.Image = LoadImg_OUT.ToBitmap();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        #region INPUT_TRAIN
        List<DataTrain> lstDataTrain = new List<DataTrain>(); //TẬP TRAIN GỐC
        List<float[]> allDescriptors = new List<float[]>();
        List<int> allLabels = new List<int>();

        private void btn_loadFolderImg_Click(object sender, EventArgs e)
        {
            using (BetterFolderBrowser folderBrowser = new BetterFolderBrowser() { RootFolder = Directory.GetCurrentDirectory() })
            {
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    lst_imagePathIn.Items.Clear();
                    string[] paths = Directory.GetFiles(folderBrowser.SelectedFolder, "*", SearchOption.AllDirectories);
                    if (paths == null || paths.Length == 0) return;
                    pathFolderImg_IN = folderBrowser.SelectedFolder;
                    for (int i = 0; i < paths.Length; i++)
                    {
                        lst_imagePathIn.Items.Add(paths[i]);
                    }
                    indexLoadImg_IN = 0;
                    lst_imagePathIn.SelectedIndex = indexLoadImg_IN;
                    grabIamge_IN();
                    txt_AddLabel.Text = Path.GetFileName(folderBrowser.SelectedFolder);
                }
            }
        }

        private void listBoxImagePath_SelectedIndexChanged(object sender, EventArgs e) //In
        {
            indexLoadImg_IN = (sender as ListBox).SelectedIndex;
            grabIamge_IN();
        }

        private void btn_AddLabel_Click(object sender, EventArgs e)
        {
            if (txt_AddLabel.Text != "")
            {
                DataTrain trainNew = new DataTrain(txt_AddLabel.Text, pathFolderImg_IN);
                lstDataTrain.Add(trainNew);

                lv_LogInput.Items.Clear();
                foreach (DataTrain item in lstDataTrain)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = item.Label;
                    lvi.SubItems.Add(item.PathImg);
                    lv_LogInput.GridLines = true;
                    lv_LogInput.Items.Add(lvi);
                }
            }
        }

        private void btn_Train_Click(object sender, EventArgs e)
        {
            ClsDefine.PATH_FOLDER_AI = $"{ClsDefine.PATH_ROOT_APP}\\{ccb_TypeModel.Text}_{ccb_TypeFeature.Text}_{txt_NameModel.Text}";
            if (Directory.Exists(ClsDefine.PATH_FOLDER_AI) == false)
                Directory.CreateDirectory(ClsDefine.PATH_FOLDER_AI);


            //Trích xuất đặc trưng
            allDescriptors.Clear();
            allLabels.Clear();
            StreamWriter writer = new StreamWriter(ClsDefine.PATH_FOLDER_AI + "\\" +PATH_TRAIN);
            for (int i = 0; i < lstDataTrain.Count; i++)
            {
                string[] paths = Directory.GetFiles(lstDataTrain[i].PathImg, "*", SearchOption.AllDirectories);
                if (paths == null || paths.Length == 0)
                {
                    MessageBox.Show("Không có ảnh trong tập train");
                    return;
                }
                writer.WriteLine($"{lstDataTrain[i].Label}, {lstDataTrain[i].PathImg}");
                for (int idx = 0; idx < paths.Length; idx++)
                {
                    Mat image = Cv2.ImRead(paths[idx], ImreadModes.Grayscale);
                    Cv2.Resize(image, image, new OpenCvSharp.Size(SIZE_W, SIZE_H));
                    switch (ccb_TypeFeature.Text) //// có cách nào để trích xuất đặc trưng đồng bộ với tất cả hay không
                    {
                        case Feature_Type.HOG:
                            var hog = new HOGDescriptor();    // Khởi tạo đối tượng HOGDescriptor
                            hog.WinSize = new OpenCvSharp.Size(SIZE_W, SIZE_H);  // Kích thước cửa sổ HOG
                                                                                 // Trích xuất các đặc trưng HOG từ hình ảnh
                            float[] descriptors = hog.Compute(image);
                            allDescriptors.Add(descriptors);
                            allLabels.Add(i);
                            break;
                        case Feature_Type.LBP:
                            break;
                        case Feature_Type.SURF:
                            break;
                        case Feature_Type.MEAN:
                            break;
                        default:
                            MessageBox.Show("Feature không hợp lệ");
                            break;
                    }           
                }
            }
            writer.Close();
            //Chuyển dữ liệu đặc trưng sang Mat
            Mat trainDataMat = new Mat(allDescriptors.Count, allDescriptors[0].Length, MatType.CV_32FC1);
            Mat labelsMat = new Mat(allLabels.Count, 1, MatType.CV_32SC1);
            for (int i = 0; i < allDescriptors.Count; i++)
            {
                labelsMat.Set(i, 0, allLabels[i]);
                for (int j = 0; j < allDescriptors[0].Length; j++)
                {
                    trainDataMat.Set(i, j, allDescriptors[i][j]);
                }
            }

            if (ccb_TypeModel.Text == Model_Type.SVM)
            {
                // Khởi tạo mô hình SVM
                svm = SVM.Create();
                svm.Type = SVM.Types.CSvc;
                svm.KernelType = SVM.KernelTypes.Linear;  // Hoặc RBF kernel tùy vào bài toán
                svm.TermCriteria = new TermCriteria(CriteriaTypes.MaxIter, 1000, 1e-6);
                svm.Train(trainDataMat, SampleTypes.RowSample, labelsMat); // Train model
                // Lưu mô hình            
                svm.Save(ClsDefine.PATH_FOLDER_AI + "\\" + PATH_MODEL);
                MessageBox.Show("Hoàn thành huấn luyện SVM!");
            }
            else if (ccb_TypeModel.Text == Model_Type.KNN)
            {
                knn = KNearest.Create();
                knn.Train(trainDataMat, SampleTypes.RowSample, labelsMat);// Train model
                // Lưu mô hình
                knn.Save(ClsDefine.PATH_FOLDER_AI + "\\" + PATH_MODEL);
                MessageBox.Show("Hoàn thành huấn luyện KNN!");
            }
            else if (ccb_TypeModel.Text == Model_Type.CNN)
            {

            }
            else
            {
                MessageBox.Show("Không đúng loại Model");
            }     
        }

        private void btn_ExportFeature_Click(object sender, EventArgs e)
        {



        }

        #endregion INPUT_TRAIN


        #region OUTPUT_PREDICT
        private void btn_loadFolderImgOut_Click(object sender, EventArgs e)
        {
            using (BetterFolderBrowser folderBrowser = new BetterFolderBrowser() { RootFolder = Directory.GetCurrentDirectory() })
            {
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    lst_imagePathOut.Items.Clear();
                    string[] paths = Directory.GetFiles(folderBrowser.SelectedFolder, "*", SearchOption.AllDirectories);
                    if (paths == null || paths.Length == 0) return;
                    pathFolderImg_OUT = folderBrowser.SelectedFolder;
                    for (int i = 0; i < paths.Length; i++)
                    {
                        lst_imagePathOut.Items.Add(paths[i]);
                    }
                    indexLoadImg_OUT = 0;
                    lst_imagePathOut.SelectedIndex = indexLoadImg_OUT;
                    grabIamge_OUT();
                }
            }
        }

        private void btn_LoadModel_Click(object sender, EventArgs e)
        {
            try
            {
                svm = SVM.Load(PATH_MODEL);
                if (svm != null)
                {
                    btn_LoadModel.BackColor = Color.Green;
                    string[] lines = File.ReadAllLines(PATH_TRAIN);
                    lstDataTrain.Clear();
                    foreach (var item in lines)
                    {
                        string[] value = item.Split(',');
                        DataTrain trainNew = new DataTrain(value[0], value[1]);
                        lstDataTrain.Add(trainNew);
                    }
                }
                else btn_LoadModel.BackColor = Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                btn_LoadModel.BackColor = Color.Red;
            }
        }

        private void lst_imagePathOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexLoadImg_OUT = (sender as ListBox).SelectedIndex;
            grabIamge_OUT();
        }

        private void btn_Predict_Click(object sender, EventArgs e)
        {
            string[] paths = Directory.GetFiles(pathFolderImg_OUT, "*", SearchOption.AllDirectories);
            if (paths == null || paths.Length == 0 || svm == null) return;
            int countOK = 0;
            for (int i = 0; i < paths.Length; i++)
            {
                Mat imgLoad = new Mat(paths[i], ImreadModes.Grayscale);
                Mat sampleMat = PreImageAI(imgLoad);
                // Dự đoán nhãn
                int result = (int)svm.Predict(sampleMat);

                string label_predict = "";
                for (int j = 0; j < lstDataTrain.Count; j++)
                {
                    if (Path.GetFileName(paths[i]).Contains(lstDataTrain[j].Label))
                    {
                        label_predict = lstDataTrain[j].Label;
                        break;
                    }
                }

                if (label_predict == lstDataTrain[result].Label)
                {
                    countOK++;
                }
            }

            MessageBox.Show($"total:{paths.Length}, OK:{countOK} ");
        }

        #endregion OUTPUT_PREDICT





















        /* List<Vec3d> lstMean = new List<Vec3d>();
            List<Vec3d> lstPS = new List<Vec3d>();
            double count_W = imgInput_Gray.Cols / 16;
            double count_H = imgInput_Gray.Rows / 16;
            int sizeH = (int)(imgInput_Gray.Rows / count_H);
            int sizeW = (int)(imgInput_Gray.Cols / count_W);

            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet_Mean = package.Workbook.Worksheets.Add("AVG");
                ExcelWorksheet worksheet_PS = package.Workbook.Worksheets.Add("PS");
                for (int y = 0; y < count_H; y++)
                {
                    for (int x = 0; x < count_W; x++)
                    {
                        Rect roi = new Rect(x * sizeW, y * sizeH, sizeW, sizeH);
                        if ((imgInput_Gray.Rows - roi.Y) > 16 && (imgInput_Gray.Cols - roi.X) > 16)
                        {
                            Mat croppedImage = new Mat(imgInput_Gray, roi);
                            //Tính Mean
                            int xAvg = Caculate_Mean(croppedImage);
                            lstMean.Add(new Vec3d(x, y, xAvg));
                            worksheet_Mean.Cells[x + 1, y + 1].Value = xAvg;
                            //Tính Phương Sai
                            double Ps = Caculate_PhuongSai(croppedImage, xAvg);
                            lstPS.Add(new Vec3d(x, y, Ps));
                            worksheet_PS.Cells[x + 1, y + 1].Value = Ps;
                        }
                    }
                }
                FileInfo excelFile = new FileInfo(filePath_IMSRC);
                package.SaveAs(excelFile);
            }*/


        /* private static Mat AddGaussianNoise(Mat image)
         {
             // Tạo ảnh cùng kích thước với ảnh gốc để chứa noise
             Mat noise = new Mat(image.Size(), MatType.CV_8SC1); // Ảnh noise với kiểu dữ liệu int8
             // Tạo noise với phân bố Gaussian (mean = 0, stddev = 25)
             Cv2.Randn(noise, 0, 25); // 0 là mean, 25 là độ lệch chuẩn (stddev)
             // Chuyển đổi noise về dạng CV_8UC1 để cộng vào ảnh
             Mat noise8U = new Mat();
             Cv2.ConvertScaleAbs(noise, noise8U); // Chuyển từ int8 sang uint8
             // Thêm noise vào ảnh
             Mat noisyImage = new Mat();
             Cv2.Add(image, noise8U, noisyImage); // Cộng noise vào ảnh

             return image;
         }*/


        /* public void kyvong_phuongsai(Mat Input, Mat ImpulseNoise)
         {
             Mat imageNoise = new Mat(Input.Size(), MatType.CV_8UC3);
             Mat image = new Mat(Input.Size(), MatType.CV_8UC3);
             imageNoise = Input.Clone();
             image = Input.Clone();
             string sint = "";
             string sout = "";

             imageNoise = ImpulseNoise;

             for (int y = 0; y < image.Rows - 16; y += 16)
             {
                 for (int x = 0; x < image.Cols - 16; x += 16)
                 {
                     Rect recttemp = new Rect(x + 1, y + 1, 16, 16);
                     Mat tempin = new Mat(image, recttemp);
                     Mat tempout = new Mat(imageNoise, recttemp);
                     Cv2.CvtColor(tempin, tempin, ColorConversionCodes.BGR2GRAY);
                     Cv2.CvtColor(tempout, tempout, ColorConversionCodes.BGR2GRAY);
                     for (int z = 0; z < 16; z++)
                     {
                         for (int v = 0; v < 16; v++)
                         {
                             byte pix = (byte)(tempout.At<byte>(z, v) - tempin.At<byte>(z, v));
                             tempout.Set<byte>(z, v, pix);
                         }
                     }
                     float countint = 0;
                     float countout = 0;
                     float diffint = 0;
                     float diffout = 0;
                     // Điền giá trị ảnh vào cửa sổ lọc
                     for (int z = 0; z < 16; z++)
                     {
                         for (int v = 0; v < 16; v++)
                         {
                             countint = tempin.At<byte>(z, v);
                             countout = tempout.At<byte>(z, v);
                         }
                     }
                     countint = countint / (16 * 16);
                     countout = countout / (16 * 16);
                     for (int z = 0; z < 16; z++)
                     {
                         for (int v = 0; v < 16; v++)
                         {
                             diffint = (tempin.At<byte>(z, v) - countint) * (tempin.At<byte>(z, v) - countint);
                             diffout = (tempout.At<byte>(z, v) - countout) * (tempout.At<byte>(z, v) - countout);
                         }
                     }
                     diffint = diffint / (16 * 16);
                     diffout = diffout / (16 * 16);

                     label1.Text = countint.ToString();
                     label3.Text = diffint.ToString();
                     sint = sint + countint.ToString("f1") + ":" + diffint.ToString("f1") + "   ";
                     sout = sout + countout.ToString("f1") + ":" + diffout.ToString("f1") + "   ";
                 }
             }
             mint.Text = sint;
             mout.Text = sout;

         }*/

    }
}
