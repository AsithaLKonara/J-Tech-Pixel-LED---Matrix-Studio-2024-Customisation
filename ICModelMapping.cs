using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace JTechPixelLED
{
    public class ICModelMapping
    {
        public string ICName { get; set; }
        public string Exporter { get; set; }
        public string UploaderPlugin { get; set; }
        public Dictionary<string, object> Options { get; set; }

        public static List<ICModelMapping> LoadMappings(string jsonPath)
        {
            if (!File.Exists(jsonPath)) return new List<ICModelMapping>();
            var json = File.ReadAllText(jsonPath);
            return JsonSerializer.Deserialize<List<ICModelMapping>>(json);
        }
    }
} 