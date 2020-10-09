using System.IO;

namespace INPTPZ1
{
    class IntervalRangeManager
    {
        public IntervalRangeModel IntervalRangeModel { get; set; }
        public IntervalRangeManager(IntervalRangeModel intervalRangeModel)
        {
            IntervalRangeModel = intervalRangeModel;
        }

        public double GetPixelCoordinateByPosition(int position, int length)
        {
            return IntervalRangeModel.Min + position * GetDelta(length);
        }
        private double GetDelta(int length)
        {
            return (IntervalRangeModel.Max - IntervalRangeModel.Min) / length;
        }
    }
}
