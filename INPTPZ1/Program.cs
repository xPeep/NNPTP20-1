using System.Numerics;

namespace INPTPZ1
{
    class Program
    {
        private const string Path = "C:\\Users\\Pepe\\Desktop\\OUTPUT\\";
        private const string FileName = "fractal_image_";
        private const string Extention = ".png";

        static void Main()
        {
            FractalManager fractalManager = new FractalManager();

            fractalManager.Initialize(500, 500, -2, -2, 2, 2, 30);
            fractalManager.PrintToConsoleComplexNumbers();
            fractalManager.CreateFractalToPicture();
            fractalManager.SaveToLocation(Path, FileName + "000", Extention);

            fractalManager.Initialize(500, 500, -1, -1, 1, 1, 30);
            fractalManager.PrintToConsoleComplexNumbers();
            fractalManager.CreateFractalToPicture();
            fractalManager.SaveToLocation(Path, FileName + "001", Extention);

            fractalManager.Initialize(500, 500, -8, -8, 4, 4, 30);
            fractalManager.PrintToConsoleComplexNumbers();
            fractalManager.CreateFractalToPicture();
            fractalManager.SaveToLocation(Path, FileName + "002", Extention);

            fractalManager.Initialize(500, 500, -5, -5, 5, 5, 30);
            fractalManager.PrintToConsoleComplexNumbers();
            fractalManager.CreateFractalToPicture();
            fractalManager.SaveToLocation(Path, FileName + "003", Extention);
        }
    }
}
