using System;
using System.Collections.Concurrent;

namespace Assignment2.CirclePainting;

public class Worker
{
    public int ID { get; private set; }

    private static readonly ConcurrentDictionary<Circle, bool> SharedPaintedCircles = new();
    private int paintedCirclesCount = 0;

    public Worker(int id)
    {
        ID = id;
    }

    public void PaintCircle(Circle circle)
    {
        if (!IsCirclePainted(circle))
        {
            Thread.Sleep(20);
            circle.Paint();
            SharedPaintedCircles.TryAdd(circle, true);
            paintedCirclesCount++;
            Visualization.UpdateProgress(ID, paintedCirclesCount);
        }
    }

    private bool IsCirclePainted(Circle circle)
    {
        return SharedPaintedCircles.TryGetValue(circle, out bool isPainted) && isPainted;
    }
}

