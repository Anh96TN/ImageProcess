using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;
using System.Windows.Forms;


namespace IMGprocessing
{
    class ImageProcess
    {
        public static Bitmap ConvertGrey(Bitmap image)
        {
            Mat img_source = BitmapConverter.ToMat(image);
            if (image != null)
            {
                if (img_source.Type() != MatType.CV_8UC1)
                    Cv2.CvtColor(img_source, img_source, ColorConversionCodes.RGB2GRAY);
            }
            return img_source.ToBitmap();
        }

        public static Bitmap MedianFilter(Bitmap image, int ksize)
        {
            Mat img_des = new Mat();
            if (image != null)
            {
                Mat img_source = BitmapConverter.ToMat(image);
                if (img_source.Type() != MatType.CV_8UC1)
                    Cv2.CvtColor(img_source, img_source, ColorConversionCodes.RGB2GRAY);
                Cv2.MedianBlur(img_source, img_des, ksize);
            }
            return img_des.ToBitmap();
        }

        public static Bitmap GaussianFilter(Bitmap image, int ksize)
        {
            Mat img_des = new Mat();
            if (image != null)
            {
                Mat img_source = BitmapConverter.ToMat(image);
                if (img_source.Type() != MatType.CV_8UC1)
                    Cv2.CvtColor(img_source, img_source, ColorConversionCodes.RGB2GRAY);
                OpenCvSharp.Size Ksize = new OpenCvSharp.Size(ksize, ksize);
                Cv2.GaussianBlur(img_source, img_des, Ksize, 1, 1, BorderTypes.Default);
            }
            return img_des.ToBitmap();
        }

        public static Bitmap BilateralFilter(Bitmap image, int d, double sigmacolor, double sigmaspace)
        {
            Mat img_des = null;
            if (image != null)
            {
                Mat img_source = BitmapConverter.ToMat(image);
                if (img_source.Type() != MatType.CV_8UC1)
                    Cv2.CvtColor(img_source, img_source, ColorConversionCodes.RGB2GRAY);
                img_des = new Mat(img_source.Size(), MatType.CV_8UC1);
                Cv2.BilateralFilter(img_source, img_des, d, sigmacolor, sigmaspace);
            }
            return img_des.ToBitmap();
        }

        public static Bitmap Canny(Bitmap image, int Threshold1 = 100, int Threshold2 = 255)
        {
            Mat img = BitmapConverter.ToMat(image);
            if (img.Type() != MatType.CV_8UC1)
                Cv2.CvtColor(img, img, ColorConversionCodes.RGB2GRAY);
            Mat imgcanny = new Mat();
            Cv2.Canny(img, imgcanny, Threshold1, Threshold2);
            return imgcanny.ToBitmap();
        }

        public static Bitmap Subtruct(Bitmap image1, Bitmap image2)
        {
            //Mat img_des = new Mat(image1.Height, image1.Width, MatType.CV_8UC1);
            Mat img_source1 = BitmapConverter.ToMat(image1);
            Mat img_source2 = BitmapConverter.ToMat(image1);
            Mat dst = new Mat(img_source1.Cols, img_source1.Rows, MatType.CV_8UC1);
            //Mat dst = new Mat(img_source1.Cols, img_source1.Rows,MatType.CV_8UC1);
            if (image1 != null && image2 != null)
            {

                if (img_source1.Type() != MatType.CV_8UC1)
                    Cv2.CvtColor(img_source1, img_source1, ColorConversionCodes.RGB2GRAY);
                if (img_source2.Type() != MatType.CV_8UC1)
                    Cv2.CvtColor(img_source2, img_source2, ColorConversionCodes.RGB2GRAY);

                Cv2.Subtract(img_source1, img_source2, img_source1, dst, -1);
            }
            return img_source1.ToBitmap();
        }

