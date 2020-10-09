using System.IO;

namespace INPTPZ1
{
    class IntervalRangeManager
    {
        IntervalRangeModel IntervalRangeModel { get; set; }
        public IntervalRangeManager(IntervalRangeModel intervalRangeModel)
        {
            ValidateInputData(intervalRangeModel);
            IntervalRangeModel = intervalRangeModel;
        }

        private void ValidateInputData(IntervalRangeModel intervalRangeModel)
        {
            if (!IsSetup())
            {
                throw new InvalidDataException("Minimum value can not be higher than maximum value.");
            }
        }

        public bool IsSetup()
        {
            return IntervalRangeModel.Min < IntervalRangeModel.Max;
        }
    }
}
