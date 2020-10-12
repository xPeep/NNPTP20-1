using System.Numerics;

namespace INPTPZ1
{
    class NewtonMapModel
    {
        public Complex Minimum { get; private set; }
        public Complex Maximum { get; private set; }
        public double Tolerance { get; private set; }
        public int Cycles { get; private set; }

        public NewtonMapModel(Complex minimum, Complex maximum, double tolerance, int cycles)
        {
            Minimum = minimum;
            Maximum = maximum;
            Tolerance = tolerance;
            Cycles = cycles;
        }
    }
}