using System.Windows.Media;

namespace JTechPixelLED.DrawingPanel
{
    public class PixelData
    {
        public bool IsOn { get; set; }
        public double Delay { get; set; } // seconds
        public Color? Color { get; set; } // null for mono

        public PixelData()
        {
            IsOn = false;
            Delay = 0.1; // default
            Color = null;
        }
    }
} 