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
        private const int RelaxationParameter = 30;

        static void Main()
        {
            GridPointsModel gridPoints = new GridPointsModel(500, 500);
            IntervalRangeModel xInterval = new IntervalRangeModel(-2.2, 2.2);
            IntervalRangeModel yInterval = new IntervalRangeModel(-1.65, 1.65);

            FractalManager fractalManager = new FractalManager(gridPoints, xInterval, yInterval, RelaxationParameter);

            fractalManager.PrintToConsoleComplexNumbers();
            fractalManager.CreateFractalToPicture();
            fractalManager.ImageManager.SaveToLocation(Path, FileName, Extention);
        }
    }
}
