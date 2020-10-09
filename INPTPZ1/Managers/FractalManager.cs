using MathNet.Numerics;
using System;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;

namespace INPTPZ1
{
    class FractalManager
    {
        public NewtonMapManager NewtonMapManager { get; private set; }
        public ComplexNumbersManager ComplexNumbersManager { get; private set; }
        public ImageManager ImageManager { get; private set; }
        public int RelaxationParameter { get;  set; }


        public FractalManager(GridPointsModel gridPoints, IntervalRangeModel xInterval, IntervalRangeModel yInterval, int relaxationParameter)
        {
            NewtonMapManager = new NewtonMapManager(gridPoints, xInterval ,yInterval);
            ImageManager = new ImageManager(gridPoints);
            ComplexNumbersManager = new ComplexNumbersManager();
            RelaxationParameter = relaxationParameter;
        }

        public void CreateFractalToPicture()
        {
            foreach (int x in Enumerable.Range(0, GetHorizontalLength()))
            {
                foreach (int y in Enumerable.Range(0, GetVerticalLength()))
                {
                    Complex worldCoordinates = NewtonMapManager.GetProcessedWorldCoordinates(x, y);

                    worldCoordinates = ComplexNumbersManager.FindSolutionByNewtonsIteration(RelaxationParameter, worldCoordinates);

                    int lastRootId = ComplexNumbersManager.FindRoot(worldCoordinates);

                    if(IsRootFound(lastRootId)) ComplexNumbersManager.AddComplexNumberToRoot(worldCoordinates);

                    Color pixelColor = ImageManager.GenerateColorByInput(lastRootId);

                    ImageManager.AddPixel(x, y, pixelColor);
                }
            }
        }
        private  bool IsRootFound(int lastRootId)
        {
            return lastRootId == -1;
        }

        private int GetHorizontalLength()
        {
            return NewtonMapManager.NewtonMapModel.GridPoints.HorizontalLength;
        }

        private int GetVerticalLength()
        {
            return NewtonMapManager.NewtonMapModel.GridPoints.VerticalLength;
        }

        public void PrintToConsoleComplexNumbers()
        {
            ComplexNumbersManager.PrintToConsoleComplexNumbers();
        }
    }
}
