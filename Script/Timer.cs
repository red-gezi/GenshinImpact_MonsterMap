using System;
/// <summary>
/// 各模块运行时间打印计时类
/// </summary>
class Timer
{
    static DateTime startTime;
    public static void Init() => startTime = DateTime.Now;
    public static void Show(string text) => Console.WriteLine(text + (DateTime.Now - startTime));
}