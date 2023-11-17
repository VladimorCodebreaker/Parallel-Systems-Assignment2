using Assignment2.CirclePainting;
using System.Collections.Concurrent;

namespace Assignment2;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==== Assignment 2 ====");
            Console.ResetColor();

            Console.WriteLine("\nChoose an option:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1: Run performance analysis");
            Console.WriteLine("0: Exit");
            Console.ResetColor();

            Console.Write("\nYour choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine();
                    RunPerformanceAnalysis();
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;
                case "0":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nExiting program. Goodbye! <3 ꒰ᐢ. .ᐢ꒱₊˚⊹ ");
                    Console.ResetColor();
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.ResetColor();
                    break;
            }
        }
    }

    private static void RunPerformanceAnalysis()
    {
        int[] workerCounts = { 5, 20, 100 };
        int numberOfCircles = 1001;

        foreach (int count in workerCounts)
        {
            ConcurrentQueue<Circle> circles = GenerateCircles(numberOfCircles);
            Visualization.Initialize(numberOfCircles, count);
            PaintCoordinator coordinator = new PaintCoordinator(circles, count);
            PerformanceAnalyzer.Analyze(coordinator, count);
        }
    }

    private static ConcurrentQueue<Circle> GenerateCircles(int number)
    {
        ConcurrentQueue<Circle> circles = new ConcurrentQueue<Circle>();
        for (int i = 0; i < number; i++)
        {
            circles.Enqueue(new Circle(i, i));
        }
        return circles;
    }
}

