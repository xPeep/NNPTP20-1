using System;
using System.Drawing;
using System.Numerics;
using MathNet.Numerics;
using System.Linq;

namespace INPTPZ1
{
    class Program
    {
        private const string Path = "C:\\Users\\Pepe\\Desktop\\OUTPUT\\";
        private const string FileName = "fractal_image";
        private const string Extention = ".png";

        static void Main()
        {
            GridPointsModel gridPoints = new GridPointsModel(500, 500);
            IntervalRangeModel xInterval = new IntervalRangeModel(-2.002, 1.998);
            IntervalRangeModel yInterval = new IntervalRangeModel(-2.001, 1.999);

            FractalManager fractalManager = new FractalManager(gridPoints, xInterval, yInterval);

            fractalManager.PrintToConsoleComplexNumbers();
            fractalManager.CreateFractalToPicture();
            fractalManager.ImageManager.SaveToLocation(Path, FileName, Extention);
        }
    }
}
