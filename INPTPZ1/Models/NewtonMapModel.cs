namespace INPTPZ1
{
    class NewtonMapModel
    {
        public GridPointsModel GridPoints { get; private set; }
        public IntervalRangeManager X { get; private set; }
        public IntervalRangeManager Y { get; private set; }
        public NewtonMapModel(GridPointsModel gridPoints, IntervalRangeModel x, IntervalRangeModel y)
        {
            GridPoints = gridPoints;
            X = new IntervalRangeManager(x);
            Y = new IntervalRangeManager(y);
        }
    }
}