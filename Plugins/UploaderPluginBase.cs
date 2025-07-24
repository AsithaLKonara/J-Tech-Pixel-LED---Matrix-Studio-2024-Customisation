public abstract class UploaderPluginBase : IUploaderPlugin
{
    protected string _log = "";
    public string Name => "Base Uploader";
    public string Description => "Base functionality for all uploaders";
    public abstract string[] SupportedFormats { get; }

    public string GetLog() => _log;

    protected void Log(string message)
    {
        _log += $"{DateTime.Now:HH:mm:ss} - {message}\n";
    }

    protected async Task<string> RunCliTool(string toolPath, string arguments)
{
    try
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = toolPath,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };
        process.Start();
        string output = await process.StandardOutput.ReadToEndAsync();
        string error = await process.StandardError.ReadToEndAsync();
        await process.WaitForExitAsync();

        if (error.Contains("not found") || error.Contains("No such file"))
            Log("Error: File or port not found!");
        else if (error.Contains("Failed"))
            Log("Error: Upload failed!");
        else
        {
            Log(output);
            Log(error);
        }

        return process.ExitCode == 0 ? "Success" : "Failure";
    }
    catch (Exception ex)
    {
        Log($"Exception: {ex.Message}");
        return "Failure";
    }
}
}