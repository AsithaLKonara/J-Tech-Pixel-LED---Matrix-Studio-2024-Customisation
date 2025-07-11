namespace JTechPixelLED.DrawingPanel
{
    public class FrameData
    {
        public PixelData[,] Pixels { get; set; }
        public int Width { get; }
        public int Height { get; }

        public FrameData(int width, int height)
        {
            Width = width;
            Height = height;
            Pixels = new PixelData[width, height];
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    Pixels[x, y] = new PixelData();
        }
    }
} 