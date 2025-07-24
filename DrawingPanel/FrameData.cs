
namespace JTechPixelLED.DrawingPanel;

public class FrameData
{
    public PixelData[,] Pixels { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public double FrameDelay { get; set; } // seconds
    public FrameData(int width, int height)
    {
        Width = width;
        Height = height;
        FrameDelay = 0.1; // default frame delay
        Pixels = new PixelData[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Pixels[x, y] = new PixelData();
            }
        }
    }


    public struct PixelColor
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public PixelColor(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }
    }


}