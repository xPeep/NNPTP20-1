using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using MathNet.Numerics;
using System.Linq;

namespace INPTPZ1
{
    class Program
    {
        static void Main(string[] args)
        {
            NewtonMap newtonMap = InitializeNewtonMap();

            FractalImage fractalImage = new FractalImage(newtonMap.GridPoints);

            List<Complex> roots = new List<Complex>();

            List<Complex> startPoints = new List<Complex>
            {
                new Complex(1, 0),
                Complex.Zero,
                Complex.Zero,
                new Complex(1, 0)
            };

            List<Complex> derive = Derive(startPoints);

            Console.WriteLine(ToString(startPoints));
            Console.WriteLine(ToString(derive));

            Color[] clrs = GetColors();

            CreateFractalToPicture(newtonMap, fractalImage.FractalBitmap, roots, startPoints, derive, clrs);

            fractalImage.SaveToLocation("C:\\Users\\Pepe\\Desktop\\OUTPUT\\", "fractal_image", ".png");
        }

        private static void CreateFractalToPicture(NewtonMap newtonMap, Bitmap bmp, List<Complex> roots, List<Complex> startPoints, List<Complex> derive, Color[] listOfColors)
        {
            foreach (int x in Enumerable.Range(0, newtonMap.GridPoints.HorizontalLength))
            {
                foreach (int y in Enumerable.Range(0, newtonMap.GridPoints.VerticalLength))
                {
                    Complex worldCoordinates = newtonMap.GetWorldCoordinatesByComplexNumber(newtonMap.GridPoints, x, y);

                    double it = FindSolutionByNewtonsIteration(startPoints, derive, ref worldCoordinates);

                    int lastRootId = FindRoot(roots, worldCoordinates);

                    if (lastRootId == -1)
                    {
                        roots.Add(worldCoordinates);
                    }

                    var color = listOfColors[GetNumberByRootId(listOfColors, lastRootId)];

                    int redColor = GenerateColorByNewtonValue(it, color.R);
                    var greenColor = GenerateColorByNewtonValue(it, color.G);
                    var blueColor = GenerateColorByNewtonValue(it, color.B);

                    color = Color.FromArgb(redColor, greenColor, blueColor);

                    bmp.SetPixel(x, y, color);
                }
            }
        }
        private static float FindSolutionByNewtonsIteration(List<Complex> startPoints, List<Complex> derive, ref Complex worldCoordinates)
        {
            var startPointResult = Polynomial.Evaluate(worldCoordinates, startPoints.ToArray());
            var deriveResult = Polynomial.Evaluate(worldCoordinates, derive.ToArray());
            var difference = Complex.Divide(startPointResult, deriveResult);

            worldCoordinates = Complex.Subtract(worldCoordinates, difference);

            return 30;
        }
        private static Color[] GetColors()
        {
            return new Color[]
            {
                Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Orange,
                Color.Fuchsia, Color.Gold, Color.Cyan, Color.Magenta
            };
        }
        public static int FindRoot(List<Complex> root, Complex ox)
        {
            return root.FindIndex(element => IsBeingRoot(element, ox));
        }
        private static bool IsBeingRoot(Complex element, Complex ox)
        {
            return Math.Pow(ox.Real - element.Real, 2) + Math.Pow(ox.Imaginary - element.Imaginary, 2) <= 0.01;
        }
        public static List<Complex> Derive(List<Complex> coeficients)
        {
            return coeficients
                .AsParallel()
                .Where((element, index) => index != 0)
                .Select((element, index) => Complex.Multiply(element, new Complex(index + 1, 0)))
                .ToList();
        }
        public static string ToString(List<Complex> coeficients)
        {
            return string.Join(" + ", coeficients);
        }

        public static NewtonMap InitializeNewtonMap()
        {
            GridPoints gridPoints = new GridPoints();
            gridPoints.SetGridPoints(200, 200);

            IntervalRange xInterval = new IntervalRange();
            xInterval.SetInverval(-2.002, 1.998);

            IntervalRange yInterval = new IntervalRange();
            yInterval.SetInverval(-2.001, 1.999);

            NewtonMap newtonMap = new NewtonMap();
            newtonMap.GenerateNewtonMap(gridPoints, xInterval, yInterval);

            return newtonMap;
        }

        public static int GetNumberByRootId(Color[] clrs, int id)
        {
            return id == -1 ? 0 : id % clrs.Length;
        }

        public static int GenerateColorByNewtonValue(double it, byte colorValue)
        {
            return Math.Min(Math.Max(0, colorValue - (int)it * 2), 255);
        }
    }

}
