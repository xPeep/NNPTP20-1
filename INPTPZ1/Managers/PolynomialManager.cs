using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace INPTPZ1
{
    class PolynomialManager
    {
        public PolynomialModel PolynomialModel { get; private set; } = new PolynomialModel();
        public NewtonMapModel NewtonMapModel { get; private set; }

        public PolynomialManager(NewtonMapModel newtonMapModel)
        {
            NewtonMapModel = newtonMapModel;
            InitializeRequiredData();
        }

        public void InitializeRequiredData()
        {
            PolynomialModel.StartPoints = InitializeStartPoints();
            PolynomialModel.Derivate = Derive(PolynomialModel.StartPoints);
        }

        public void PrintToConsoleComplexNumbers()
        {
            Console.WriteLine(ToString(PolynomialModel.StartPoints));
            Console.WriteLine(ToString(PolynomialModel.Derivate));
        }

        public Complex FindSolutionByNewtonsIteration(Complex coordinates)
        {
            foreach (var x in Enumerable.Range(0, NewtonMapModel.Cycles))
            {
                coordinates = Complex.Subtract(coordinates,
                    Complex.Divide(
                        Polynomial.Evaluate(coordinates, PolynomialModel.StartPoints.ToArray()),
                        Polynomial.Evaluate(coordinates, PolynomialModel.Derivate.ToArray())
                    )
                );
            }
            return coordinates;
        }
        public Complex GetProcessedWorldCoordinates(ResolutionModel resulution, int x, int y)
        {
            return new Complex(
                GetPixelCoordinateByPosition(NewtonMapModel.Minimum.Real, NewtonMapModel.Maximum.Real, resulution.Width, x),
                GetPixelCoordinateByPosition(NewtonMapModel.Minimum.Imaginary, NewtonMapModel.Maximum.Imaginary, resulution.Height, y)
            );
        }

        public int FindRoot(Complex coordinates)
        {
            return PolynomialModel.Roots.FindIndex(element => IsBeingRoot(element, coordinates));
        }

        private static List<Complex> InitializeStartPoints()
        {
            return new List<Complex>() {
                new Complex(1, 0),
                Complex.Zero,
                Complex.Zero,
                new Complex(1, 0),
            };
        }

        private bool IsBeingRoot(Complex element, Complex coordinates)
        {
            return Complex.Abs(Complex.Pow(Complex.Subtract(coordinates, element), 2)) < NewtonMapModel.Tolerance;
        }

        private static List<Complex> Derive(List<Complex> coeficients)
        {
            return coeficients
                .Where((element, index) => index != 0)
                .Select((element, index) => Complex.Multiply(element, new Complex(index + 1, 0)))
                .ToList();
        }

        private static double GetPixelCoordinateByPosition(double minimum, double maximum, int length, int position)
        {
            return minimum + position * GetDelta(minimum, maximum, length);
        }

        private static double GetDelta(double minimum, double maximum, int length)
        {
            return (maximum - minimum) / length;
        }

        private static string ToString(List<Complex> coeficients)
        {
            return string.Join(" + ", coeficients);
        }
    }
}
