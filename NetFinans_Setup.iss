; =====================================================================
; NetFinans - Inno Setup Kurulum Betiği
; =====================================================================

#define MyAppName "NetFinans"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "NetFinans"
#define MyAppURL "https://www.netfinans.com"

; Self-Contained derleme çıktısındaki NetFinans.exe kullanılır:
#if FileExists("bin\Release\net8.0-windows\publish\NetFinans.exe") || FileExists("bin\Release\net8.0-windows\NetFinans.exe")
  #define MyAppExeName "NetFinans.exe"
#else
  #define MyAppExeName "MuhasebeOtomasyonu.exe"
#endif

[Setup]
; Benzersiz Uygulama Kimliği (GUID)
AppId={{E58D7C9A-4B21-4E18-912A-18A7F4839C20}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes
; Kurulum dosyasının (.exe) kaydedileceği klasör ve dosya adı:
OutputDir=Kurulum_Ciktisi
OutputBaseFilename=NetFinans_Kurulum
SetupIconFile=app.ico
UninstallDisplayIcon={app}\app.ico
Compression=lzma2/max
SolidCompression=yes
WizardStyle=modern
ArchitecturesInstallIn64BitMode=x64compatible
PrivilegesRequired=admin

[Languages]
Name: "turkish"; MessagesFile: "compiler:Languages\Turkish.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
; 1. Uygulama ikonu
Source: "app.ico"; DestDir: "{app}"; Flags: ignoreversion

; 2. Self-Contained yayın klasörü (.NET Desktop Runtime içinde gömülüdür, müşteride uyarı çıkmaz)
#if DirExists("bin\Release\net8.0-windows\publish")
  Source: "bin\Release\net8.0-windows\publish\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
#else
  Source: "bin\Release\net8.0-windows\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
#endif

; 3. Veritabanı kurulum scripti (Yedek ve referans olarak SQL klasörüne kopyalanır)
Source: "database.sql"; DestDir: "{app}\SQL"; Flags: ignoreversion

[Icons]
; Başlat Menüsü ve Masaüstü Kısayolları
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\app.ico"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\app.ico"; Tasks: desktopicon

[Run]
; Kurulum tamamlandığında programı çalıştırma seçeneği
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
