
ProcessStartInfo startInfo = new ProcessStartInfo
{
    FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "avrdude.exe"),
    Arguments = "-c arduino -p m328p -P COM3 -b 115200 -U flash:w:file.hex:i",
    RedirectStandardOutput = true,
    RedirectStandardError = true,
    UseShellExecute = false,
    CreateNoWindow = false
};