using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using MathNet.Numerics;

namespace INPTPZ1
{
    class ComplexNumbersManager
    {
        public ComplexNumbersModel ComplexNumbersModel { get; private set; }
        public ComplexNumbersManager()
        {
            ComplexNumbersModel = new ComplexNumbersModel
            {
                StartPoints = InitializeStartPoints()
            };
            ComplexNumbersModel.Derive = Derive(ComplexNumbersModel.StartPoints);
        }

        public void PrintToConsoleComplexNumbers()
        {
            Console.WriteLine(ToString(ComplexNumbersModel.StartPoints));
            Console.WriteLine(ToString(ComplexNumbersModel.Derive));
        }

        public Complex FindSolutionByNewtonsIteration(int relaxationParameter, Complex worldCoordinates)
        {            
            foreach (int x in Enumerable.Range(0, relaxationParameter))
            {
                var difference = Complex.Divide(
                    Polynomial.Evaluate(worldCoordinates, ComplexNumbersModel.StartPoints.ToArray()),
                    Polynomial.Evaluate(worldCoordinates, ComplexNumbersModel.Derive.ToArray())
                );

                worldCoordinates = Complex.Subtract(worldCoordinates, difference);
            }
            return worldCoordinates;
        }

        private List<Complex> InitializeStartPoints()
        {
            return new List<Complex>() {
                new Complex(1, 0),
                Complex.Zero,
                Complex.Zero,
                new Complex(1, 0),
            };
        }

        public void AddComplexNumberToRoot(Complex number)
        {
            ComplexNumbersModel.Roots.Add(number);
        }

        public int FindRoot(Complex worldCoordinates)
        {
            return ComplexNumbersModel.Roots.FindIndex(element => IsBeingRoot(element, worldCoordinates));
        }

        private bool IsBeingRoot(Complex element, Complex worldCoordinates)
        {
            return Complex.Abs(Complex.Pow(Complex.Subtract(worldCoordinates ,element), 2)) < 0.01;
        }

        private List<Complex> Derive(List<Complex> coeficients)
        {
            return coeficients
                .Where((element, index) => index != 0)
                .Select((element, index) => Complex.Multiply(element, new Complex(index + 1, 0)))
                .ToList();
        }

        public string ToString(List<Complex> coeficients)
        {
            return string.Join(" + ", coeficients);
        }
    }
}
