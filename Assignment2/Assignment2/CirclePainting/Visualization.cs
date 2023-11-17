using System;
using System.Collections.Concurrent;
using System.Text;

namespace Assignment2.CirclePainting;

public class Visualization
{
    private static ConcurrentDictionary<int, int> progress = new();
    private static int totalCircles;
    private static int totalPaintedCircles = 0;
    private static readonly object lockObject = new object();
    private static Timer progressTimer;

    public static void Initialize(int totalCirclesCount, int workerCount)
    {
        totalCircles = totalCirclesCount;
        totalPaintedCircles = 0;
        progress.Clear();
        for (int i = 1; i <= workerCount; i++)
        {
            progress.TryAdd(i, 0);
        }

        progressTimer = new Timer(UpdateDisplay, null, 0, 100);
    }

    public static void UpdateProgress(int workerId, int paintedCount)
    {
        lock (lockObject)
        {
            progress[workerId] = paintedCount;
        }
    }

    private static void UpdateDisplay(object state)
    {
        lock (lockObject)
        {
            totalPaintedCircles = 0;
            foreach (var count in progress.Values)
            {
                totalPaintedCircles += count;
            }

            int percentage = (int)((totalPaintedCircles / (double)totalCircles) * 100);
            int barLength = 50;
            int filledLength = (int)(barLength * percentage / 100);

            string bar = new string('#', filledLength).PadRight(barLength);
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Overall Progress: [{bar}] {totalPaintedCircles}/{totalCircles} Circles Painted ({percentage}%)");
            Console.ResetColor();
        }
    }

    public static void CompleteProgressDisplay()
    {
        progressTimer?.Change(Timeout.Infinite, Timeout.Infinite);
    }
}

