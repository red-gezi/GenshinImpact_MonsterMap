using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using static 原神地图辅助器.DataInfo;
namespace 原神地图辅助器
{
    public partial class Unitility
    {

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref Rectangle lpRect);

        [DllImport("user32 ")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32 ")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32 ")]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern bool SetProcessDPIAware();

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
        [DllImport("gdi32.dll")]
        private static extern int DeleteDC(IntPtr hdc);
        [DllImport("user32.dll")]
        private static extern bool PrintWindow(IntPtr hwnd, IntPtr hdcBlt, int nFlags);
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);
        public static Bitmap GetScreenshot(IntPtr hWnd)
        {
            IntPtr hscrdc = GetWindowDC(hWnd);
            Rectangle windowRect = new Rectangle();
            //RECT windowRect = new RECT();
            GetWindowRect(hWnd, ref windowRect);
            int width = Math.Abs(windowRect.X - windowRect.Width);
            int height = Math.Abs(windowRect.Y - windowRect.Height);
            //int width = windowRect.Right- windowRect.Left;
            //int height = windowRect.Bottom- windowRect.Top;
            //IntPtr hbitmap = CreateCompatibleBitmap(hscrdc, width, height);
            IntPtr hbitmap = CreateCompatibleBitmap(hscrdc, DataInfo.width, DataInfo.height);
            IntPtr hmemdc = CreateCompatibleDC(hscrdc);
            SelectObject(hmemdc, hbitmap);
            PrintWindow(hWnd, hmemdc, 0);
            Bitmap bmp = Image.FromHbitmap(hbitmap);
            DeleteDC(hscrdc);
            DeleteDC(hmemdc);
            return bmp;
        }
        //public static Rectangle MatchPicBySift(Bitmap imgSrc, Bitmap imgSub)
        //{
        //    Timer.Init();
        //    using (Mat matSrc = imgSrc.ToMat())
        //    using (Mat matTo = imgSub.ToMat())
        //    using (Mat matToRet = new Mat())
        //    {
        //        Console.WriteLine("////////////////////////////////////////");
        //        Timer.Show("开始分析");

        //        KeyPoint[] keyPointsTo;
        //        using (var sift = OpenCvSharp.Features2D.SIFT.Create())
        //        {
        //            if (keyPointsSrc == null)
        //            {
        //                sift.DetectAndCompute(matSrc, null, out keyPointsSrc, matSrcRet);
        //            }
        //            Timer.Show("提取大地图特征点");
        //            sift.DetectAndCompute(matTo, null, out keyPointsTo, matToRet);
        //            Timer.Show("提取游戏截图特征点");

        //        }
        //        using (var bfMatcher = new BFMatcher())
        //        {
        //            var matches = bfMatcher.KnnMatch(matSrcRet, matToRet, k: 2);
        //            Timer.Show("对比特征点完毕");

        //            var pointsSrc = new List<Point2f>();
        //            var pointsDst = new List<Point2f>();
        //            var goodMatches = new List<DMatch>();
        //            foreach (DMatch[] items in matches.Where(x => x.Length > 1))
        //            {
        //                if (items[0].Distance < 0.5 * items[1].Distance)
        //                {
        //                    pointsSrc.Add(keyPointsSrc[items[0].QueryIdx].Pt);
        //                    pointsDst.Add(keyPointsTo[items[0].TrainIdx].Pt);
        //                    goodMatches.Add(items[0]);
        //                    //Console.WriteLine($"{keyPointsSrc[items[0].QueryIdx].Pt.X}, {keyPointsSrc[items[0].QueryIdx].Pt.Y}");
        //                }
        //            }



        //            var outMat = new Mat();

        //            // 算法RANSAC对匹配的结果做过滤
        //            var pSrc = pointsSrc.ConvertAll(point => new Point2d((int)point.X, (int)point.Y));
        //            var pDst = pointsDst.ConvertAll(point => new Point2d((int)point.X, (int)point.Y));
        //            //var pSrc = pointsSrc.ConvertAll<Point2d>(pointsSrc);
        //            // var pDst = pointsDst.ConvertAll(Point2fToPoint2d);
        //            var outMask = new Mat();
        //            // 如果原始的匹配结果为空, 则跳过过滤步骤
        //            if (pSrc.Count > 0 && pDst.Count > 0)
        //                Cv2.FindHomography(pSrc, pDst, HomographyMethods.Ransac, mask: outMask);
        //            // 如果通过RANSAC处理后的匹配点大于10个,才应用过滤. 否则使用原始的匹配点结果(匹配点过少的时候通过RANSAC处理后,可能会得到0个匹配点的结果).
        //            if (outMask.Rows > 10)
        //            {
        //                byte[] maskBytes = new byte[outMask.Rows * outMask.Cols];
        //                outMask.GetArray(out maskBytes);
        //                Cv2.DrawMatches(matSrc, keyPointsSrc, matTo, keyPointsTo, goodMatches, outMat, matchesMask: maskBytes, flags: DrawMatchesFlags.NotDrawSinglePoints);
        //            }
        //            else
        //            {
        //                Cv2.DrawMatches(matSrc, keyPointsSrc, matTo, keyPointsTo, goodMatches, outMat, flags: DrawMatchesFlags.NotDrawSinglePoints);
        //            }
        //            dealMap = BitmapConverter.ToBitmap(outMat);

        //            var pointOriginX_R = pointsSrc.OrderBy(point => point.X).FirstOrDefault();//原图最右侧的点
        //            var pointOriginX_L = pointsSrc.OrderByDescending(point => point.X).FirstOrDefault();//原图最左侧的点

        //            var pointTargetX_R = pointsDst.OrderBy(point => point.X).FirstOrDefault();//测试图最右侧的点
        //            var pointTargetX_L = pointsDst.OrderByDescending(point => point.X).FirstOrDefault();//测试图最左侧的点

        //            scaleX = (pointOriginX_R.X - pointOriginX_L.X) / (pointTargetX_R.X - pointTargetX_L.X);
        //            scaleY = (pointOriginX_R.Y - pointOriginX_L.Y) / (pointTargetX_R.Y - pointTargetX_L.Y);

        //            var targetWidth = imgSub.Width;
        //            var targetHeigh = imgSub.Height;

        //            float rectBaisXL = pointOriginX_R.X - pointTargetX_R.X * scaleX;
        //            float rectBaisXR = pointOriginX_L.X + (targetWidth - pointTargetX_L.X) * scaleX;

        //            float rectBaisYU = pointOriginX_R.Y - pointTargetX_R.Y * scaleY;
        //            float rectBaisYD = pointOriginX_L.Y + (targetHeigh - pointTargetX_L.Y) * scaleY;
        //            Timer.Show("变换坐标系");


        //            return new Rectangle((int)rectBaisXL, (int)rectBaisYU, (int)(rectBaisXR - rectBaisXL), (int)(rectBaisYD - rectBaisYU));

        //        }
        //    }
        //}
        /// <summary>
        /// ///////////////////////////////////////////////对象对比检测
        /// </summary>
        static Mat matSrcRet = new Mat();
        static KeyPoint[] keyPointsSrc = null;
        static KeyPoint[] keyPointsTo = null;
        public static Rectangle MatchMap(Bitmap imgSrc, Bitmap imgSub, bool useSift,out Image outImage)
        {
            Timer.Init();
            using (Mat matSrc = imgSrc.ToMat())
            using (Mat matTo = imgSub.ToMat())
            using (Mat matToRet = new Mat())
            {
                Console.WriteLine("////////////////////////////////////////");
                Timer.Show("开始分析");
                using (var useMatch = useSift ? (Feature2D)OpenCvSharp.Features2D.SIFT.Create() : (Feature2D)OpenCvSharp.XFeatures2D.SURF.Create(400, 4, 3, true, true))
                {
                    if (keyPointsSrc == null) useMatch.DetectAndCompute(matSrc, null, out keyPointsSrc, matSrcRet);//仅在第一次载入大地图分析点
                    Timer.Show("提取大地图特征点");
                    useMatch.DetectAndCompute(matTo, null, out keyPointsTo, matToRet);
                    Timer.Show("提取游戏截图特征点");
                }
                using (var bfMatcher = new BFMatcher())
                {
                    var pointsSrc = new List<Point2f>();
                    var pointsDst = new List<Point2f>();
                    var goodMatches = new List<DMatch>();
                    if (useSift)
                    {
                        var matches = bfMatcher.KnnMatch(matSrcRet, matToRet, k: 2);
                        Timer.Show("对比特征点完毕");
                        foreach (DMatch[] items in matches.Where(x => x.Length > 1))
                        {
                            if (items[0].Distance < 0.5 * items[1].Distance)
                            {
                                pointsSrc.Add(keyPointsSrc[items[0].QueryIdx].Pt);
                                pointsDst.Add(keyPointsTo[items[0].TrainIdx].Pt);
                                goodMatches.Add(items[0]);
                            }
                        }
                    }
                    else
                    {
                        var matches = bfMatcher.Match(matSrcRet, matToRet);
                        Timer.Show("对比特征点完毕");
                        //求最小最大距离
                        double minDistance = 1000;//反向逼近
                        double maxDistance = 0;
                        for (int i = 0; i < matSrcRet.Rows; i++)
                        {
                            double distance = matches[i].Distance;
                            if (distance > maxDistance)
                            {
                                maxDistance = distance;
                            }
                            if (distance < minDistance)
                            {
                                minDistance = distance;
                            }
                        }
                        for (int i = 0; i < matSrcRet.Rows; i++)
                        {
                            double distance = matches[i].Distance;
                            if (distance < Math.Max(minDistance * 2, 0.02))
                            {
                                pointsSrc.Add(keyPointsSrc[matches[i].QueryIdx].Pt);
                                pointsDst.Add(keyPointsTo[matches[i].TrainIdx].Pt);
                                goodMatches.Add(matches[i]);
                            }
                        }
                    }
                    var outMat = new Mat();
                    // 算法RANSAC对匹配的结果做过滤
                    var pSrc = pointsSrc.ConvertAll(point => new Point2d((int)point.X, (int)point.Y));
                    var pDst = pointsDst.ConvertAll(point => new Point2d((int)point.X, (int)point.Y));
                    var outMask = new Mat();
                    // 如果原始的匹配结果为空, 则跳过过滤步骤
                    if (pSrc.Count > 0 && pDst.Count > 0)
                        Cv2.FindHomography(pSrc, pDst, HomographyMethods.Ransac, mask: outMask);
                    Timer.Show("过滤完毕");

                    // 如果通过RANSAC处理后的匹配点大于10个,才应用过滤. 否则使用原始的匹配点结果(匹配点过少的时候通过RANSAC处理后,可能会得到0个匹配点的结果).
                    if (outMask.Rows > 10)
                    {
                        byte[] maskBytes = new byte[outMask.Rows * outMask.Cols];
                        outMask.GetArray(out maskBytes);
                        for (int i = maskBytes.Count() - 1; i < 0; i--)
                        {
                            if (maskBytes[i] == 1)
                            {
                                pointsSrc.RemoveAt(i);
                                pointsDst.RemoveAt(i);
                            }

                        }
                        Cv2.DrawMatches(matSrc, keyPointsSrc, matTo, keyPointsTo, goodMatches, outMat, matchesMask: maskBytes, flags: DrawMatchesFlags.NotDrawSinglePoints);
                    }
                    else
                    {
                        Cv2.DrawMatches(matSrc, keyPointsSrc, matTo, keyPointsTo, goodMatches, outMat, flags: DrawMatchesFlags.NotDrawSinglePoints);
                    }
                    dealMap = BitmapConverter.ToBitmap(outMat);
                    outImage = dealMap;
                    var pointOriginX_R = pointsSrc.OrderBy(point => point.X).FirstOrDefault();//原图最右侧的点
                    var pointOriginX_L = pointsSrc.OrderByDescending(point => point.X).FirstOrDefault();//原图最左侧的点

                    var pointTargetX_R = pointsDst.OrderBy(point => point.X).FirstOrDefault();//测试图最右侧的点
                    var pointTargetX_L = pointsDst.OrderByDescending(point => point.X).FirstOrDefault();//测试图最左侧的点

                    scaleX = (pointOriginX_R.X - pointOriginX_L.X) / (pointTargetX_R.X - pointTargetX_L.X);
                    scaleY = (pointOriginX_R.Y - pointOriginX_L.Y) / (pointTargetX_R.Y - pointTargetX_L.Y);

                    var targetWidth = imgSub.Width;
                    var targetHeigh = imgSub.Height;

                    float rectBaisXL = pointOriginX_R.X - pointTargetX_R.X * scaleX;
                    float rectBaisXR = pointOriginX_L.X + (targetWidth - pointTargetX_L.X) * scaleX;

                    float rectBaisYU = pointOriginX_R.Y - pointTargetX_R.Y * scaleY;
                    float rectBaisYD = pointOriginX_L.Y + (targetHeigh - pointTargetX_L.Y) * scaleY;
                    Timer.Show("变换坐标系");
                    return new Rectangle((int)rectBaisXL, (int)rectBaisYU, (int)(rectBaisXR - rectBaisXL), (int)(rectBaisYD - rectBaisYU));
                }
            }
        }
    }
}