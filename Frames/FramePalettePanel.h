// ===================================================================
//
//   (c) Paul Alan Freshney 2012-2024
//   www.freshney.org :: paul@freshney.org :: maximumoctopus.com
//
//   https://github.com/MaximumOctopus/LEDMatrixStudio
//
//   https://maximumoctopus.hashnode.dev/
//
//   C++ Rewrite October 11th 2023
//
// ===================================================================

#ifndef FramePalettePanelH
#define FramePalettePanelH
//---------------------------------------------------------------------------
#include <System.Classes.hpp>
#include <Vcl.Controls.hpp>
#include <Vcl.StdCtrls.hpp>
#include <Vcl.Forms.hpp>
#include <Vcl.ComCtrls.hpp>
#include <Vcl.ExtCtrls.hpp>
#include <Vcl.Buttons.hpp>
//---------------------------------------------------------------------------
class TframePalette : public TFrame
{
__published:	// IDE-managed Components
	TLabel *lPaletteColourHex;
	TShape *sRGBPaletteColour;
	TShape *sRGBP7;
	TShape *sRGBP6;
	TShape *sRGBP5;
	TShape *sRGBP4;
	TShape *sRGBP3;
	TShape *sRGBP2;
	TShape *sRGBP1;
	TShape *sRGBP8;
	TShape *sRGBP9;
	TShape *sRGBP15;
	TShape *sRGBP16;
	TShape *sRGBP23;
	TShape *sRGBP22;
	TShape *sRGBP24;
	TShape *sRGBP17;
	TShape *sRGBP10;
	TShape *sRGBP11;
	TShape *sRGBP18;
	TShape *sRGBP25;
	TShape *sRGBP26;
	TShape *sRGBP19;
	TShape *sRGBP12;
	TShape *sRGBP13;
	TShape *sRGBP20;
	TShape *sRGBP27;
	TShape *sRGBP28;
	TShape *sRGBP21;
	TShape *sRGBP14;
	TLabel *lPaletteColourInteger;
	TTrackBar *tbRed;
	TEdit *eRed;
	TTrackBar *tbGreen;
	TEdit *eGreen;
	TEdit *eBlue;
	TTrackBar *tbBlue;
	TShape *sRGBP30;
	TShape *sRGBP29;
	TShape *sRGBP31;
	TShape *sRGBP32;
	TShape *sRGBP33;
	TShape *sRGBP34;
	TShape *sRGBP35;
	TSpeedButton *bClear;
	TSpeedButton *sbSavePalette;
	TSpeedButton *sbLoadPalette;
	TSpeedButton *sbMoveUp;
	TSpeedButton *sbMoveDown;
	TSpeedButton *sbDeleteColour;
	TSpeedButton *sbDuplicateColour;
	TOpenDialog *odPalette;
	TSaveDialog *sdPalette;
	void __fastcall eRedKeyPress(TObject *Sender, System::WideChar &Key);
	void __fastcall sRGBP1MouseDown(TObject *Sender, TMouseButton Button, TShiftState Shift,
          int X, int Y);
	void __fastcall sRGBP1MouseMove(TObject *Sender, TShiftState Shift, int X, int Y);
	void __fastcall tbRedChange(TObject *Sender);
	void __fastcall bClearClick(TObject *Sender);
	void __fastcall sbSavePaletteClick(TObject *Sender);
	void __fastcall sbLoadPaletteClick(TObject *Sender);
	void __fastcall sbMoveUpClick(TObject *Sender);
	void __fastcall sbMoveDownClick(TObject *Sender);
	void __fastcall sbDeleteColourClick(TObject *Sender);
	void __fastcall sbDuplicateColourClick(TObject *Sender);

private:

	static const int CRed   = 0;
	static const int CGreen = 1;
	static const int CBlue  = 2;

	static const int kPalletCount = 35;

	int RGBPaletteHistoryIndex = 0;

	void SetUIToColour(int);

	bool LoadPaletteHistory();
	bool SavePaletteHistory();
	void SavePaletteAsJSON(const std::wstring &filename);
	void LoadPaletteFromJSON(const std::wstring &filename);

    std::wstring PaletteName;
    std::wstring PaletteDescription;

public:
	__fastcall TframePalette(TComponent* Owner);

	TShape *RGBPaletteHistory[kPalletCount];

	void Init();
	void DeInit();

	void AddToHistory(int);

	std::function<void(int, int)> OnColourClick;
	std::function<void(int)> OnColourMove;

	static std::vector<int> LoadPaletteAuto(const std::wstring &filename);

    void SetPaletteName(const std::wstring& name);
    void SetPaletteDescription(const std::wstring& desc);
    std::wstring GetPaletteName() const;
    std::wstring GetPaletteDescription() const;
    void UpdateMetadataUI();
};
//---------------------------------------------------------------------------
extern PACKAGE TframePalette *framePalette;
//---------------------------------------------------------------------------
#endif
