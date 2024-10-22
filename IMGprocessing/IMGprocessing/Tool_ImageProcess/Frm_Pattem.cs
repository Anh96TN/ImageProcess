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

namespace IMGprocessing
{
    public partial class Frm_Pattem : Form
    {
        Pen Redpen = new Pen(Color.Red, 1);
        Pen Yellowpen = new Pen(Color.Yellow, 1);
        Pen Greenpen = new Pen(Color.Green, 1);

        Mat imgInput_MatGrey = new Mat();
        Mat PM_imgTemplateGrey = new Mat();
        Mat Blob_imgGrey = new Mat();
        bool Is_Select_Region = false;
        bool Is_Draw_Region = false;

        System.Drawing.Point P1_IMG;
        System.Drawing.Point P2_IMG;
        System.Drawing.Point P1_Display;
        System.Drawing.Point P2_Display;
        Pen pen = new Pen(Color.Red);
        Graphics grp;
        Rectangle rect;
        OpenCvSharp.Rect roiSelect;
        RotatedRect rotatedRect_Calib;
        float SCALE_CALIBRATION = 1;

        bool IsAlignOK = false;

        private List<temFound> lstTemFound = new List<temFound>();

        struct temFound
        {
            public Point2d Point;
            public double Angle;
            public double Score;
            public double Scale;
        }

        public Frm_Pattem()
        {
            InitializeComponent();
            grp = pictureBox1.CreateGraphics();
        }

