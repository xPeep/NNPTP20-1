using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace INPTPZ1
{
    class ImageManager
    {
        public Bitmap FractalBitmap { get; set; }
        public ImageManager(GridPointsModel gridPoints)
        {
            FractalBitmap = new Bitmap(gridPoints.HorizontalLength, gridPoints.VerticalLength);
        }
        public Color[] GetColors()
        {
            return new Color[]
            {
                Color.Red, Color.Green, Color.Blue,
            };
        }
        public Color GenerateColorByInput(int lastRootId)
        {
            var color = GetColors()[GetNumberByRootId(lastRootId)];
            int redColor = GenerateColorByNewtonValue(30, color.R);
            var greenColor = GenerateColorByNewtonValue(30, color.G);
            var blueColor = GenerateColorByNewtonValue(30, color.B);

            return Color.FromArgb(redColor, greenColor, blueColor);
        }
        public int GetNumberByRootId(int id)
        {
            return id == -1 ? 0 : id % GetColors().Length;
        }
        public int GenerateColorByNewtonValue(int it, byte colorValue)
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
            try
            {
                FractalBitmap.SetPixel(x, y, color);
            }
            catch (IOException exception)
            {
                throw new IOException("Cannot save pixel data to bitmap: " + exception.Message);
            }

        }
    }
}
