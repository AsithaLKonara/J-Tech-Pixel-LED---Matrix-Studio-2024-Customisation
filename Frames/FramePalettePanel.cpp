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

#include <vcl.h>
#pragma hdrstop

#include "FramePalettePanel.h"
#include "LanguageConstants.h"
#include "LanguageHandler.h"
#include "Registry.h"
#include "SystemSettings.h"
#include "Utility.h"
#include <fstream>
#include <nlohmann/json.hpp>
#include <codecvt>

extern LanguageHandler *GLanguageHandler;
extern SystemSettings *GSystemSettings;

//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TframePalette *framePalette;
//---------------------------------------------------------------------------
__fastcall TframePalette::TframePalette(TComponent* Owner)
	: TFrame(Owner)
{
    sbSavePalette->Hint = L"Save current palette to file (plain text, one hex color per line or JSON)";
    sbLoadPalette->Hint = L"Load palette from file (plain text, one hex color per line or JSON)";
    sbSavePalette->OnClick = sbSavePaletteClick;
    sbLoadPalette->OnClick = sbLoadPaletteClick;
    sbMoveUp->OnClick = sbMoveUpClick;
    sbMoveDown->OnClick = sbMoveDownClick;
    sbDeleteColour->OnClick = sbDeleteColourClick;
    sbDuplicateColour->OnClick = sbDuplicateColourClick;

    // Metadata UI
    ePaletteName->Text = L"Palette Name";
    ePaletteDescription->Text = L"Palette Description";
    ePaletteName->OnChange = [](TObject* Sender) {
        TframePalette* self = static_cast<TframePalette*>(Sender->Owner);
        self->PaletteName = self->ePaletteName->Text.c_str();
    };
    ePaletteDescription->OnChange = [](TObject* Sender) {
        TframePalette* self = static_cast<TframePalette*>(Sender->Owner);
        self->PaletteDescription = self->ePaletteDescription->Text.c_str();
    };
}


void TframePalette::Init()
{
	bClear->Caption = GLanguageHandler->Text[kClear].c_str();

	RGBPaletteHistory[0] = sRGBP1; RGBPaletteHistory[1] = sRGBP2; RGBPaletteHistory[2] = sRGBP3; RGBPaletteHistory[3] = sRGBP4;
	RGBPaletteHistory[4] = sRGBP5; RGBPaletteHistory[5] = sRGBP6; RGBPaletteHistory[6] = sRGBP7; RGBPaletteHistory[7] = sRGBP8;
	RGBPaletteHistory[8] = sRGBP9; RGBPaletteHistory[9] = sRGBP10; RGBPaletteHistory[10] = sRGBP11; RGBPaletteHistory[11] = sRGBP12;
	RGBPaletteHistory[12] = sRGBP13; RGBPaletteHistory[13] = sRGBP14; RGBPaletteHistory[14] = sRGBP15; RGBPaletteHistory[15] = sRGBP16;
	RGBPaletteHistory[16] = sRGBP17; RGBPaletteHistory[17] = sRGBP18; RGBPaletteHistory[18] = sRGBP19; RGBPaletteHistory[19] = sRGBP20;
	RGBPaletteHistory[20] = sRGBP21; RGBPaletteHistory[21] = sRGBP22; RGBPaletteHistory[22] = sRGBP23; RGBPaletteHistory[23] = sRGBP24;
	RGBPaletteHistory[24] = sRGBP25; RGBPaletteHistory[25] = sRGBP26; RGBPaletteHistory[26] = sRGBP27; RGBPaletteHistory[27] = sRGBP28;
	RGBPaletteHistory[28] = sRGBP29; RGBPaletteHistory[29] = sRGBP30; RGBPaletteHistory[30] = sRGBP31; RGBPaletteHistory[31] = sRGBP32;
	RGBPaletteHistory[32] = sRGBP33; RGBPaletteHistory[33] = sRGBP34; RGBPaletteHistory[34] = sRGBP35;

	RGBPaletteHistoryIndex = 0;

	LoadPaletteHistory();
}


void TframePalette::DeInit()
{
	SavePaletteHistory();
}


void TframePalette::SetUIToColour(int colour)
{
	int r = colour & 0x0000ff;
	int g = (colour & 0x00ff00) >> 8;
	int b = (colour & 0xff0000) >> 16;

	sRGBPaletteColour->Brush->Color = TColor(colour);

	tbRed->Position = r;
	tbGreen->Position = g;
	tbBlue->Position = b;

	eRed->Text = r;
	eGreen->Text = g;
	eBlue->Text = b;

	lPaletteColourHex->Caption = Utility::WS2US(GSystemSettings->App.HexPrefix) +
								 IntToHex(tbRed->Position, 2) +
								 IntToHex(tbGreen->Position, 2) +
								 IntToHex(tbBlue->Position, 2);

	lPaletteColourInteger->Caption = sRGBPaletteColour->Brush->Color;
}


