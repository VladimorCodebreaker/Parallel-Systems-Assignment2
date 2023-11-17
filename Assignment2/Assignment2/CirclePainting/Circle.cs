using System;
namespace Assignment2.CirclePainting;

public class Circle
{
    public int X { get; }
    public int Y { get; }
    public bool IsPainted { get; private set; }

    public Circle(int x, int y)
    {
        X = x;
        Y = y;
        IsPainted = false;
    }

    public void Paint()
    {
        IsPainted = true;
    }

    public void Reset()
    {
        IsPainted = false;
    }
}

