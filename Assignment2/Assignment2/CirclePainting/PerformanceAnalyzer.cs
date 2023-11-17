using System;
using System.Diagnostics;

namespace Assignment2.CirclePainting;

public class PerformanceAnalyzer
{
    public static void Analyze(PaintCoordinator coordinator, int numberOfWorkers)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        coordinator.StartPainting();

        stopwatch.Stop();
        long timeTaken = stopwatch.ElapsedMilliseconds;

        Visualization.CompleteProgressDisplay();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\nThreads: {numberOfWorkers}, Time: {timeTaken} ms\n");
        Console.ResetColor();
    }
}

