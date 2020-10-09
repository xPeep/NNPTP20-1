using System;
using System.Drawing;
using System.Numerics;
using MathNet.Numerics;
using System.Linq;

namespace INPTPZ1
{
    class Program
    {
        static void Main(string[] args)
        {
            FractalManager fractalManager = new FractalManager();
            fractalManager.PrintToConsoleComplexNumbers();
            fractalManager.CreateFractalToPicture();
            fractalManager.FractalImageManager.SaveToLocation("C:\\Users\\Pepe\\Desktop\\OUTPUT\\", "fractal_image", ".png");
        }
    }
}