        public static Bitmap Rotation(Bitmap image, double angle)
        {
            Mat dst = null;
            Mat img = BitmapConverter.ToMat(image);
            try
            {
                Mat source = img;
                Point2f src_center = new Point2f(source.Cols / 2.0F, source.Rows / 2.0F);
                Mat rot_mat = Cv2.GetRotationMatrix2D(src_center, angle, 1.0);
                dst = new Mat(source.Size(), source.Type());
                Cv2.WarpAffine(source, dst, rot_mat, source.Size());
            }
            catch { }
            return dst.ToBitmap();
        }

        public static double MatchingTemplate(Bitmap source, Bitmap temp, double MarkRate, out Rectangle TemplateRectangle)
        {
            double score = 0;
            Mat matToFind = new Mat(source.Width, source.Height, MatType.CV_8UC1);
            Mat matTemplate = new Mat(temp.Width, temp.Height, MatType.CV_8UC1);
            matToFind = BitmapConverter.ToMat(source);
            matTemplate = BitmapConverter.ToMat(temp);
            if (matToFind.Type() != MatType.CV_8UC1)
                Cv2.CvtColor(matToFind, matToFind, ColorConversionCodes.RGB2GRAY);
            if (matTemplate.Type() != MatType.CV_8UC1)
                Cv2.CvtColor(matTemplate, matTemplate, ColorConversionCodes.RGB2GRAY);
            Mat result;
            Cv2.MatchTemplate(matToFind, matTemplate, result = new Mat(), TemplateMatchModes.CCoeffNormed);
            double minval, maxval;
            OpenCvSharp.Point minloc = new OpenCvSharp.Point();
            OpenCvSharp.Point maxloc = new OpenCvSharp.Point();
            Cv2.MinMaxLoc(result, out minval, out maxval, out minloc, out maxloc);
            TemplateRectangle = new Rectangle(maxloc.X, maxloc.Y, matTemplate.Width, matTemplate.Height);
            score = maxval;
            return score;
        }

        public static void Blob(Bitmap source)
        {
            Mat img_src = BitmapConverter.ToMat(source);
            if (img_src.Type() != MatType.CV_8UC1)
                Cv2.CvtColor(img_src, img_src, ColorConversionCodes.RGB2GRAY);
            Mat img_dst;
            Cv2.AdaptiveThreshold(img_src, img_dst = new Mat(), 150, AdaptiveThresholdTypes.GaussianC, ThresholdTypes.Binary, 5, 2);




            Cv2.ImShow("img sub", img_dst);
            Cv2.WaitKey();
        }


