using System.IO;
using System.Numerics;

namespace INPTPZ1
{
    class NewtonMapManager
    {
        public NewtonMapModel NewtonMapModel { get; private set; }
        public NewtonMapManager(GridPointsModel gridPoints, IntervalRangeModel x, IntervalRangeModel y)
        {
            NewtonMapModel = new NewtonMapModel(gridPoints, x, y);
        }
        public Complex GetProcessedWorldCoordinates(int x, int y)
        {
            return new Complex(
                NewtonMapModel.X.GetPixelCoordinateByPosition(x, NewtonMapModel.GridPoints.HorizontalLength),
                NewtonMapModel.Y.GetPixelCoordinateByPosition(y, NewtonMapModel.GridPoints.VerticalLength)
            );
        }
    }
}
