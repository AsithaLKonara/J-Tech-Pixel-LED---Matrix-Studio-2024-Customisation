using System;
using System.Collections.Generic;

namespace JTechPixelLED.Plugins
{
    public interface IUploaderPlugin
    {
        string DisplayName { get; }
        List<string> SupportedICs { get; }
        void ShowUI();
        void SetFile(string filePath);
        void SetPort(string portName);
        void Upload();
        void Log(string message);
        void HandleError(Exception ex);
    }
}