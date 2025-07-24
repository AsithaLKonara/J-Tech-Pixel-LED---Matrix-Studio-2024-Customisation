public class ATMEGA328PUploader : UploaderPluginBase
{
    public override string[] SupportedFormats => [".hex"];
    public override string Name => "ATMEGA328P Uploader";
    public override string Description => "Uploads .hex files to ATMEGA328P via avrdude";

    public async Task UploadAsync(string filePath, string port, string baudRate, string chipModel)
    {
        if (!File.Exists(filePath))
        {
            Log("File not found!");
            return;
        }

        string args = $" -c arduino -p m328p -P {port} -b {baudRate} -U flash:w:{filePath}:i";
        string result = await RunCliTool("avrdude", args);
        Log(result == "Success" ? "Upload completed!" : "Upload failed!");
    }
}