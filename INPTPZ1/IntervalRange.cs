using System;
using System.IO;

namespace INPTPZ1
{
    /// <summary>
    /// This program should produce Newton fractals.
    /// See more at: https://en.wikipedia.org/wiki/Newton_fractal
    /// </summary>
    class IntervalRange
    {
        public double Min { get; private set; }
        public double Max { get; private set; }

        public double GetDelta(GridPoints gridPoints)
        {
            return (Max - Min) / gridPoints.HorizontalLength;
        }

        public double GetPixelCoordinateByPosition(GridPoints gridPoints, int position)
        {
            return Min + position * GetDelta(gridPoints);
        }

        public void SetInverval(double min, double max)
        {
            if(min < max)
            {
                Min = min;
                Max = max;
            }
            else
            {
                throw new InvalidDataException("Minimum value can not be higher than maximum value.");
            }
        }

        public bool IsSetup()
        {
            return Min < Max;
        }
    }
}
