namespace INPTPZ1
{
    class Program
    {
        private const string Path = "C:\\Users\\Pepe\\Desktop\\OUTPUT\\";
        private const string FileName = "fractal_image";
        private const string Extention = ".png";
        private const int Iterations = 26;

        static void Main()
        {
            GridPointsModel gridPoints = new GridPointsModel(500, 500);
            IntervalRangeModel x = new IntervalRangeModel(-2, 2);
            IntervalRangeModel y = new IntervalRangeModel(-2, 2);
            FractalManager fractalManager = new FractalManager(gridPoints, x, y, Iterations);

            fractalManager.PrintToConsoleComplexNumbers();
            fractalManager.CreateFractalToPicture();
            fractalManager.ImageManager.SaveToLocation(Path, FileName, Extention);
        }
    }
}