void __fastcall TframePalette::eRedKeyPress(TObject *Sender, System::WideChar &Key)
{
	if (Key == 13)
	{
		TEdit *edit = (TEdit*)Sender;

		int value = edit->Text.ToIntDef(999);

		if (value >= 0 && value <= 255)
		{
			switch (edit->Tag)
			{
			case 0:
				tbRed->Position   = value;
				break;
			case 1:
				tbGreen->Position = value;
				break;
			case 2:
				tbBlue->Position  = value;
				break;
			}

			tbRedChange(nullptr);
		}
	}
}


void __fastcall TframePalette::sRGBP1MouseDown(TObject *Sender, TMouseButton Button, TShiftState Shift,
		  int X, int Y)
{
	TShape *shape = (TShape*)Sender;

	int colour = shape->Brush->Color;
	int mouse = 0;

	if (Shift.Contains(ssLeft))
	{
		mouse = 0;
	}
	else if (Shift.Contains(ssMiddle))
	{
		mouse = 1;
	}
	else if (Shift.Contains(ssRight))
	{
		mouse = 2;
	}

	SetUIToColour(colour);

	if (Sender == sRGBPaletteColour)
	{
		AddToHistory(colour);
    }

	if (OnColourClick) OnColourClick(mouse, colour);
}


void __fastcall TframePalette::sRGBP1MouseMove(TObject *Sender, TShiftState Shift, int X,
		  int Y)
{
	if (OnColourMove)
	{
		TShape *shape = (TShape*)Sender;

		OnColourMove(shape->Brush->Color);
	}
}


void __fastcall TframePalette::tbRedChange(TObject *Sender)
{
	if (Sender != nullptr)
	{
		TTrackBar *tb = (TTrackBar*)Sender;

		switch (tb->Tag)
		{
		case CRed:
			eRed->Text = tb->Position;
			break;
		case CGreen:
			eGreen->Text = tb->Position;
			break;
		case CBlue:
			eBlue->Text = tb->Position;
			break;
		}
	}

	lPaletteColourHex->Caption = Utility::WS2US(GSystemSettings->App.HexPrefix) +
								 IntToHex(tbRed->Position, 2) +
								 IntToHex(tbGreen->Position, 2) +
								 IntToHex(tbBlue->Position, 2);


	sRGBPaletteColour->Brush->Color = TColor((tbBlue->Position << 16) +
											 (tbGreen->Position << 8) +
											  tbRed->Position);

	lPaletteColourInteger->Caption = sRGBPaletteColour->Brush->Color;
}


void TframePalette::AddToHistory(int colour)
{
	bool canadd = true;

	for (int t = 0; t < kPalletCount; t++)
	{
		if (colour == RGBPaletteHistory[t]->Brush->Color)
		{
			canadd = false;
			break;
		}
	}

	if (canadd)
	{
		RGBPaletteHistory[RGBPaletteHistoryIndex]->Brush->Color = TColor(colour);

		if (RGBPaletteHistoryIndex == kPalletCount - 1)
		{
			RGBPaletteHistoryIndex = 0;
		}
		else
		{
			RGBPaletteHistoryIndex++;
		}
	}
}


bool TframePalette::LoadPaletteHistory()
{
    HKEY hKey;

	LONG dwRet;

	dwRet = RegOpenKeyEx(HKEY_CURRENT_USER,
						 L"SOFTWARE\\freshney.org\\MatrixBuilder",
						 NULL,
						 KEY_READ,
						 &hKey);

	if (dwRet != ERROR_SUCCESS)
	{
		return false;
	}

	// ===========================================================================

	for (int t = 0; t < kPalletCount; t++)
	{
		int x = Registry::ReadInteger(hKey, L"rgbpalettehistory" + std::to_wstring(t), 0);

		RGBPaletteHistory[t]->Brush->Color = TColor(x);
	}

	// ===========================================================================

	RegCloseKey(hKey);

	return true;
}


bool TframePalette::SavePaletteHistory()
{
	// ===========================================================================
	// == Save User Settings =====================================================
	// ===========================================================================

    HKEY hKey;

	LONG dwRet;

	dwRet = RegOpenKeyEx(HKEY_CURRENT_USER,
						 L"SOFTWARE\\freshney.org\\MatrixBuilder",
						 NULL,
						 KEY_WRITE,
						 &hKey);

	if (dwRet != ERROR_SUCCESS)
	{
		return false;
	}

	// ===========================================================================

	for (int t = 0; t < kPalletCount; t++)
	{
		Registry::WriteInteger(hKey, L"rgbpalettehistory" + std::to_wstring(t), RGBPaletteHistory[t]->Brush->Color);
	}

	// ===========================================================================

	RegCloseKey(hKey);

    return true;
}


void __fastcall TframePalette::bClearClick(TObject *Sender)
{
	if (MessageDlg(GLanguageHandler->Text[kAreYouSureYouWantToClearThePalette].c_str(), mtWarning, mbYesNo, 0) == mrYes)
	{
		for (int t = 0; t < kPalletCount; t++)
		{
            RGBPaletteHistory[t]->Brush->Color = clBlack;
		}

        RGBPaletteHistoryIndex = 0;
	}
}

