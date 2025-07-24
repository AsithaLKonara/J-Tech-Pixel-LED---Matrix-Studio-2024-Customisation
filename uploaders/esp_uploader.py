import esptool

def upload_to_esp(file_path, port="/dev/ttyUSB0"):
    esp = esptool.ESPTool()
    esp.connect(port)
    esp.write_flash([file_path])  # Requires esptool.py integration
    esp.disconnect()