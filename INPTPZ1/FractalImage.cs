using System.Drawing;
using System.IO;

namespace INPTPZ1
{
    class FractalImage
    {
        public Bitmap FractalBitmap { get; set; }
        public FractalImage(GridPoints gridPoints)
        {
            FractalBitmap = new Bitmap(gridPoints.HorizontalLength, gridPoints.VerticalLength);
        }

        public void SaveToLocation(string path, string fileName, string extention)
        {
            try
            {
                FractalBitmap.Save($"{path}{fileName}{extention}");
            }
            catch (IOException exception)
            {
                throw new IOException("Picture can not be saved. " + exception.Message);
            }
        }
    }

}
