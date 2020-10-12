using System.Numerics;

namespace INPTPZ1
{
    class Program
    {
        static void Main()
        {
            string Path = "C:\\Users\\Pepe\\Desktop\\OUTPUT\\";
            string FileName = "fractal_image_";
            string Extention = ".png";

            ResolutionModel resolution = new ResolutionModel(500, 500);
            Complex minimum = new Complex(-2, -2);
            Complex maximum = new Complex(2, 2);
            int cycles = 30;
            double tolerance = 0.01;

            FractalManager fractalManager = new FractalManager(resolution, minimum, maximum, cycles, tolerance);
            fractalManager.PrintToConsoleComplexNumbers();
            fractalManager.CreateFractalToPicture();
            fractalManager.SaveToLocation(Path, FileName, Extention);
        }
    }
}
