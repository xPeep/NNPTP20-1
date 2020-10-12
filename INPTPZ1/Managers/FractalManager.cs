using System;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization;

namespace INPTPZ1
{
    class FractalManager
    {
        private NewtonMapManager NewtonMapManager { get; set; }
        private ComplexNumbersManager ComplexNumbersManager { get; set; }
        private ImageManager ImageManager { get; set; }
        private int IterationCounter { get; set; }
        private bool Initialized { get; set; } = false;

        public void Initialize(int screenWidth, int screenHeigth, double realMinimum, double imaginaryMinimum, double realMaximum, double imaginaryMaximum, int iterations)
        {
            if (ValidateDataInput(screenWidth, screenHeigth, realMinimum, imaginaryMinimum, realMaximum, imaginaryMaximum, iterations))
            {
                ResolutionModel resolution = new ResolutionModel(screenWidth, screenHeigth);
                Complex minimum = new Complex(realMinimum, imaginaryMinimum);
                Complex maximum = new Complex(realMaximum, imaginaryMaximum);
                NewtonMapModel newtonMapModel = new NewtonMapModel(resolution, minimum, maximum);

                NewtonMapManager = new NewtonMapManager(newtonMapModel);
                ImageManager = new ImageManager(resolution);
                ComplexNumbersManager = new ComplexNumbersManager();
                IterationCounter = iterations;

                Initialized = true;
            }
            else
            {
                throw new InvalidDataContractException("Input data cannot be used for modeling fractal image.");              
            }
        }

        public void CreateFractalToPicture()
        {
            if (Initialized)
            {
                foreach (int x in Enumerable.Range(0, NewtonMapManager.NewtonMapModel.Resolution.Width))
                {
                    foreach (int y in Enumerable.Range(0, NewtonMapManager.NewtonMapModel.Resolution.Height))
                    {
                        Complex worldCoordinates = NewtonMapManager.GetProcessedWorldCoordinates(x, y);
                        Complex newtonSolution = ComplexNumbersManager.FindSolutionByNewtonsIteration(IterationCounter, worldCoordinates);
                        int lastRootId = ComplexNumbersManager.FindRoot(newtonSolution);
                        if (IsRootFound(lastRootId)) ComplexNumbersManager.AddComplexNumberToRoot(newtonSolution);
                        Color pixelColor = ImageManager.GenerateColorByRootId(lastRootId);
                        ImageManager.AddPixel(x, y, pixelColor);
                    }
                }
            }
        }

        public void PrintToConsoleComplexNumbers()
        {
            if (Initialized)
            {
                ComplexNumbersManager.PrintToConsoleComplexNumbers();
            }
        }
        public void SaveToLocation(string path, string fileName, string extention)
        {
            if (Initialized)
            {
                ImageManager.SaveToLocation(path, fileName, extention);
            }
        }

        private bool IsRootFound(int lastRootId)
        {
            return lastRootId == -1;
        }

        private bool ValidateDataInput(int screenWidth, int screenHeigth, double realMinimum, double imaginaryMinimum, double realMaximum, double imaginaryMaximum, int iterations)
        {
            return (screenWidth > 0 && screenHeigth > 0 && realMaximum > realMinimum && imaginaryMaximum > imaginaryMinimum && iterations > 0);
        }
    }
}
