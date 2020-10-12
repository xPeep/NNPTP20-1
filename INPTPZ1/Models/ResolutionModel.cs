namespace INPTPZ1
{
    class ResolutionModel
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public ResolutionModel(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