        private void btn_ManualPattern_Click(object sender, EventArgs e)
        {
            if (imgInput_MatGrey == null && pictureBox1.Image == null) return;
            double angle = 90.0, score = 0.85, startScale = 0.95, endScale = 1.05;
            if (endScale < startScale)
            {
                MessageBox.Show("Start scale > End scale");
                return;
            }

            Mat matToFind = new Mat();
            imgInput_MatGrey.CopyTo(matToFind);
            Cv2.CvtColor(matToFind, matToFind, ColorConversionCodes.GRAY2BGR);
            double diffScale = endScale - startScale;
            double stepScale = 0.05;
            List<temFound> lstTemFoundComplete = new List<temFound>();
            int spec = 50;
            for (double scaleIndex = startScale; scaleIndex <= endScale; scaleIndex += stepScale)
            {
                scaleIndex = Math.Round(scaleIndex, 2);
                Mat TempleteImgScale = new Mat();
                Cv2.Resize(PM_imgTemplateGrey, TempleteImgScale, new OpenCvSharp.Size((int)((double)PM_imgTemplateGrey.Width * scaleIndex), (int)((double)PM_imgTemplateGrey.Height * scaleIndex)));
                SeachMatchTemplete(imgInput_MatGrey, TempleteImgScale, -angle, angle, score, scaleIndex);
                if (lstTemFound.Count == 0) continue;
                if (lstTemFoundComplete.Count == 0) lstTemFoundComplete.Add(lstTemFound[0]);
                int indexCheck = 0;
                for (int i = 0; i < lstTemFound.Count; i++)
                {
                    for (int indexTemComplete = 0; indexTemComplete < lstTemFoundComplete.Count; indexTemComplete++)
                    {
                        if (lstTemFoundComplete[indexTemComplete].Point.X < (lstTemFound[i].Point.X + spec)
                                && lstTemFoundComplete[indexTemComplete].Point.X > (lstTemFound[i].Point.X - spec)
                                && lstTemFoundComplete[indexTemComplete].Point.Y < (lstTemFound[i].Point.Y + spec)
                                && lstTemFoundComplete[indexTemComplete].Point.Y > (lstTemFound[i].Point.Y - spec))
                        {
                            if (lstTemFoundComplete[indexTemComplete].Score < lstTemFound[i].Score)
                            {
                                lstTemFoundComplete[indexTemComplete] = new temFound()
                                {
                                    Score = lstTemFound[i].Score,
                                    Point = new Point2d(lstTemFound[i].Point.X, lstTemFound[i].Point.Y),
                                    Angle = lstTemFound[i].Angle,
                                    Scale = lstTemFound[i].Scale
                                };
                            }
                        }
                        else
                        {
                            indexCheck++;
                        }
                    }
                    if (indexCheck == lstTemFoundComplete.Count)
                    {
                        lstTemFoundComplete.Add(new temFound()
                        {
                            Score = lstTemFound[i].Score,
                            Point = new Point2d(lstTemFound[i].Point.X, lstTemFound[i].Point.Y),
                            Angle = lstTemFound[i].Angle,
                            Scale = lstTemFound[i].Scale
                        });
                    }
                    indexCheck = 0;
                }
                TempleteImgScale.Dispose();
            }
            //Point2f center = new Point2f();
            Point2d refPoint = new Point2d();
            double _angle = 0;
            for (int j = 0; j < lstTemFoundComplete.Count; j++)
            {
                double offsetX1, offsetY1, offsetX2, offsetY2;
                _angle = lstTemFoundComplete[j].Angle * Math.PI / 180;
                double width = PM_imgTemplateGrey.Width * lstTemFoundComplete[j].Scale;
                double height = PM_imgTemplateGrey.Height * lstTemFoundComplete[j].Scale;
                Point2d LeftTop = new OpenCvSharp.Point2d(lstTemFoundComplete[j].Point.X, lstTemFoundComplete[j].Point.Y);
                refPoint.X = LeftTop.X;
                refPoint.Y = LeftTop.Y;
                offsetX1 = Math.Cos(lstTemFoundComplete[j].Angle * Math.PI / 180) * width;
                offsetY1 = Math.Sin(lstTemFoundComplete[j].Angle * Math.PI / 180) * width;
                Point2d RightTop = new OpenCvSharp.Point2d(lstTemFoundComplete[j].Point.X + offsetX1, lstTemFoundComplete[j].Point.Y + offsetY1);
                offsetX2 = Math.Sin(lstTemFoundComplete[j].Angle * Math.PI / 180) * height;
                offsetY2 = Math.Cos(lstTemFoundComplete[j].Angle * Math.PI / 180) * height;
                Point2d LeftBot = new OpenCvSharp.Point2d(lstTemFoundComplete[j].Point.X - offsetX2, lstTemFoundComplete[j].Point.Y + offsetY2);
                Point2d RightBot = new OpenCvSharp.Point2d(LeftBot.X + offsetX1, LeftBot.Y + offsetY1);
                OpenCvSharp.Point2d CenterPoint = new OpenCvSharp.Point2d();
                CenterPoint.X = ((double)(LeftTop.X + RightTop.X + RightBot.X + LeftBot.X) / 4);
                CenterPoint.Y = ((double)(LeftTop.Y + RightTop.Y + RightBot.Y + LeftBot.Y) / 4);
                Cv2.Circle(matToFind, (int)CenterPoint.X, (int)CenterPoint.Y, 5, new Scalar(0, 255, 0), 2, LineTypes.AntiAlias);
                OpenCvSharp.Point[] polyP = new OpenCvSharp.Point[4] { ((OpenCvSharp.Point)LeftTop), (OpenCvSharp.Point)RightTop, (OpenCvSharp.Point)RightBot, (OpenCvSharp.Point)LeftBot };
                Cv2.Polylines(matToFind, new OpenCvSharp.Point[][] { polyP }, true, new Scalar(0, 255, 0), 2, LineTypes.AntiAlias);
                Cv2.PutText(matToFind, string.Format("Score: {0}", Math.Round(lstTemFoundComplete[j].Score, 2)), (OpenCvSharp.Point)CenterPoint, HersheyFonts.Italic, 0.5, new Scalar(0, 0, 255));
                Cv2.PutText(matToFind, string.Format("X: {0}; Y: {1}", Math.Round(CenterPoint.X, 2), Math.Round(CenterPoint.Y, 2)), new OpenCvSharp.Point(CenterPoint.X, CenterPoint.Y + 15), HersheyFonts.Italic, 0.5, new Scalar(0, 0, 255));
                Cv2.PutText(matToFind, string.Format("Angle: {0}", Math.Round(lstTemFoundComplete[j].Angle, 2)), new OpenCvSharp.Point(CenterPoint.X, CenterPoint.Y + 30), HersheyFonts.Italic, 0.5, new Scalar(0, 0, 255));
                Cv2.PutText(matToFind, string.Format("Scale: {0}", Math.Round(lstTemFoundComplete[j].Scale, 2)), new OpenCvSharp.Point(CenterPoint.X, CenterPoint.Y + 45), HersheyFonts.Italic, 0.5, new Scalar(0, 0, 255));
                //UpdateListView(new string[] { DateTime.Now.ToString("HH:mm:ss"), $"Score = {Math.Round(lstTemFoundComplete[j].Score, 2)}, Position = ({Math.Round(CenterPoint.X, 2)},{Math.Round(CenterPoint.Y, 2)}), Angle = {lstTemFoundComplete[j].Angle}, Scale = {lstTemFoundComplete[j].Scale}" });
                //WriteLog(Type.Pattern, $"Score = {Math.Round(lstTemFoundComplete[j].Score, 2)}, Position = ({Math.Round(CenterPoint.X, 2)},{Math.Round(CenterPoint.Y, 2)}), Angle = {lstTemFoundComplete[j].Angle}, Scale = {lstTemFoundComplete[j].Scale}");
            }
            pictureBox2.Image = matToFind.ToBitmap();
        }

