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
    public class Unitility
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref Rectangle lpRect);

        [DllImport("user32 ")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32 ")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);


       
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
            IntPtr hbitmap = CreateCompatibleBitmap(hscrdc, width, height);
            IntPtr hmemdc = CreateCompatibleDC(hscrdc);
            SelectObject(hmemdc, hbitmap);
            PrintWindow(hWnd, hmemdc, 0);
            Bitmap bmp = Image.FromHbitmap(hbitmap);
            DeleteDC(hscrdc);
            DeleteDC(hmemdc);
            return bmp;
        }
        static Mat matSrcRet = new Mat();
        static KeyPoint[] keyPointsSrc = null;
        public static Rectangle MatchPicBySift(Bitmap imgSrc, Bitmap imgSub)
        {
            Timer.Init();
            using (Mat matSrc = imgSrc.ToMat())
            using (Mat matTo = imgSub.ToMat())
            using (Mat matToRet = new Mat())
            {
                Console.WriteLine("////////////////////////////////////////");
                Timer.Show("开始分析");

                KeyPoint[] keyPointsTo;
                using (var sift = OpenCvSharp.Features2D.SIFT.Create())
                {
                    if (keyPointsSrc == null)
                    {
                        sift.DetectAndCompute(matSrc, null, out keyPointsSrc, matSrcRet);
                    }
                    Timer.Show("提取大地图特征点");
                    sift.DetectAndCompute(matTo, null, out keyPointsTo, matToRet);
                    Timer.Show("提取游戏截图特征点");

                }
                using (var bfMatcher = new BFMatcher())
                {
                    var matches = bfMatcher.KnnMatch(matSrcRet, matToRet, k: 2);
                    Timer.Show("对比特征点完毕");

                    var pointsSrc = new List<Point2f>();
                    var pointsDst = new List<Point2f>();
                    //var goodMatches = new List<DMatch>();
                    foreach (DMatch[] items in matches.Where(x => x.Length > 1))
                    {
                        if (items[0].Distance < 0.5 * items[1].Distance)
                        {
                            pointsSrc.Add(keyPointsSrc[items[0].QueryIdx].Pt);
                            pointsDst.Add(keyPointsTo[items[0].TrainIdx].Pt);
                            //goodMatches.Add(items[0]);
                            //Console.WriteLine($"{keyPointsSrc[items[0].QueryIdx].Pt.X}, {keyPointsSrc[items[0].QueryIdx].Pt.Y}");
                        }
                    }

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


        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;                             //最左坐标
            public int Top;                             //最上坐标
            public int Right;                           //最右坐标
            public int Bottom;                        //最下坐标
        }
    }
}
class Timer
{
    static DateTime startTime;
    public static void Init()
    {
        startTime = DateTime.Now;
    }
    public static void Show(string text)
    {
        Console.WriteLine(text + (DateTime.Now - startTime));
    }
}