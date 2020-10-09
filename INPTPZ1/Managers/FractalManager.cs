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
        public FractalImageManager FractalImageManager { get; private set; }

        public FractalManager()
        {
            NewtonMapManager = new NewtonMapManager();
            ComplexNumbersManager = new ComplexNumbersManager();
            FractalImageManager = new FractalImageManager(NewtonMapManager.NewtonMapModel.GridPoints);
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
                    FractalImageManager.AddPixel(x, y, lastRootId);
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