        private void btn_LoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                imgInput_MatGrey = Cv2.ImRead(openfile.FileName, ImreadModes.Grayscale);
                OpenCvSharp.Size dsize = new OpenCvSharp.Size(imgInput_MatGrey.Cols * 0.2, imgInput_MatGrey.Rows * 0.2);
                Cv2.Resize(imgInput_MatGrey, imgInput_MatGrey, dsize);
                pictureBox1.Image = imgInput_MatGrey.ToBitmap();
                IsAlignOK = false;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (imgInput_MatGrey == null && pictureBox1.Image == null) return;
                if (Is_Select_Region == true)
                {
                    Is_Draw_Region = true;
                    P1_IMG = Convert_PosDisplay_To_PosIMG(imgInput_MatGrey, pictureBox1, new System.Drawing.Point(e.X, e.Y));
                    P1_Display = new System.Drawing.Point(e.X, e.Y);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (imgInput_MatGrey == null && pictureBox1.Image == null) return;
                P2_IMG = Convert_PosDisplay_To_PosIMG(imgInput_MatGrey, pictureBox1, new System.Drawing.Point(e.X, e.Y));

                if (Is_Draw_Region == true && Is_Select_Region == true)
                {
                    P2_Display = new System.Drawing.Point(e.X, e.Y);
                    pen = Redpen;
                    pictureBox1.Refresh();
                    rect = DrawRectangleAnyDirection(grp, pen, P1_Display, P2_Display);
                }
            }
            catch (Exception)
            { }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (imgInput_MatGrey == null && pictureBox1.Image == null) return;
                if (Is_Draw_Region == true && Is_Select_Region == true)
                {
                    grp.DrawRectangle(Redpen, rect);
                    roiSelect = new OpenCvSharp.Rect(P1_IMG.X, P1_IMG.Y, Math.Abs(P1_IMG.X - P2_IMG.X), Math.Abs(P1_IMG.Y - P2_IMG.Y));
                    PM_imgTemplateGrey = new Mat(imgInput_MatGrey, roiSelect);
                    pictureBox2.Image = PM_imgTemplateGrey.ToBitmap();
                    Is_Draw_Region = false;
                }
                Is_Select_Region = false;
                btn_SetTemplate.UseVisualStyleBackColor = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_SetTemplate_Click(object sender, EventArgs e)
        {
            if (Is_Select_Region == false)
            {
                Is_Select_Region = true;
                btn_SetTemplate.BackColor = Color.Green;
            }
            else
            {
                Is_Select_Region = false;
                btn_SetTemplate.UseVisualStyleBackColor = true;
            }
        }

        private System.Drawing.Point Convert_PosDisplay_To_PosIMG(Mat _img, PictureBox _ptb, System.Drawing.Point _point_Display)
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

        private Rectangle DrawRectangleAnyDirection(Graphics _grp, Pen _pen, System.Drawing.Point pt1, System.Drawing.Point pt2)
        {
            Rectangle rect;
            int[] arr_X = new int[] { pt1.X, pt2.X }; Array.Sort(arr_X);
            int[] arr_Y = new int[] { pt1.Y, pt2.Y }; Array.Sort(arr_Y);
            rect = new Rectangle(arr_X[0], arr_Y[0], arr_X[1] - arr_X[0], arr_Y[1] - arr_Y[0]);
            _grp.DrawRectangle(_pen, rect);
            return rect;
        }

