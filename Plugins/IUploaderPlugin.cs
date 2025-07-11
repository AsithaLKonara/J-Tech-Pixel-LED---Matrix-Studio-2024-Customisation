using System.Windows.Controls;

namespace JTechPixelLED.Plugins
{
    public interface IUploaderPlugin
    {
        string Name { get; }
        UserControl GetUploaderPanel();
        void Upload(string filePath, string comPort, System.Action<string> logCallback);
    }
}