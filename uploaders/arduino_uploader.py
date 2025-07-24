import subprocess

def upload_to_arduino(file_path, port="/dev/ttyUSB0"):
    cmd = ["avrdude", "-c", "arduino", "-p", "m328p", "-P", port, "-U", f"flash:w:{file_path}:i"]
    result = subprocess.run(cmd, capture_output=True, text=True)
    if result.returncode != 0:
        raise Exception(f"Upload failed: {result.stderr}")
    print("Upload successful!")