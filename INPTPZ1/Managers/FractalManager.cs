using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace INPTPZ1
{
    class FractalManager
    {
        public NewtonMapManager NewtonMapManager { get; private set; }
        public ComplexNumbersManager ComplexNumbersManager { get; private set; }
        public ImageManager ImageManager { get; private set; }
        public int RelaxationParameter { get; set; }

        public FractalManager(GridPointsModel gridPoints, IntervalRangeModel x, IntervalRangeModel y, int relaxationParameter)
        {
            NewtonMapManager = new NewtonMapManager(gridPoints, x, y);
            ImageManager = new ImageManager(gridPoints);
            ComplexNumbersManager = new ComplexNumbersManager();
            RelaxationParameter = relaxationParameter;
        }

        public void CreateFractalToPicture()
        {
            foreach (int x in Enumerable.Range(0, NewtonMapManager.NewtonMapModel.GridPoints.HorizontalLength))
            {
                foreach (int y in Enumerable.Range(0, NewtonMapManager.NewtonMapModel.GridPoints.VerticalLength))
                {
                    Complex worldCoordinates = NewtonMapManager.GetProcessedWorldCoordinates(x, y);
                    worldCoordinates = ComplexNumbersManager.FindSolutionByNewtonsIteration(RelaxationParameter, worldCoordinates);
                    int lastRootId = ComplexNumbersManager.FindRoot(worldCoordinates);
                    if (IsRootFound(lastRootId)) ComplexNumbersManager.AddComplexNumberToRoot(worldCoordinates);
                    Color pixelColor = ImageManager.GenerateColorByInput(lastRootId);
                    lock (ImageManager)
                    {
                        ImageManager.AddPixel(x, y, pixelColor);
                    }
                }
            }
            ImageManager.SetPixels();
        }
        private bool IsRootFound(int lastRootId)
        {
            return lastRootId == -1;
        }
        public void PrintToConsoleComplexNumbers()
        {
            ComplexNumbersManager.PrintToConsoleComplexNumbers();
        }
    }
}
