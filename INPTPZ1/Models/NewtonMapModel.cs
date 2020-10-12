using System.Numerics;

namespace INPTPZ1
{
    class NewtonMapModel
    {
        public ResolutionModel Resolution { get; private set; }
        public Complex Minimum { get; private set; }
        public Complex Maximum { get; private set; }
        public NewtonMapModel(ResolutionModel resolution, Complex minimum, Complex maximum)
        {
            Resolution = resolution;
            Minimum = minimum;
            Maximum = maximum;
        }
    }
}