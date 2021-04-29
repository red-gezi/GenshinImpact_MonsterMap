using System;

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