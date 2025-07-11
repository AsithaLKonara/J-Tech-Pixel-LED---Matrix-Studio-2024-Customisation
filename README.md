# J-Tech-Pixel-LED---Matrix-Studio-2024-Customisation

# J Tech Pixel LED - User Manual

## Table of Contents
1. [Overview](#overview)
2. [Plugin Uploaders](#plugin-uploaders)
3. [Export Formats](#export-formats)
4. [Palette Editor](#palette-editor)
5. [Animation Controls](#animation-controls)
6. [Testing Guide](#testing-guide)

---

## Overview

J Tech Pixel LED is a comprehensive LED matrix editor and animation tool with support for multiple microcontroller platforms. The software allows you to create, edit, and upload LED patterns to various hardware platforms.

### Key Features
- **Pixel Drawing Panel**: Create animations with up to 150x150 pixels
- **Plugin Uploaders**: Support for Arduino, ESP01, Nuvoton, and custom platforms
- **Multiple Export Formats**: Binary, data, and hex file support
- **Advanced Palette Editor**: Custom color palettes with metadata
- **Animation Speed Controls**: Real-time playback speed adjustment

---

## Plugin Uploaders

The software includes four upload plugins, each designed for specific microcontroller platforms.

### Arduino UNO Uploader

**Supported Hardware**: Arduino UNO, Arduino Nano (ATmega328P)

**Requirements**:
- `avrdude` tool installed and in PATH
- USB connection to Arduino board
- `.hex` files exported from the software

**Usage**:
1. Select the **Arduino UNO Upload** tab
2. Choose the COM port from the dropdown
3. Browse and select your `.hex` file
4. Click **Upload** to flash the firmware
5. Monitor progress in the log window

**Command**: `avrdude -p atmega328p -c arduino -P COMx -b 115200 -U flash:w:file.hex`

### ESP01 Uploader

**Supported Hardware**: ESP01 (ESP8266-based modules)

**Requirements**:
- `esptool.py` tool installed and in PATH
- USB connection via CH340 or FTDI adapter
- `.bin` files exported from the software

**Usage**:
1. Select the **ESP01 Upload** tab
2. Choose the COM port from the dropdown
3. Set flash address (default: `0x00000`)
4. Browse and select your `.bin` file
5. Click **Upload** to flash the firmware
6. Monitor progress in the log window

**Command**: `esptool.py --port COMx write_flash 0x00000 file.bin`

### Nuvoton/NUMICRO Uploader

**Supported Hardware**: Nuvoton M031, M051, M252 series

**Requirements**:
- `NuLinkISP.exe` tool installed and in PATH
- Nu-Link USB programmer connected
- `.hex` or `.bin` files exported from the software

**Usage**:
1. Select the **Nuvoton Upload** tab
2. Choose the chip type from the dropdown
3. Select the COM port
4. Browse and select your firmware file
5. Click **Upload** to flash the firmware
6. Monitor progress in the log window

**Command**: `NuLinkISP.exe -chip M031 -file file.hex -port COMx`

### ATM01/RA508 Uploader (Custom/Future)

**Status**: Custom development required

**Note**: Support for ATM01/RA508 or other proprietary chips is not included by default. To enable this feature, please contact support with your programmer type, protocol, and test hardware. Custom plugin development is available as a paid service.

---

## Export Formats

The software supports multiple export formats for different use cases.

### Binary Export (.bin)
- **Format**: Raw binary data
- **Use Case**: Direct upload to microcontrollers
- **File Type**: Binary file
- **Command Line**: `avrdude -U flash:w:file.bin:i`

### Data Export (.dat)
- **Format**: Binary data with header information
- **Use Case**: Data files for custom applications
- **File Type**: Binary file with metadata
- **Compatibility**: Various microcontroller platforms

### Hex Export (.hex)
- **Format**: Human-readable hex dump
- **Use Case**: Debugging and manual verification
- **File Type**: Text file with hex values
- **Format**: `0A 1B 2C ...` (space-separated hex values)

### Export Process
1. Create your animation in the Pixel Drawing Panel
2. Click **Export** button
3. Choose your desired format (bin, dat, hex)
4. Select file location and name
5. Export completes with status confirmation

---

## Palette Editor

The advanced palette editor allows you to create, manage, and customize color palettes.

### Features
- **Save/Load Palettes**: Support for plain text and JSON formats
- **Reorder Colors**: Move colors up/down in the palette
- **Delete/Duplicate**: Remove or copy individual colors
- **Metadata**: Name and description for each palette
- **Import/Export**: Share palettes between projects

### Palette Formats

#### Plain Text Format
```
FF0000
00FF00
0000FF
FFFFFF
```
One hex color per line.

#### JSON Format
```json
{
  "name": "My Custom Palette",
  "description": "A custom color palette for LED projects",
  "colors": [16711680, 65280, 255, 16777215]
}
```

### Usage
1. **Save Palette**: Click "Save" button, choose format and location
2. **Load Palette**: Click "Load" button, select palette file
3. **Reorder**: Select color, use ↑/↓ buttons
4. **Delete**: Select color, click "Del" button
5. **Duplicate**: Select color, click "Copy" button
6. **Metadata**: Edit name and description in the top fields

---

## Animation Controls

### Speed Controls
- **Slider**: Adjust speed from 10ms to 1000ms per frame
- **Numeric Input**: Direct input of milliseconds per frame
- **FPS Display**: Real-time frames per second calculation
- **Real-time Updates**: Changes apply immediately during playback

### Playback Controls
- **Play**: Start animation playback
- **Stop**: Stop animation playback
- **Frame Navigation**: Previous/Next frame buttons
- **Frame Management**: Add, delete, clone frames

### Per-Pixel Timing
- **Individual Delays**: Each pixel can have its own ON delay (0.1s to 2.0s)
- **Right-click Menu**: Set pixel delay via context menu
- **Visual Feedback**: Animated pixels are highlighted during playback

---

## Testing Guide

### Manual Testing Checklist

#### Application Startup
- [ ] Application launches without errors
- [ ] All plugin tabs are visible
- [ ] Pixel Drawing Panel loads correctly

#### Plugin Testing
- [ ] **Arduino**: COM port detection, file selection, upload process
- [ ] **ESP01**: Flash address field, file selection, upload process
- [ ] **Nuvoton**: Chip selection, COM port, file selection, upload process
- [ ] **ATM01/RA508**: Placeholder message displays correctly

#### Export Testing
- [ ] **Binary Export**: .bin files created successfully
- [ ] **Data Export**: .dat files created successfully
- [ ] **Hex Export**: .hex files created successfully
- [ ] **File Validation**: Exported files can be opened/verified

#### Palette Testing
- [ ] **Save/Load**: Plain text and JSON formats work
- [ ] **Reorder**: Colors can be moved up/down
- [ ] **Delete/Duplicate**: Colors can be removed or copied
- [ ] **Metadata**: Name and description fields work

#### Animation Testing
- [ ] **Speed Controls**: Slider and numeric input work
- [ ] **Playback**: Play/stop functions correctly
- [ ] **Frame Management**: Add/delete/clone frames work
- [ ] **Per-pixel Timing**: Individual delays work correctly

### Automated Testing
Run the automated test suite:
```bash
cd JTechPixelLED.Tests
/usr/local/share/dotnet/dotnet test
```

Expected results:
```
Test summary: total: 5, failed: 0, succeeded: 5, skipped: 0
```

---

## Troubleshooting

### Common Issues

#### Plugin Upload Failures
- **Check Tool Installation**: Ensure required tools (avrdude, esptool.py, NuLinkISP.exe) are installed and in PATH
- **Verify COM Port**: Ensure correct COM port is selected
- **Check File Format**: Verify exported file format matches plugin requirements
- **Review Log Output**: Check log window for specific error messages

#### Export Issues
- **File Permissions**: Ensure write permissions for export directory
- **Disk Space**: Verify sufficient disk space for file creation
- **File Format**: Check that selected format is supported

#### Palette Issues
- **File Format**: Ensure palette files are in correct format (plain text or JSON)
- **File Encoding**: Use UTF-8 encoding for palette files
- **JSON Syntax**: Validate JSON syntax for JSON format palettes

#### Animation Issues
- **Speed Range**: Ensure speed values are within valid range (10-1000ms)
- **Frame Count**: Verify sufficient frames exist for animation
- **Memory**: Check available system memory for large animations

### Support

For technical support or custom plugin development:
- **Email**: asithalakmlakonara11992081@gmail.com
- **GitHub**:  https://github.com/AsithaLKonara/

---

## Version History

### Current Version
- **Version**: 1.0.0
- **Date**: 12 Jul 2025
- **Features**: Complete plugin system, export formats, palette editor, animation controls

### Previous Versions
- Initial release with basic LED matrix editing
- Added plugin uploader system
- Enhanced export capabilities
- Advanced palette management
- Real-time animation controls

---

*This manual covers all features implemented in J Tech Pixel LED. For additional information or custom development, please contact support.* 
