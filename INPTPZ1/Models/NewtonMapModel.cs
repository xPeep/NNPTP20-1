using System.Numerics;

namespace INPTPZ1
{
    class NewtonMapModel
    {
        public Complex Minimum { get; private set; }
        public Complex Maximum { get; private set; }
        public double Tolerance { get; private set; } = 0.01;
        public int Cycles { get; private set; }

        public NewtonMapModel(Complex minimum, Complex maximum, int cycles)
        {
            Minimum = minimum;
            Maximum = maximum;
            Cycles = cycles;
        }
    }
}