using System;
using System.IO;

namespace INPTPZ1
{
    class GridPoints
    {
        public int HorizontalLength { get; private set; }
        public int VerticalLength { get; private set; }

        public void SetGridPoints(int horizontalLength, int verticalLength)
        {
            if (horizontalLength > 0 && verticalLength > 0)
            {
                HorizontalLength = horizontalLength;
                VerticalLength = verticalLength;
            }
            else
            {
                throw new InvalidDataException("Size of the values have to be higher than 0.");
            }
        }

        public bool IsSetup()
        {
            return HorizontalLength > 0 && VerticalLength > 0;
        }
    }
}
