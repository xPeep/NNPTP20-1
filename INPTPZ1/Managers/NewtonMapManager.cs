using System.Drawing;
using System.Numerics;

namespace INPTPZ1
{
    class NewtonMapManager
    {
        public NewtonMapModel NewtonMapModel { get; private set; }
        public NewtonMapManager(NewtonMapModel newtonMapModel)
        {
            NewtonMapModel = newtonMapModel;
        }

        public Complex GetProcessedWorldCoordinates(int x, int y)
        {
            return new Complex(
                GetPixelCoordinateByPosition(NewtonMapModel.Minimum.Real, NewtonMapModel.Maximum.Real, NewtonMapModel.Resolution.Width, x),
                GetPixelCoordinateByPosition(NewtonMapModel.Minimum.Imaginary, NewtonMapModel.Maximum.Imaginary, NewtonMapModel.Resolution.Height, y)
            );
        }

        private double GetPixelCoordinateByPosition(double minimum, double maximum, int length, int position)
        {
            return minimum + position * GetDelta(minimum, maximum, length);
        }

        private double GetDelta(double minimum, double maximum, int length)
        {
            return (maximum - minimum) / length;
        }
    }
}
