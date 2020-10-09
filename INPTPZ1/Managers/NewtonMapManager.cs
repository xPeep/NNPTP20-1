using System;
using System.IO;
using System.Numerics;

namespace INPTPZ1
{
    class NewtonMapManager
    {
        public NewtonMapModel NewtonMapModel { get; private set; }

        public NewtonMapManager(GridPointsModel gridPoints, IntervalRangeModel xInterval, IntervalRangeModel yInterval)
        {
            ValidateDataInput(gridPoints, yInterval, yInterval);
            NewtonMapModel = new NewtonMapModel(gridPoints, xInterval, yInterval);
        }

        private void ValidateDataInput(GridPointsModel gridPoints, IntervalRangeModel xInterval, IntervalRangeModel yInterval)
        {
            if (gridPoints == null || xInterval == null || yInterval == null)
            {
                throw new InvalidDataException("Null parameters are not allowed for generate newton map.");
            }
            else if (!gridPoints.IsSetup() || !xInterval.IsSetup() || !yInterval.IsSetup())
            {
                throw new InvalidDataException("All parameters have to be specified for generate newton map.");
            }        
        }

        public Complex GetProcessedWorldCoordinates(int x, int y)
        {
            return new Complex(
                GetPixelCoordinateByPosition(x),
                GetPixelCoordinateByPosition(y)
            );
        }

        public double GetPixelCoordinateByPosition(int position)
        {
            return NewtonMapModel.X.Min + position * GetDelta();
        }
        public double GetDelta()
        {
            return (NewtonMapModel.X.Max - NewtonMapModel.X.Min) / NewtonMapModel.GridPoints.HorizontalLength;
        }
    }
}
