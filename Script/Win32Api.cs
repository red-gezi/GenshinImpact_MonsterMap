//using OpenCvSharp;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static 原神地图辅助器.InfoModel;

namespace 原神地图辅助器
{
    public partial class Win32Api
    {

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref Rectangle lpRect);
        [DllImport("user32")]
        public static extern bool GetClientRect(IntPtr hwnd, out RECT lpRect);
        [DllImport("user32 ")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);
        [DllImport("user32 ")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern bool SetProcessDPIAware();
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
        [DllImport("gdi32.dll")]
        public static extern int DeleteDC(IntPtr hdc);
        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hwnd, IntPtr hdcBlt, int nFlags);
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hwnd);
    }
}