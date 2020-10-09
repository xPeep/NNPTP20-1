using System;
using System.IO;

namespace INPTPZ1
{
    class NewtonMapModel
    {
        public GridPointsModel GridPoints { get; private set; }
        public IntervalRangeModel X { get; private set; }
        public IntervalRangeModel Y { get; private set; }

        public NewtonMapModel(GridPointsModel gridPoints, IntervalRangeModel xInterval, IntervalRangeModel yInterval)
        {
            GridPoints = gridPoints;
            X = xInterval;
            Y = yInterval;
        }
    }
}
/*            if (gridPoints == null || xInterval == null || yInterval == null)
            {
                throw new InvalidDataException("Null parameters are not allowed for generate newton map.");
            }
            else if (!gridPoints.IsSetup() || !xInterval.IsSetup() || !yInterval.IsSetup())
            {
                throw new InvalidDataException("All parameters have to be specified for generate newton map.");
            }
            else
            {
            }*/