using System;
using System.IO;

namespace JTechPixelLED
{
    public class ExportManager
    {
        public static void Export(string mode, string filePath, string format)
        {
            string exportDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Exports", mode);
            Directory.CreateDirectory(exportDir);

            string exportPath = Path.Combine(exportDir, Path.GetFileNameWithoutExtension(filePath) + "." + format);
            File.Copy(filePath, exportPath, true);
            File.WriteAllText(Path.Combine(exportDir, "log.txt"), $"Exported {filePath} to {exportPath} at {DateTime.Now}");
        }

        public static void GenerateArduinoSketch(string exportDir, int numFiles)
        {
            string sketch = $@"// Auto-generated Arduino/ESP32 sketch for SD card CSV animation
#include <SD.h>
#include <SPI.h>
#define SD_CS_PIN 5 // Change as needed
#define NUM_FILES {numFiles}

void setPixel(int x, int y, int state, uint32_t color) {
    // TODO: Implement for your LED matrix
}

void setup() {{
    Serial.begin(115200);
    if (!SD.begin(SD_CS_PIN)) {{
        Serial.println("SD card initialization failed!");
        while (1);
    }}
    // Initialize your LED matrix here
}}

void loop() {{
    for (int fileIdx = 1; fileIdx <= NUM_FILES; fileIdx++) {{
        String fileName = "/out" + String(fileIdx) + ".csv";
        File file = SD.open(fileName);
        if (!file) {{
            Serial.print("Failed to open ");
            Serial.println(fileName);
            continue;
        }}
        file.readStringUntil('\n'); // skip header
        while (file.available()) {{
            String line = file.readStringUntil('\n');
            if (line.length() == 0) continue;
            int idx1 = line.indexOf(',');
            int idx2 = line.indexOf(',', idx1 + 1);
            int idx3 = line.indexOf(',', idx2 + 1);
            int idx4 = line.indexOf(',', idx3 + 1);
            int idx5 = line.indexOf(',', idx4 + 1);
            int frame = line.substring(0, idx1).toInt();
            int x = line.substring(idx1 + 1, idx2).toInt();
            int y = line.substring(idx2 + 1, idx3).toInt();
            int state = line.substring(idx3 + 1, idx4).toInt();
            String colorStr = line.substring(idx4 + 1, idx5);
            float delaySec = line.substring(idx5 + 1).toFloat();
            uint32_t color = 0;
            if (colorStr.length() > 0) {{
                color = (uint32_t)strtoul(colorStr.c_str() + 1, NULL, 16);
            }}
            setPixel(x, y, state, color);
            delay((int)(delaySec * 1000));
        }}
        file.close();
    }}
    // Optionally, loop or stop
    // while (1);
}}
";
            File.WriteAllText(Path.Combine(exportDir, "led_player.ino"), sketch);
        }
    }
}