void __fastcall TframePalette::sbMoveUpClick(TObject *Sender)
{
    int idx = GetSelectedPaletteIndex();
    if (idx > 0) {
        std::swap(Palette[idx], Palette[idx-1]);
        SetSelectedPaletteIndex(idx-1);
        UpdatePaletteUI();
    }
}

void __fastcall TframePalette::sbMoveDownClick(TObject *Sender)
{
    int idx = GetSelectedPaletteIndex();
    if (idx >= 0 && idx < Palette.size()-1) {
        std::swap(Palette[idx], Palette[idx+1]);
        SetSelectedPaletteIndex(idx+1);
        UpdatePaletteUI();
    }
}

void __fastcall TframePalette::sbDeleteColourClick(TObject *Sender)
{
    int idx = GetSelectedPaletteIndex();
    if (idx >= 0 && Palette.size() > 1) {
        Palette.erase(Palette.begin() + idx);
        SetSelectedPaletteIndex(std::max(0, idx-1));
        UpdatePaletteUI();
    }
}

void __fastcall TframePalette::sbDuplicateColourClick(TObject *Sender)
{
    int idx = GetSelectedPaletteIndex();
    if (idx >= 0) {
        Palette.insert(Palette.begin() + idx, Palette[idx]);
        SetSelectedPaletteIndex(idx+1);
        UpdatePaletteUI();
    }
}

void TframePalette::SetPaletteName(const std::wstring& name) {
    PaletteName = name;
    ePaletteName->Text = name.c_str();
}
void TframePalette::SetPaletteDescription(const std::wstring& desc) {
    PaletteDescription = desc;
    ePaletteDescription->Text = desc.c_str();
}
std::wstring TframePalette::GetPaletteName() const {
    return PaletteName;
}
std::wstring TframePalette::GetPaletteDescription() const {
    return PaletteDescription;
}
void TframePalette::UpdateMetadataUI() {
    ePaletteName->Text = PaletteName.c_str();
    ePaletteDescription->Text = PaletteDescription.c_str();
}

void TframePalette::SavePaletteAsJSON(const std::wstring &filename) {
    nlohmann::json j;
    j["name"] = Utility::WS2US(PaletteName);
    j["description"] = Utility::WS2US(PaletteDescription);
    j["colors"] = nlohmann::json::array();
    for (int t = 0; t < kPalletCount; t++) {
        j["colors"].push_back(Palette[t]);
    }
    std::ofstream file(filename);
    if (file) {
        file << j.dump(2);
    }
}
void TframePalette::LoadPaletteFromJSON(const std::wstring &filename) {
    nlohmann::json j;
    std::ifstream file(filename);
    if (file) {
        file >> j;
        Palette.clear();
        if (j.contains("colors")) {
            for (auto &c : j["colors"]) {
                Palette.push_back(c.get<int>());
            }
        }
        if (j.contains("name")) {
            PaletteName = Utility::US2WS(j["name"].get<std::string>());
        } else {
            PaletteName = L"";
        }
        if (j.contains("description")) {
            PaletteDescription = Utility::US2WS(j["description"].get<std::string>());
        } else {
            PaletteDescription = L"";
        }
        UpdateMetadataUI();
        UpdatePaletteUI();
    }
}

std::vector<int> TframePalette::LoadPaletteAuto(const std::wstring &filename)
{
    std::vector<int> result;
    if (filename.size() > 5 && filename.substr(filename.size()-5) == L".json") {
        // JSON
        nlohmann::json j;
        std::ifstream file(filename);
        if (file) {
            file >> j;
            for (auto &c : j["colors"]) {
                result.push_back(c.get<int>());
            }
        }
    } else {
        // Plain text
        std::wifstream file(filename);
        if (file) {
            std::wstring line;
            while (std::getline(file, line)) {
                try {
                    int color = std::stoi(line, nullptr, 16);
                    result.push_back(color);
                } catch (...) {}
            }
        }
    }
    return result;
}

void __fastcall TframePalette::sbSavePaletteClick(TObject *Sender)
{
    if (sdPalette->Execute())
    {
        std::wstring fname = sdPalette->FileName.c_str();
        if (fname.size() > 5 && fname.substr(fname.size()-5) == L".json")
            SavePaletteAsJSON(fname);
        else
        {
            std::wofstream file(fname);
            if (file)
            {
                for (auto color : Palette)
                {
                    file << std::hex << std::setw(6) << std::setfill(L'0') << color << L"\n";
                }
            }
        }
    }
}

void __fastcall TframePalette::sbLoadPaletteClick(TObject *Sender)
{
    if (odPalette->Execute())
    {
        std::wstring fname = odPalette->FileName.c_str();
        if (fname.size() > 5 && fname.substr(fname.size()-5) == L".json")
            LoadPaletteFromJSON(fname);
        else
        {
            std::wifstream file(fname);
            if (file)
            {
                Palette.clear();
                std::wstring line;
                while (std::getline(file, line))
                {
                    int color = std::stoi(line, nullptr, 16);
                    Palette.push_back(color);
                }
                SetSelectedPaletteIndex(0);
                UpdatePaletteUI();
            }
        }
    }
}
