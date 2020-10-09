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