using System;
using System.IO;
using System.Numerics;

namespace INPTPZ1
{
    class NewtonMap
    {
        public GridPoints GridPoints { get; set; }
        public IntervalRange X { get; set; }
        public IntervalRange Y { get; set; }

        public Complex GetWorldCoordinatesByComplexNumber(GridPoints gridPoints, int x, int y)
        {
            return new Complex(
                X.GetPixelCoordinateByPosition(gridPoints, x),
                Y.GetPixelCoordinateByPosition(gridPoints, y)
            );
        }

        public void GenerateNewtonMap(GridPoints gridPoints, IntervalRange xInterval, IntervalRange yInterval)
        {
            if (gridPoints == null || xInterval == null || yInterval == null)
            {
                throw new InvalidDataException("Null parameters are not allowed for generate newton map.");
            }
            else if (!gridPoints.IsSetup() || !xInterval.IsSetup() || !yInterval.IsSetup())
            {
                throw new InvalidDataException("All parameters have to be specified for generate newton map.");
            }
            else
            {
                GridPoints = gridPoints;
                X = xInterval;
                Y = yInterval;
            }
        }
    }
}
