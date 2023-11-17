using System;
using System.Collections.Concurrent;

namespace Assignment2.CirclePainting;

public class PaintCoordinator
{
    private ConcurrentQueue<Circle> circlesToPaint;
    private Worker[] workers;

    public PaintCoordinator(ConcurrentQueue<Circle> circles, int numberOfWorkers)
    {
        circlesToPaint = circles;
        workers = new Worker[numberOfWorkers];

        for (int i = 0; i < numberOfWorkers; i++)
        {
            workers[i] = new Worker(i + 1);
        }
    }

    public void StartPainting()
    {
        Parallel.ForEach(workers, worker =>
        {
            while (!circlesToPaint.IsEmpty)
            {
                if (circlesToPaint.TryDequeue(out Circle circle))
                {
                    worker.PaintCircle(circle);
                }
            }
        });
    }
}

