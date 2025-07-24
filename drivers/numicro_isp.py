import subprocess

def upload_to_numicro(file_path, port="/dev/ttyUSB0"):
    cmd = ["NuvotonISP", "-p", port, "-f", file_path]
    result = subprocess.run(cmd, capture_output=True, text=True)
    if "Success" not in result.stdout:
        raise Exception("NUMICRO upload failed")