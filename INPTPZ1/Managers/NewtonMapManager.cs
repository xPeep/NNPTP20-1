using System.Numerics;

namespace INPTPZ1
{
    class NewtonMapManager
    {
        public NewtonMapModel NewtonMapModel { get; private set; }

        public NewtonMapManager()
        {
            NewtonMapModel = GenerateNewtonMapInstance();
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

        public NewtonMapModel GenerateNewtonMapInstance()
        {
            GridPointsModel gridPoints = new GridPointsModel(200, 200);
            IntervalRangeModel xInterval = new IntervalRangeModel(-2.002, 1.998);
            IntervalRangeModel yInterval = new IntervalRangeModel(-2.001, 1.999);

            return new NewtonMapModel(gridPoints, xInterval, yInterval);
        }
    }
}
