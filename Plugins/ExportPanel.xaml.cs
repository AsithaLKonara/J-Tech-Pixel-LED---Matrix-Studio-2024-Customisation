using System;
using System.IO;
using System.Windows.Controls;
using JTechPixelLED.Utils;

namespace JTechPixelLED.Plugins.Export
{
    public partial class ExportPanel : UserControl
    {
        public ExportPanel()
        {
            InitializeComponent();
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            // Get pixel data from main application
            byte[] pixelData = GetPixelDataFromMainApp();
            
            // Split into 1000 pixel chunks
            int chunkSize = 1000;
            int totalChunks = (int)Math.Ceiling((double)pixelData.Length / chunkSize);
            
            // Create output directory
            string outputDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "PixelLEDExports");
            Directory.CreateDirectory(outputDir);
            
            // Export each chunk
            for (int i = 0; i < totalChunks; i++)
            {
                int startIdx = i * chunkSize;
                int endIdx = Math.Min(startIdx + chunkSize, pixelData.Length);
                byte[] chunk = pixelData.Skip(startIdx).Take(endIdx - startIdx).ToArray();
                
                string chunkDir = Path.Combine(outputDir, $"Chunk_{i+1:D3}");
                Directory.CreateDirectory(chunkDir);
                
                // Export .bin file
                File.WriteAllBytes(Path.Combine(chunkDir, $"pattern_{i+1:D3}.bin"), chunk);
                
                // Export .dat file with metadata
                string datContent = $"// Pattern chunk {i+1} of {totalChunks}\n// Start: {startIdx}, End: {endIdx}\n\n";
                File.WriteAllText(Path.Combine(chunkDir, $"pattern_{i+1:D3}.dat"), datContent);
                
                // Export .hex file
                string hexContent = BitConverter.ToString(chunk).Replace("-", " ");
                File.WriteAllText(Path.Combine(chunkDir, $"pattern_{i+1:D3}.hex"), hexContent);
            }
            
            // Generate Arduino sketch
            GenerateArduinoSketch(outputDir, totalChunks);
        }

        private void GenerateArduinoSketch(string outputDir, int totalChunks)
        {
            string sketch = $@"#include <SD.h>

File myFile;
const int chipSelect = 10;

void setup() {{
  Serial.begin(9600);
  while (!Serial) {{;}} // wait for serial port to connect

  if (!SD.begin(chipSelect)) {{
    Serial.println(""Card failed, or not present"");
    return;
  }}
  
  Serial.println(""card initialized."");
  
  for (int i = 1; i <= {totalChunks}; i++) {{
    char filename[20];
    sprintf(filename, ""/pattern_%03d.bin"", i);
    
    if (SD.exists(filename)) {{
      myFile = SD.open(filename, FILE_READ);
      if (myFile) {{
        // Upload logic here
        Serial.print(""Uploading "" + String(filename));
        
        // Read and process file
        while (myFile.available()) {{
          // Process data
        }}
        
        myFile.close();
      }}
    }}
  }}
}}

void loop() {{
  // Empty
}}";

            File.WriteAllText(Path.Combine(outputDir, "UploaderSketch.ino"), sketch);
        }
    }
}