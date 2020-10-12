using System;
using System.Drawing;
using System.IO;

namespace INPTPZ1
{
    class ImageManager
    {
        private Bitmap FractalBitmap { get; set; }
        public ResolutionModel Resolution { get; private set; }

        public ImageManager(ResolutionModel resolution)
        {
            Resolution = resolution;
            FractalBitmap = new Bitmap(Resolution.Width, Resolution.Height);
        }

        public static Color[] GetColors()
        {
            return new[] { Color.Red, Color.Green, Color.Blue };
        }

        public static Color GenerateColorByRootId(int lastRootId)
        {
            var color = GetColors()[GetNumberByRootId(lastRootId)];

            int redColor = GenerateColorByNewtonValue(30, color.R);
            var greenColor = GenerateColorByNewtonValue(30, color.G);
            var blueColor = GenerateColorByNewtonValue(30, color.B);

            return Color.FromArgb(redColor, greenColor, blueColor);
        }

        public static int GetNumberByRootId(int id)
        {
            return id == -1 ? 0 : id % GetColors().Length;
        }

        public static int GenerateColorByNewtonValue(int it, byte colorValue)
        {
            return Math.Min(Math.Max(0, colorValue - it * 2), 255);
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

        public void AddPixel(int x, int y, Color color)
        {
            FractalBitmap.SetPixel(x, y, color);
        }
    }
}
