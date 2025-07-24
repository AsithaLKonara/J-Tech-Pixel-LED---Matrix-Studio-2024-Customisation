# J Tech Pixel LED - Deployment Guide

## Release Information
- **Version**: 1.0.0
- **Release Date**: [Current Date]
- **Target Platforms**: Windows 10/11, macOS 10.15+

## System Requirements

### Minimum Requirements
- **OS**: Windows 10 (64-bit) or macOS 10.15+
- **RAM**: 4 GB
- **Storage**: 500 MB free space
- **Display**: 1024x768 minimum resolution

### Recommended Requirements
- **OS**: Windows 11 or macOS 12+
- **RAM**: 8 GB
- **Storage**: 1 GB free space
- **Display**: 1920x1080 or higher

### Required Tools (for Upload Plugins)
- **Arduino Uploader**: `avrdude` (included with Arduino IDE)
- **ESP01 Uploader**: `esptool.py` (Python-based)
- **Nuvoton Uploader**: `NuLinkISP.exe` (from Nuvoton)

## Installation Instructions

### Windows Installation
1. **Download** the latest release from the repository
2. **Extract** the ZIP file to your desired location
3. **Run** `JTechPixelLED.exe` as administrator (for USB access)
4. **Install** required tools (see Tool Installation section)

### macOS Installation
1. **Download** the latest release from the repository
2. **Extract** the ZIP file to Applications folder
3. **Run** `JTechPixelLED.app` from Applications
4. **Install** required tools (see Tool Installation section)

## Tool Installation

### Arduino Uploader Setup
```bash
# Install Arduino IDE (includes avrdude)
# Download from: https://www.arduino.cc/en/software
# Add Arduino tools to PATH or specify full path in plugin settings
```

### ESP01 Uploader Setup
```bash
# Install Python 3.7+
# Install esptool.py
pip install esptool

# Verify installation
esptool.py --version
```

### Nuvoton Uploader Setup
```bash
# Download Nu-Link ISP tool from Nuvoton website
# Install and add to PATH
# Available at: https://www.nuvoton.com/tool-and-software/software-development-tool/
```
## Additional Tool Requirements

For full functionality, ensure these tools are installed and in PATH:

### ESP Uploader
- `esptool.py` (Python package)
- Python 3.7+

### ATMEGA Uploader
- `avrdude` (comes with Arduino IDE)
- Arduino IDE (for tool installation)

### ATTINY Uploader
- `avrdude` with UPDI support
- USBasp programmer (if using hardware)

### PIC Uploader
- PICkit3 software
- MPLAB X IDE (for tool installation)

### Export Tool
- SD card library for Arduino
- Python 3.7+ for esptool.py
- AVR tools for ATMEGA/ATTINY
- PIC tools for PICkit3

## Additional Tool Requirements

For full functionality, ensure these tools are installed and in PATH:

### ATM01/RA508 Uploader
- `atm01uploader` - Custom tool for ATM01/RA508
- Requires specific hardware drivers for ATM01/RA508

### Export Tool
- `esptool.py` for ESP exports
- `avrdude` for ATMEGA/ATTINY exports
- `NuLinkISP.exe` for Nuvoton exports
- `pk3cmd` for PIC exports


## File Structure
```
JTechPixelLED/
├── JTechPixelLED.exe (Windows) / JTechPixelLED.app (macOS)
├── Plugins/
│   ├── ArduinoUploader/
│   ├── ESP01Uploader/
│   ├── NuvotonUploader/
│   └── ATM01Uploader/
├── DrawingPanel/
├── Utils/
├── Licensing/
├── Branding/
├── USER_MANUAL.md
├── DEPLOYMENT.md
├── README.md
└── JTechPixelLED.Tests/ (for development)
```

## Configuration

### Plugin Configuration
Each plugin can be configured via the UI:
- **COM Port Selection**: Auto-detected from system
- **File Paths**: Browse and select firmware files
- **Tool Paths**: Specify custom tool locations if needed

### Export Settings
- **Default Format**: Set preferred export format
- **File Location**: Configure default export directory
- **File Naming**: Customize export file naming

## Testing Deployment

### Pre-deployment Checklist
- [ ] All plugins load without errors
- [ ] Export formats work correctly
- [ ] Palette editor functions properly
- [ ] Animation controls respond correctly
- [ ] User manual is accessible
- [ ] License system works
- [ ] Automated tests pass

### Manual Testing
```bash
# Run automated tests
cd JTechPixelLED.Tests
dotnet test

# Expected output:
# Test summary: total: 5, failed: 0, succeeded: 5, skipped: 0
```

### Plugin Testing
1. **Arduino**: Test with real Arduino UNO board
2. **ESP01**: Test with ESP01 module and USB adapter
3. **Nuvoton**: Test with Nu-Link programmer
4. **ATM01/RA508**: Verify placeholder displays correctly

## Troubleshooting

### Common Issues

#### Plugin Not Loading
- **Check Dependencies**: Ensure required tools are installed
- **Verify PATH**: Tools must be in system PATH
- **Permissions**: Run as administrator (Windows)

#### Upload Failures
- **COM Port**: Verify correct port is selected
- **File Format**: Ensure file format matches plugin requirements
- **Hardware**: Check USB connections and drivers
- **Tool Version**: Update to latest tool versions

#### Export Issues
- **Permissions**: Check write permissions for export directory
- **Disk Space**: Ensure sufficient free space
- **File Format**: Verify format is supported

### Support Information
- **Documentation**: USER_MANUAL.md
- **Repository**: [GitHub URL]
- **Issues**: [GitHub Issues URL]
- **Email**: [Support Email]

## Release Notes

### Version 1.0.0
**New Features:**
- ✅ Complete plugin uploader system
- ✅ Multiple export formats (bin, dat, hex)
- ✅ Advanced palette editor with metadata
- ✅ Real-time animation speed controls
- ✅ Per-pixel timing support
- ✅ Comprehensive user manual
- ✅ Automated test suite
- ✅ Professional UI with status bar and tooltips

**Technical Improvements:**
- Modular plugin architecture
- Robust error handling
- Cross-platform compatibility
- Extensible design for future plugins

**Known Issues:**
- ATM01/RA508 plugin requires custom development
- Some tools may need manual PATH configuration

## Future Roadmap

### Planned Features
- **Dynamic Plugin Loading**: Load plugins from external DLLs
- **Additional Export Formats**: Support for more microcontroller platforms
- **Enhanced UI**: Dark mode, customizable themes
- **Cloud Integration**: Share palettes and animations online
- **Advanced Animation**: More complex animation patterns

### Custom Development
- **ATM01/RA508 Support**: Available as paid custom development
- **Proprietary Protocols**: Support for custom hardware
- **Enterprise Features**: Multi-user, network deployment

---

## License Information

This software is provided under the terms of the license agreement. For licensing inquiries, contact [Your Contact Information].

---

*For technical support or custom development, please refer to the contact information above.* 