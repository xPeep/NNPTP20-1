using MathNet.Numerics;
using System;
using System.Dynamic;
using System.Linq;
using System.Numerics;

namespace INPTPZ1
{
    class FractalManager
    {
        public NewtonMapManager NewtonMapManager { get; private set; }
        public ComplexNumbersManager ComplexNumbersManager { get; private set; }
        public ImageManager ImageManager { get; private set; }

        public FractalManager(GridPointsModel gridPoints, IntervalRangeModel xInterval, IntervalRangeModel yInterval)
        {
            NewtonMapManager = new NewtonMapManager(gridPoints, xInterval ,yInterval);
            ImageManager = new ImageManager(gridPoints);
            ComplexNumbersManager = new ComplexNumbersManager();
        }

        public void CreateFractalToPicture()
        {
            foreach (int x in Enumerable.Range(0, NewtonMapManager.NewtonMapModel.GridPoints.HorizontalLength))
            {
                foreach (int y in Enumerable.Range(0, NewtonMapManager.NewtonMapModel.GridPoints.VerticalLength))
                {
                    Complex worldCoordinates = NewtonMapManager.GetProcessedWorldCoordinates(x, y);

                    worldCoordinates = ComplexNumbersManager.FindSolutionByNewtonsIteration(worldCoordinates);

                    int lastRootId = ComplexNumbersManager.FindRoot(worldCoordinates);

                    if (IsRootFound(lastRootId))
                    {
                        ComplexNumbersManager.AddComplexNumberToRoot(worldCoordinates);
                    }

                    ImageManager.AddPixel(x, y, lastRootId);
                }
            }
        }
        private  bool IsRootFound(int lastRootId)
        {
            return lastRootId == -1;
        }

        public void PrintToConsoleComplexNumbers()
        {
            ComplexNumbersManager.PrintToConsoleComplexNumbers();
        }
    }
}