        void SeachMatchTemplete(Mat InputImage, Mat TempleteImg, double startAngle, double endAngle, double threshold, double scale)
        {
            try
            {
                double distance = Math.Sqrt(Math.Pow((double)InputImage.Width, 2) + Math.Pow((double)InputImage.Height, 2)) * 1.2;
                Mat dtsTranForm = new Mat((int)distance,
                                          (int)distance,
                                          InputImage.Type());

                Point2f inImgCP = new Point2f((float)InputImage.Width / 2, (float)InputImage.Height / 2);
                Point2f outImgCP = new Point2f((float)dtsTranForm.Width / 2, (float)dtsTranForm.Height / 2);
                lstTemFound.Clear();
                OpenCvSharp.Point offset = new OpenCvSharp.Point();
                offset.X = (int)((double)dtsTranForm.Width / 2 - (double)InputImage.Width / 2);
                offset.Y = (int)((double)dtsTranForm.Height / 2 - (double)InputImage.Height / 2);
                double step = 5;
                int spec = 50; //pixels
                for (double angle = startAngle; startAngle <= angle && angle <= endAngle; angle += step)
                {
                    Mat rotMatrix = Cv2.GetRotationMatrix2D(inImgCP, -angle, 1);
                    rotMatrix.Set<double>(0, 2, rotMatrix.Get<double>(0, 2) + offset.X);
                    rotMatrix.Set<double>(1, 2, rotMatrix.Get<double>(1, 2) + offset.Y);
                    Cv2.WarpAffine(InputImage, dtsTranForm, rotMatrix, dtsTranForm.Size());
                    Mat result = new Mat();
                    Cv2.MatchTemplate(dtsTranForm, TempleteImg, result, TemplateMatchModes.CCoeffNormed);
                    Cv2.Threshold(result, result, 0.8, 1, ThresholdTypes.Tozero);
                    while (true)
                    {
                        double minval, maxval;
                        OpenCvSharp.Point minloc, maxloc = new OpenCvSharp.Point();
                        Cv2.MinMaxLoc(result, out minval, out maxval, out minloc, out maxloc);
                        if (maxval > threshold)
                        {
                            Cv2.FloodFill(result, maxloc, new Scalar(0));

                            if (lstTemFound.Count == 0)
                            {
                                lstTemFound.Add(new temFound(
                                    )
                                {
                                    Score = maxval,
                                    Point = new Point2d(maxloc.X, maxloc.Y),
                                    Angle = angle,
                                    Scale = scale
                                });
                            }
                            for (int i = 0; i < lstTemFound.Count; i++)
                            {
                                if (angle == lstTemFound[i].Angle)
                                {
                                    if (maxloc.X < (lstTemFound[i].Point.X + spec)
                                       && maxloc.X > (lstTemFound[i].Point.X - spec)
                                       && maxloc.Y < (lstTemFound[i].Point.Y + spec)
                                       && maxloc.Y > (lstTemFound[i].Point.Y - spec))
                                    {
                                        if (maxval > lstTemFound[i].Score)
                                        {

                                            lstTemFound[i] = new temFound()
                                            {
                                                Score = maxval,
                                                Point = new Point2d(maxloc.X, maxloc.Y),
                                                Angle = angle,
                                                Scale = scale
                                            };
                                        }
                                        continue;
                                    }
                                }
                                else
                                {
                                    lstTemFound.Add(new temFound(
                                    )
                                    {
                                        Score = maxval,
                                        Point = new Point2d(maxloc.X, maxloc.Y),
                                        Angle = angle,
                                        Scale = scale
                                    });
                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    rotMatrix.Dispose();
                    result.Dispose();
                }
                List<temFound> lstTemFoundFilter = new List<temFound>();
                int index = 0;
                if (lstTemFound.Count == 0) return;
                if (lstTemFoundFilter.Count == 0) lstTemFoundFilter.Add(lstTemFound[0]);
                for (int i = 0; i < lstTemFound.Count; i++)
                {
                    if (lstTemFound[i].Point.X < (lstTemFoundFilter[index].Point.X + spec)
                                   && lstTemFound[i].Point.X > (lstTemFoundFilter[index].Point.X - spec)
                                   && lstTemFound[i].Point.Y < (lstTemFoundFilter[index].Point.Y + spec)
                                   && lstTemFound[i].Point.Y > (lstTemFoundFilter[index].Point.Y - spec))
                    {
                        if (lstTemFoundFilter[index].Score < lstTemFound[i].Score)
                        {
                            lstTemFoundFilter[index] = lstTemFound[i];
                            continue;
                        }
                    }
                    else
                    {
                        lstTemFoundFilter.Add(lstTemFound[i]);
                        index++;
                    }
                }
                lstTemFound = lstTemFoundFilter;
                step /= 10;
                List<double> LstDeg = new List<double>();
                for (int i = 0; i < lstTemFound.Count; i++)
                {
                    LstDeg.Add(lstTemFound[i].Angle);
                }
                for (int i = 0; i < lstTemFound.Count; i++)
                {
                    for (double angle = (LstDeg[i] - 5); (LstDeg[i] - 5) <= angle && angle <= (LstDeg[i] + 5); angle += step)
                    {
                        Mat rotMatrix = Cv2.GetRotationMatrix2D(inImgCP, -angle, 1);
                        rotMatrix.Set<double>(0, 2, rotMatrix.Get<double>(0, 2) + offset.X);
                        rotMatrix.Set<double>(1, 2, rotMatrix.Get<double>(1, 2) + offset.Y);
                        Cv2.WarpAffine(InputImage, dtsTranForm, rotMatrix, dtsTranForm.Size());
                        Mat result = new Mat();
                        Cv2.MatchTemplate(dtsTranForm, TempleteImg, result, TemplateMatchModes.CCoeffNormed);
                        Cv2.Threshold(result, result, 0.8, 1, ThresholdTypes.Tozero);
                        double minval, maxval;
                        OpenCvSharp.Point minloc, maxloc = new OpenCvSharp.Point();
                        Cv2.MinMaxLoc(result, out minval, out maxval, out minloc, out maxloc);
                        if (maxval > lstTemFound[i].Score)
                        {
                            lstTemFound[i] = new temFound()
                            {
                                Score = maxval,
                                Point = new Point2d(maxloc.X, maxloc.Y),
                                Angle = angle,
                                Scale = scale
                            };
                        }
                        rotMatrix.Dispose();
                        result.Dispose();
                    }
                }
                LstDeg.Clear();
                for (int i = 0; i < lstTemFound.Count; i++)
                {
                    LstDeg.Add(lstTemFound[i].Angle);
                }
                step /= 10;
                for (int i = 0; i < lstTemFound.Count; i++)
                {
                    for (double angle = (LstDeg[i] - (double)0.5); (LstDeg[i] - (double)0.5) <= angle && angle <= (LstDeg[i] + (double)0.5); angle += step)
                    {
                        angle = Math.Round(angle, 2);
                        Mat rotMatrix = Cv2.GetRotationMatrix2D(inImgCP, -angle, 1);
                        rotMatrix.Set<double>(0, 2, rotMatrix.Get<double>(0, 2) + offset.X);
                        rotMatrix.Set<double>(1, 2, rotMatrix.Get<double>(1, 2) + offset.Y);
                        Cv2.WarpAffine(InputImage, dtsTranForm, rotMatrix, dtsTranForm.Size());
                        Mat result = new Mat();
                        Cv2.MatchTemplate(dtsTranForm, TempleteImg, result, TemplateMatchModes.CCoeffNormed);
                        Cv2.Threshold(result, result, 0.8, 1, ThresholdTypes.Tozero);
                        double minval, maxval;
                        OpenCvSharp.Point minloc, maxloc = new OpenCvSharp.Point();
                        Cv2.MinMaxLoc(result, out minval, out maxval, out minloc, out maxloc);
                        if (maxval > lstTemFound[i].Score)
                        {
                            lstTemFound[i] = new temFound()
                            {
                                Score = maxval,
                                Point = new Point2d(maxloc.X, maxloc.Y),
                                Angle = angle,
                                Scale = scale
                            };
                        }
                        rotMatrix.Dispose();
                        result.Dispose();
                    }
                }

                for (int i = 0; i < lstTemFound.Count; i++)
                {
                    Point2d pointTemFromImgTranformCalCP = lstTemFound[i].Point - new Point2d(outImgCP.X, outImgCP.Y);
                    Point2d pointTemFromImgTranformCalCPBackRotation = Rotate(pointTemFromImgTranformCalCP, -lstTemFound[i].Angle * Math.PI / 180);
                    Point2d pointTemFromImgInputCalCp = pointTemFromImgTranformCalCPBackRotation + new Point2d(inImgCP.X, inImgCP.Y);
                    lstTemFound[i] = new temFound()
                    {
                        Score = lstTemFound[i].Score,
                        Point = pointTemFromImgInputCalCp,
                        Angle = -lstTemFound[i].Angle,
                        Scale = lstTemFound[i].Scale
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        static public Point2d Rotate(Point2d point, double thetaRad)
        {
            Point2d result = new Point2d();
            result.X = Math.Cos(thetaRad) * point.X - Math.Sin(thetaRad) * point.Y;
            result.Y = Math.Sin(thetaRad) * point.X + Math.Cos(thetaRad) * point.Y;
            return result;
        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            Mat imgColor = new Mat();
            imgInput_MatGrey.CopyTo(imgColor);
            Cv2.CvtColor(imgColor, imgColor, ColorConversionCodes.GRAY2BGR);
            Mat invertedImg = new Mat();
            Cv2.BitwiseNot(imgInput_MatGrey, invertedImg);
            Mat imgBin = new Mat();
            Cv2.Threshold(invertedImg, imgBin, 130, 255, ThresholdTypes.Binary);
            OpenCvSharp.Point[][] contours;
            HierarchyIndex[] hierarchyIndices;
            Cv2.FindContours(imgBin, out contours, out hierarchyIndices, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
            double areaMax = 0;
            int idx = 0;
            for (int i = 0; i < contours.Length; i++)
            {
                Rect boundingRect = Cv2.BoundingRect(contours[i]);
                if (boundingRect.Width > 5 && boundingRect.Height > 7)
                {
                    double area = Cv2.ContourArea(contours[i]);
                    if (area > areaMax)
                    {
                        areaMax = area;
                        idx = i;
                    }
                }
            }

            if (contours.Length > 0 && areaMax < 70000)
            {
                //Vẽ vùng Bouding
                OpenCvSharp.Point[] contour = contours[idx];
                RotatedRect rotatedRect = Cv2.MinAreaRect(contour);
                rotatedRect_Calib = rotatedRect;
                OpenCvSharp.Point2f[] rectPoints_bouding = rotatedRect.Points();
                for (int i = 0; i < 4; i++)
                {
                    Cv2.Line(imgColor, (OpenCvSharp.Point)rectPoints_bouding[i], (OpenCvSharp.Point)rectPoints_bouding[(i + 1) % 4], Scalar.Red, 2); // Nối các đỉnh
                }
                OpenCvSharp.Point ptcen = new OpenCvSharp.Point(rotatedRect.Center.X, rotatedRect.Center.Y);
                Cv2.Circle(imgColor, ptcen, 5, Scalar.Green, -1);

                double w_mm = Math.Round(rotatedRect.Size.Width*SCALE_CALIBRATION,4);
                double h_mm = Math.Round(rotatedRect.Size.Height*SCALE_CALIBRATION,4);
                double x_cen = Math.Round(ptcen.X * SCALE_CALIBRATION,4);
                double y_cen = Math.Round(ptcen.Y * SCALE_CALIBRATION,4);
                string s = Check_(rotatedRect.Size.Width, rotatedRect.Size.Height);
                lb_doCS.Text = s;
                lb_KichThuoc.Text = $"W= {w_mm},  H= {h_mm}, X_center = {x_cen}, Y_center = {y_cen}";
                ////////////////////////////// Blob=============================
                // Tìm hình chữ nhật xoay nhỏ nhất bao quanh contour
                // 1. Thu nhỏ hình chữ nhật
                Size2f newSize = new Size2f(rotatedRect.Size.Width - 25, rotatedRect.Size.Height - 25);
                RotatedRect scaledRotatedRect = new RotatedRect(rotatedRect.Center, newSize, rotatedRect.Angle);
                // 3. Lấy các điểm của hình chữ nhật xoay đã thu nhỏ
                OpenCvSharp.Point2f[] rectPoints = scaledRotatedRect.Points();
                // 4. Tạo ma trận affine để cắt phần hình ảnh
                OpenCvSharp.Point2f[] srcPoints = rectPoints; // Điểm nguồn là các đỉnh của rotatedRect đã xoay
                OpenCvSharp.Point2f[] dstPoints = {
                new OpenCvSharp.Point2f(0, newSize.Height - 1), // Bottom-left
                new OpenCvSharp.Point2f(0, 0),                  // Top-left
                new OpenCvSharp.Point2f(newSize.Width - 1, 0)};   // Top-right
                // Tạo ma trận biến đổi affine
                Mat affineMatrix = Cv2.GetAffineTransform(srcPoints.Take(3).ToArray(), dstPoints);
                // Cắt ảnh theo hình chữ nhật đã xoay và thu nhỏ
                Cv2.WarpAffine(imgInput_MatGrey, Blob_imgGrey, affineMatrix, new OpenCvSharp.Size((int)newSize.Width, (int)newSize.Height));

                lb_Result.Text = "OK";
                lb_Result.BackColor = Color.Green;
                IsAlignOK = true;
            }
            else if (areaMax > 70000)
            {
                lb_Result.Text = "NG AREA";
                lb_Result.BackColor = Color.Red;
            }
            else
            {
                lb_Result.Text = "NG";
                lb_Result.BackColor = Color.Red;
            }
            pictureBox2.Image = imgColor.ToBitmap();
            pictureBox1.Image = Blob_imgGrey.ToBitmap();
        }

        private void btn_Blob_Click(object sender, EventArgs e)
        {
            if (IsAlignOK == true)
            {
                lb_Result.Text = "OK";
                lb_Result.BackColor = Color.Green;
                Mat imgColor = new Mat();
                Blob_imgGrey.CopyTo(imgColor);
                Cv2.CvtColor(imgColor, imgColor, ColorConversionCodes.GRAY2BGR);
                Mat imgBin = new Mat();
                Cv2.Threshold(Blob_imgGrey, imgBin, 130, 255, ThresholdTypes.Binary);
                OpenCvSharp.Point[][] contours;
                HierarchyIndex[] hierarchyIndices;
                Cv2.FindContours(imgBin, out contours, out hierarchyIndices, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

                int Spect_Area = 50;
                int.TryParse(txt_SpectArea.Text, out Spect_Area);

                for (int i = 0; i < contours.Length; i++)
                {
                    Rect boundingRect = Cv2.BoundingRect(contours[i]);
                    double area = Cv2.ContourArea(contours[i]);
                    if (area > Spect_Area)
                    {
                        Cv2.DrawContours(imgColor, contours, i, Scalar.Red, 1);
                        lb_Result.Text = "NG";
                        lb_Result.BackColor = Color.Red;
                    }
                }
                pictureBox1.Image = imgBin.ToBitmap();
                pictureBox2.Image = imgColor.ToBitmap();
            }
            else
            {
                MessageBox.Show("Chưa chạy Align");
            }      
        }

        private void btn_Calib_Click(object sender, EventArgs e)
        {
            btn_Test_Click(sender, e);
            Calibration(rotatedRect_Calib);
            MessageBox.Show("Calib OK");
            btn_Calib.BackColor = Color.Green;
        }

        public double Calibration(RotatedRect rotatedRect, float Width_mm=77, float Hei_mm=162)
        {
            float CD, CR;
            if (rotatedRect.Size.Width > rotatedRect.Size.Height)
            {
                CD = rotatedRect.Size.Width; CR = rotatedRect.Size.Height;
            }
            else
            {
                CD = rotatedRect.Size.Height; CR = rotatedRect.Size.Width;
            }

            float scale_x = 1;
            float scale_y = 1;
            scale_x = Width_mm / CR;
            scale_y = Hei_mm / CD;       
            return SCALE_CALIBRATION = (scale_x + scale_y)/2;
        }
       
        private string Check_(double CR, double CD)
        {
            if (CR > CD)
            {
                double tmp = CR;
                CR = CD; 
                CD = tmp;
            }

            double Width = 77;
            double Height = 162;
            double ratioX = CR * SCALE_CALIBRATION * 100 / Width;
            double ratioY = CD * SCALE_CALIBRATION * 100 / Height;
            string ratio = "Width Matching: " + ratioX.ToString("F3") + "%" + "\n"
                + "Height Matching:" + ratioY.ToString("F3") + "%";
            return ratio;
        }
    }
}
