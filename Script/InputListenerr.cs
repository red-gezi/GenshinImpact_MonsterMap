using System;
using System.Runtime.InteropServices;
/// <summary>
/// 全局检测类
/// </summary>
class InputListenerr
{
   static bool isCtrlDown = false;
    ///////////////////////////////////////////下面是看不懂的win API区域///////////////////////////////////////////////////
    ///该类作用在于放在后台也能检测到键盘输入
    static WindowsHookCallBack k_callback;
    ///该类作用在于放在后台也能检测到鼠标输入
    static WindowsHookCallBack m_callback;
    public static void GetKeyDownEvent(Action<string> response)
    {
        k_callback = CreateCallBack((status, data) =>
        {
            if (data.vkCode == 162)//判断按下的是否是ctrl
            {
                isCtrlDown = status== KeyBoredHookStatus.WM_KEYDOWN; 
            }
            else if (status == KeyBoredHookStatus.WM_KEYDOWN)
            {
                //代码
                if (data.vkCode==27)
                {
                    response("esc");

                }
                else
                {
                    string key = (isCtrlDown ? "Ctrl" : "") + (((char)data.vkCode).ToString().ToUpper());
                    response(key);
                }
                
            }
        });
        IntPtr intPtr = SetWindowsHookEx(WindowsHookType.WH_KEYBOARD_LL, k_callback, IntPtr.Zero, 0);
    }
    public static void GetMouseEvent(Action<string> response)
    {
        m_callback = CreateCallBack((status, data) =>
        {
            if ((int)status!=512)
            {
                response(status.ToString());
            }

        });
        IntPtr intPtr = SetWindowsHookEx(WindowsHookType.WH_MOUSE_LL, m_callback, IntPtr.Zero, 0);
    }

    public enum KeyBoredHookStatus
    {
        WM_KEYDOWN = 0x0100,
        WM_KEYUP = 0x0101,
        WM_SYSKEYDOWN = 0x0104,
        WM_SYSKEYUP = 0x0105
    }

    [StructLayout(LayoutKind.Sequential)]
    public sealed class KeyBoredHookData
    {
        //虚拟码
        public int vkCode;

        //扫描码
        public int scanCode;
        public int flags;
        public int time;
        public IntPtr dwExtraInfo;
    }


    enum WindowsHookType
    {
        //全局键盘钩子
        WH_KEYBOARD_LL = 13,

        //全局鼠标钩子
        WH_MOUSE_LL = 14,
    }
    ///////////////////////////////////////////下面是看不懂的win API区域///////////////////////////////////////////////////

    //所有钩子函数的参数都一样，问题在于如何解释参数
    delegate IntPtr WindowsHookCallBack(int nCode, int wParam, IntPtr lParam);

    [DllImport("User32.dll", SetLastError = true)]
    extern static IntPtr SetWindowsHookEx(WindowsHookType hookType, WindowsHookCallBack lpfn, IntPtr hmod, int dwThreadId);


    [DllImport("User32.dll", SetLastError = true)]
    extern static IntPtr CallNextHookEx(int hhk, int nCode, int wParam, IntPtr lParam);
    //这两种组合键，你自己可以改
    static WindowsHookCallBack CreateCallBack(Action<KeyBoredHookStatus, KeyBoredHookData> action)
    {
        return (int nCode, int wParam, IntPtr lParam) =>
        {
            if (nCode < 0)
            {
                return CallNextHookEx(default, nCode, wParam, lParam);
            }
            else
            {
                KeyBoredHookData data = Marshal.PtrToStructure<KeyBoredHookData>(lParam);
                action((KeyBoredHookStatus)wParam, data);
                return CallNextHookEx(default, nCode, wParam, lParam);
            }
        };
    }
}
