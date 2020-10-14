using System;
using System.Numerics;

namespace INPTPZ1
{
    class Program
    {
        static void Main(string[] args)
        {
            string Path = args[0];

            ResolutionModel resolution = new ResolutionModel(Int32.Parse(args[1]), Int32.Parse(args[2]));

            Complex minimum = new Complex(Double.Parse(args[3]), Double.Parse(args[5]));
            Complex maximum = new Complex(Double.Parse(args[4]), Double.Parse(args[6]));

            int cycles = Int32.Parse(args[7]);

            FractalManager fractalManager = new FractalManager(resolution, minimum, maximum, cycles);
            fractalManager.PrintToConsoleComplexNumbers();
            fractalManager.CreateFractalToPicture();
            fractalManager.SaveToLocation(Path);
        }
    }
}
