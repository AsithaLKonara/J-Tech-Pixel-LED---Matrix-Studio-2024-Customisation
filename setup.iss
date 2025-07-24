[Setup]
AppName=J Tech Pixel LED
AppVersion=1.0
DefaultDirName={pf}\J Tech Pixel LED
DefaultGroupName=J Tech Pixel LED
OutputBaseFilename=JTechPixelLED
Compression=lzma
SolidCompression=yes

[Files]
Source: "JTechPixelLED.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "avrdude.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "esptool.py"; DestDir: "{app}"; Flags: ignoreversion
Source: "stm32flash.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "PICkit3.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "Plugins\*.dll"; DestDir: "{app}\Plugins"; Flags: ignoreversion recursesubdirs
Source: "Documentation\*"; DestDir: "{app}\Documentation"; Flags: ignoreversion recursesubdirs
Source: "Logs\*"; DestDir: "{app}\Logs"; Flags: ignoreversion recursesubdirs
Source: "Exports\*"; DestDir: "{app}\Exports"; Flags: ignoreversion recursesubdirs

[Run]
Filename: "{app}\avrdude.exe"; Parameters: "-v"; Flags: runhidden
Filename: "{app}\esptool.py"; Parameters: "--version"; Flags: runhidden
Filename: "{app}\stm32flash.exe"; Parameters: "--version"; Flags: runhidden
Filename: "{app}\PICkit3.exe"; Parameters: "/version"; Flags: runhidden