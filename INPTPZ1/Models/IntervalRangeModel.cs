using System;

namespace INPTPZ1
{
    class IntervalRangeModel
    {
        public double Min { get; private set; }
        public double Max { get; private set; }
        public IntervalRangeModel(double min, double max)
        {
            Min = min;
            Max = max;
        }
    }
}
