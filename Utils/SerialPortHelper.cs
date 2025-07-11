using System.IO.Ports;

namespace JTechPixelLED.Utils
{
    public static class SerialPortHelper
    {
        public static string[] GetAvailablePorts()
        {
            return SerialPort.GetPortNames();
        }
    }
} 