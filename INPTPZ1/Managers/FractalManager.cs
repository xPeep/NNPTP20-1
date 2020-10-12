using System.Drawing;
using System.Linq;
using System.Numerics;

namespace INPTPZ1
{
    class FractalManager
    {
        private ImageManager ImageManager { get; set; }
        private PolynomialManager PolynomialManager { get; set; }

        public FractalManager(ResolutionModel resolution, Complex minimum, Complex maximum, int cycles, double tolerance)
        {
            ImageManager = new ImageManager(resolution);
            PolynomialManager = new PolynomialManager(new NewtonMapModel(minimum, maximum, tolerance, cycles));
        }

        public void CreateFractalToPicture()
        {
            foreach (int x in Enumerable.Range(0, ImageManager.Resolution.Width))
            {
                foreach (int y in Enumerable.Range(0, ImageManager.Resolution.Height))
                {
                    Complex coordinates = PolynomialManager.GetProcessedWorldCoordinates(ImageManager.Resolution, x, y);
                    Complex solution = PolynomialManager.FindSolutionByNewtonsIteration(coordinates);
                    int roodId = PolynomialManager.FindRoot(solution);
                    if (IsRootFound(roodId)) PolynomialManager.PolynomialModel.Roots.Add(solution);
                    Color color = ImageManager.GenerateColorByRootId(roodId);
                    ImageManager.AddPixel(x, y, color);
                }
            }
        }

        public void PrintToConsoleComplexNumbers()
        {
            PolynomialManager.PrintToConsoleComplexNumbers();
        }

        public void SaveToLocation(string path, string fileName, string extention)
        {
            ImageManager.SaveToLocation(path, fileName, extention);
        }

        private static bool IsRootFound(int lastRootId)
        {
            return lastRootId == -1;
        }
    }
}