        public static Bitmap Merge_2Image(Bitmap image_1, Bitmap image_2)
        {
            Mat dst = null;
            Mat img_1 = BitmapConverter.ToMat(image_1);
            Mat img_2 = BitmapConverter.ToMat(image_2);
            try
            {
                dst = new Mat(img_1.Rows, img_1.Cols + img_2.Cols, img_1.Type());

                dst[0, img_1.Rows, 0, img_1.Cols] = img_1;
                dst[0, img_1.Rows, img_1.Cols, dst.Cols] = img_2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dst.ToBitmap();
        }




        //public double GetRotation(Bitmap bmpSource, Bitmap bmpTemplate, Rectangle roiTemplate)
        //{
        //    double rot = 0;
        //    try
        //    {
        //        Rectangle R1 = new Rectangle();
        //        double score1 = 0;
        //        score1 = MatchingTemplate2(bmpSource.Clone(roiTemplate, bmpSource.PixelFormat), bmpTemplate, 0.85, out R1);
        //        R1.X += roiTemplate.X;
        //        R1.Y += roiTemplate.Y;
        //        Rectangle R2 = new Rectangle();
        //        double score2 = 0;
        //        score2 = MatchingTemplate2(bmpSource.Clone(data.ROITemplatePoint2, bmpSource.PixelFormat), data.TemplatePoint2, 0.85, out R2);
        //        R2.X += data.ROITemplatePoint2.X;
        //        R2.Y += data.ROITemplatePoint2.Y;
        //        double OffsetX = Math.Abs(R2.X - R1.X);
        //        double OffsetY = Math.Abs(R2.Y - R1.Y);
        //        rot = Math.Atan2(OffsetY, OffsetX);
        //        rot = rot * 180 / Math.PI;
        //        if (R2.Y > R1.Y)
        //            rot *= -1;
        //    }
        //    catch { }
        //    return rot;
        //}

        public static Bitmap CompareImage(Bitmap img1, Bitmap img2, ref int results)
        {
            OpenCvSharp.Point[][] Contour;
            HierarchyIndex[] hie;
            OpenCvSharp.Point point = new OpenCvSharp.Point(0, 0);
            try
            {
                if (img1.Width == img2.Width & img1.Height == img2.Height)
                {
                    Mat Input1 = BitmapConverter.ToMat(img1);
                    if (Input1.Type() != MatType.CV_8UC1)
                        Cv2.CvtColor(Input1, Input1, ColorConversionCodes.RGB2GRAY);
                    Mat Input2 = BitmapConverter.ToMat(img2);
                    if (Input2.Type() != MatType.CV_8UC1)
                        Cv2.CvtColor(Input2, Input2, ColorConversionCodes.RGB2GRAY);
                    Mat matSub = new Mat();
                    Cv2.Absdiff(Input1, Input2, matSub);
                    Bitmap bmpcanny = Canny(matSub.ToBitmap(), 30, 250);
                    Cv2.FindContours(BitmapConverter.ToMat(bmpcanny), out Contour, out hie, RetrievalModes.External, ContourApproximationModes.ApproxSimple, point);
                    results = Contour.Length;
                    return matSub.ToBitmap();
                }
            }
            catch { }
            return null;
        }


        public static Bitmap Calibper_Process(Bitmap image)
        {
            /*  /// 1
              int filterHalfSize = 10;
              int filterSize = filterHalfSize * 2 + 1;
              float[] prewittFilterData = new float[filterSize];
              for (int i = 0; i < filterSize; i++)
              {
                  if (i < filterHalfSize)
                      prewittFilterData[i] = -1f / filterSize * 5; // *5는 지금까지 사용해 왔던 Recipe 때문에... ㅠㅠ
                  else if (i == filterHalfSize)
                      prewittFilterData[i] = 0;
                  else
                      prewittFilterData[i] = 1f / filterSize * 5;  // *5는 지금까지 사용해 왔던 Recipe 때문에... ㅠㅠ
              }
              Mat prewittFilter = new Mat(filterSize, 1, MatType.CV_32F, prewittFilterData);
              /// 2
              if (image == null) return null;
              MatOfByte caliperMat = new MatOfByte(BitmapConverter.ToMat(image));
              MatOfFloat projectionMat = new MatOfFloat(caliperMat.Height, 1);
              Mat bluredMat = new Mat();
              Cv2.GaussianBlur(projectionMat, bluredMat, new OpenCvSharp.Size(1, 1), 0);
              MatOfFloat deriv1stMat = new MatOfFloat();
              Cv2.Filter2D(bluredMat, deriv1stMat, -1, prewittFilter);
              Mat img_des = new Mat();
              Mat img_des_2 = new Mat();
              //Cv2.CvtColor(deriv1stMat, img_des, ColorConversionCodes.GRAY2RGB);
              //Cv2.CvtColor(img_des, img_des_2, ColorConversionCodes.RGB2GRAY);
              Mat outputMat = new Mat();
              deriv1stMat.ConvertTo(outputMat, MatType.CV_8UC1, 255.0 / (deriv1stMat.Max() - deriv1stMat.Min()), -deriv1stMat.Min() * 255.0 / (deriv1stMat.Max() - deriv1stMat.Min()));*/
            return null;
        }




        private static void ShowImage(Bitmap image)
        {
            Mat img_source = BitmapConverter.ToMat(image);
            Cv2.ImShow("img, Temp", img_source);
            Cv2.WaitKey();
        }

    }
}
