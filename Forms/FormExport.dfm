object frmExport: TfrmExport
  Left = 0
  Top = 0
  ClientHeight = 711
  ClientWidth = 1012
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -12
  Font.Name = 'Segoe UI'
  Font.Style = []
  Position = poMainFormCenter
  OnClose = FormClose
  OnConstrainedResize = FormConstrainedResize
  OnShow = FormShow
  TextHeight = 15
  object Panel1: TPanel
    Left = 0
    Top = 647
    Width = 1012
    Height = 64
    Align = alBottom
    Color = clWhite
    ParentBackground = False
    TabOrder = 0
    DesignSize = (
      1012
      64)
    object gbProfiles: TGroupBox
      Left = 4
      Top = 2
      Width = 333
      Height = 55
      Caption = '.'
      TabOrder = 0
      object Bevel2: TBevel
        Left = 252
        Top = 28
        Width = 4
        Height = 12
        Shape = bsLeftLine
      end
      object sbSave: TBitBtn
        Left = 259
        Top = 21
        Width = 68
        Height = 25
        Glyph.Data = {
          E6040000424DE604000000000000360000002800000014000000140000000100
          180000000000B0040000232E0000232E00000000000000000000FF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
          00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFFFF
          FFFFFFFFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFFFFFFFFFFFF
          FF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFF00FFFF
          00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00
          FFFF00FFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FF
          FFFFFFFFFFFFFF00FFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFFFFFFFF
          FFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
          FF00FFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFFFF
          FFFFFBFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFFFF
          FFFFFFFFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF
          00FFFF00FFFF00FFFFFFFFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFFFFFFFFFFFF
          FF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFFFFFFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFF
          00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
          FFFFFFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00
          FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFF
          FFFFFFFFFFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
          FFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
          00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFF00FFFF00FF}
        TabOrder = 0
        OnClick = sbSaveClick
      end
      object sbOpen: TBitBtn
        Left = 8
        Top = 21
        Width = 57
        Height = 25
        Glyph.Data = {
          E6040000424DE604000000000000360000002800000014000000140000000100
          180000000000B0040000232E0000232E00000000000000000000FF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
          00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFFFFFFFFFFFFFFFFFFFF00FFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFF00FFFF00FFFFFFFFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFF00FFFF00FFFFFFFFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          00FFFF00FFFFFFFFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFF00FF
          FF00FFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFF00
          FFFFFFFFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF
          00FFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFFFFFF
          FFFFFFFFFFFFFF00FFFFFFFFFFFFFFFFFFFFFF00FFFFFFFFFF00FFFFFFFFFF00
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFFFFFFFFFFFFFF
          FFFFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFFFFFFFFFFFFFFFFFFFF00
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFFFFFFFFFFFFFFFFFFFF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFF00
          FFFF00FFFFFFFFFF00FFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFF00FFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          00FFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFF00
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFF
          FFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
          00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFF00FFFF00FF}
        TabOrder = 1
        OnClick = sbOpenClick
      end
      object cbProfileList: TComboBox
        Left = 67
        Top = 23
        Width = 142
        Height = 23
        Style = csDropDownList
        TabOrder = 2
      end
      object sbDelete: TBitBtn
        Left = 215
        Top = 21
        Width = 31
        Height = 25
        Hint = 'delete'
        Glyph.Data = {
          E6040000424DE604000000000000360000002800000014000000140000000100
          180000000000B0040000232E0000232E00000000000000000000FF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
          00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
          FF00FFFFFFFFFFFFFFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
          FFFFFFFFFFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FF
          FF00FFFF00FFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          00FFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFF00
          FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
          00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFFFFFF
          FFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFFFFFFFFFFFFFF
          00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
          FF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
          00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFFFFFFFFFFFFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF
          00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFF
          FFFFFFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF
          00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00
          FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
          00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
          00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFF00FFFF00FF}
        TabOrder = 3
        OnClick = sbDeleteClick
      end
    end
    object GroupBox6: TGroupBox
      Left = 676
      Top = 2
      Width = 314
      Height = 55
      Anchors = [akRight, akBottom]
      Caption = '.'
      TabOrder = 1
      object bCancel: TBitBtn
        Left = 228
        Top = 21
        Width = 75
        Height = 25
        Cancel = True
        Glyph.Data = {
          76050000424D7605000000000000360000002800000015000000150000000100
          18000000000040050000232E0000232E00000000000000000000FF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF00FF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF00FF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF00FF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF00FF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF00FF00FFFF00FF
          FF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FF00FF00FFFF00FF
          FF00FFFF00FFFF00FFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00
          FFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FF00FF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFFFF
          FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF00FF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFFFFFFFF00FFFFFFFFFFFF
          FFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF00FF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF00FF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFFFFFFFF00FFFF00
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF00FF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF00FF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFFFFFFFF00FFFFFFFFFFFF
          FFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF00FF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFFFF
          FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF00FF00FFFF00FF
          FF00FFFF00FFFF00FFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00
          FFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FF00FF00FFFF00FF
          FF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FF00FF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF00FF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF00FF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF00FF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF00}
        ModalResult = 2
        TabOrder = 0
      end
      object bExport: TBitBtn
        Left = 10
        Top = 21
        Width = 87
        Height = 25
        Glyph.Data = {
          E6040000424DE604000000000000360000002800000014000000140000000100
          180000000000B0040000232E0000232E00000000000000000000FF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
          00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFFFF
          FFFFFFFFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFFFFFFFFFFFF
          FF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFF00FFFF
          00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00
          FFFF00FFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FF
          FFFFFFFFFFFFFF00FFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFFFFFFFF
          FFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
          FF00FFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFFFF
          FFFFFBFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFFFF
          FFFFFFFFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF
          00FFFF00FFFF00FFFFFFFFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFFFFFFFFFFFF
          FF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFFFFFFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFF
          00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
          FFFFFFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00
          FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFF
          FFFFFFFFFFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
          FFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
          00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFF00FFFF00FF}
        TabOrder = 1
        OnClick = bExportClick
      end
      object bCopyToClipboard: TBitBtn
        Left = 99
        Top = 21
        Width = 31
        Height = 25
        Hint = 'copy to clipboard'
        Glyph.Data = {
          E6040000424DE604000000000000360000002800000014000000140000000100
          180000000000B0040000232E0000232E00000000000000000000FF00FFFF00FF
          FF00FFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFF
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
          00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FF
          FFFFFFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFF
          FFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFFFFFFFF
          FFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFF
          FF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFFFF
          FFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF
          00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00
          FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FF
          FF00FFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00
          FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF
          FFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
          FF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFF
          FFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFFFF
          FFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF
          00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFF
          FF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFF00FFFF
          00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00
          FFFF00FFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF
          00FFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FF
          FF00FFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00
          FFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
          00FFFF00FFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
          FFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFF
          00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
          FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
          FFFF00FFFF00FFFF00FF}
        TabOrder = 2
        OnClick = bCopyToClipboardClick
      end
      object bClose: TBitBtn
        Left = 148
        Top = 21
        Width = 75
        Height = 25
        ModalResult = 1
        TabOrder = 3
        OnClick = bCloseClick
      end
    end
    object cbAutoPreview: TCheckBox
      Left = 471
      Top = 24
      Width = 122
      Height = 17
      Caption = '.'
      TabOrder = 2
    end
    object bBuildCode: TBitBtn
      Left = 362
      Top = 21
      Width = 103
      Height = 25
      Glyph.Data = {
        E6040000424DE604000000000000360000002800000014000000140000000100
        180000000000B0040000232E0000232E00000000000000000000FF00FFFF00FF
        FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
        FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
        00FFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
        FFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
        FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
        00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
        FF00FFFFFFFFFFFFFFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00
        FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
        FFFFFFFFFFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FF
        FF00FFFF00FFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
        FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
        00FFFF00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
        FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFF00
        FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
        00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFFFFFF
        FFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
        FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFFFFFFFFFFFFFF
        00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
        FF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00
        FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
        00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FF
        FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
        FFFFFFFFFFFFFFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF
        00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFF
        FFFFFFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
        FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF
        00FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
        FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00
        FFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
        00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFFFFFFFFFFFF00FFFF00FFFFFFFF
        FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
        FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFFFFFFFF
        FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
        FFFFFFFFFFFFFFFFFFFFFFFFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
        FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
        00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
        FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
        FFFF00FFFF00FFFF00FF}
      TabOrder = 3
      OnClick = bBuildCodeClick
    end
  end
  object pcExport: TPageControl
    Left = 0
    Top = 0
    Width = 1012
    Height = 647
    ActivePage = tsCode
    Align = alClient
    TabOrder = 1
    OnChange = cbOptimiseClick
    object tsCode: TTabSheet
      Caption = '.'
      object Panel2: TPanel
        Left = 0
        Top = 0
        Width = 409
        Height = 617
        Align = alLeft
        BevelInner = bvRaised
        BevelOuter = bvLowered
        TabOrder = 0
        ExplicitLeft = -5
        object gbSource: TGroupBox
          Left = 15
          Top = 8
          Width = 185
          Height = 257
          Caption = '.'
          TabOrder = 0
          object sbDataRows: TSpeedButton
            Left = 16
            Top = 24
            Width = 75
            Height = 25
            GroupIndex = 1
            Down = True
            Caption = '.'
            OnClick = cbDirectionChange
          end
          object sbDataColumns: TSpeedButton
            Left = 97
            Top = 24
            Width = 75
            Height = 25
            GroupIndex = 1
            Caption = '.'
            OnClick = cbDirectionChange
          end
          object lFrame: TLabel
            Left = 16
            Top = 120
            Width = 3
            Height = 15
            Caption = '.'
          end
          object Label2: TLabel
            Left = 87
            Top = 142
            Width = 11
            Height = 15
            Caption = 'to'
          end
          object lSelectiveOutput: TLabel
            Left = 16
            Top = 172
            Width = 3
            Height = 15
            Caption = '.'
          end
          object Label9: TLabel
            Left = 87
            Top = 194
            Width = 11
            Height = 15
            Caption = 'to'
          end
          object cbDirection: TComboBox
            Left = 16
            Top = 55
            Width = 152
            Height = 23
            Style = csDropDownList
            TabOrder = 0
            OnChange = cbOptimiseClick
          end
          object cbScanDirection: TComboBox
            Left = 16
            Top = 84
            Width = 152
            Height = 23
            Style = csDropDownList
            TabOrder = 1
            OnChange = cbOptimiseClick
          end
          object eFrameStart: TEdit
            Left = 16
            Top = 141
            Width = 55
            Height = 23
            TabOrder = 2
            Text = '1'
            OnExit = cbOptimiseClick
          end
          object eFrameEnd: TEdit
            Left = 113
            Top = 139
            Width = 55
            Height = 23
            TabOrder = 3
            Text = '1'
            OnExit = cbOptimiseClick
          end
          object cbOptimise: TCheckBox
            Left = 16
            Top = 220
            Width = 166
            Height = 17
            Caption = '.'
            TabOrder = 4
            OnClick = cbOptimiseClick
          end
          object eSelectiveStart: TEdit
            Left = 16
            Top = 191
            Width = 55
            Height = 23
            ParentCustomHint = False
            TabOrder = 5
            Text = '1'
            OnExit = cbOptimiseClick
          end
          object eSelectiveEnd: TEdit
            Left = 113
            Top = 191
            Width = 55
            Height = 23
            TabOrder = 6
            Text = '1'
            OnExit = cbOptimiseClick
          end
        end
        object gbLSB: TGroupBox
          Left = 210
          Top = 8
          Width = 185
          Height = 58
          Caption = '.'
          TabOrder = 1
          object sbLSBLeft: TSpeedButton
            Left = 12
            Top = 24
            Width = 75
            Height = 25
            GroupIndex = 1
            OnClick = cbOptimiseClick
          end
          object sbLSBRight: TSpeedButton
            Left = 93
            Top = 24
            Width = 75
            Height = 25
            GroupIndex = 1
            Down = True
            OnClick = cbOptimiseClick
          end
        end
        object gbExportFormat: TGroupBox
          Left = 210
          Top = 72
          Width = 185
          Height = 81
          Caption = '.'
          TabOrder = 2
          object cbLanguageFormat: TComboBox
            Left = 16
            Top = 20
            Width = 152
            Height = 23
            Style = csDropDownList
            TabOrder = 0
            OnChange = cbOptimiseClick
          end
          object cbIncludeExample: TCheckBox
            Left = 16
            Top = 54
            Width = 166
            Height = 17
            Caption = '.'
            TabOrder = 1
            OnClick = cbOptimiseClick
          end
        end
        object gbNumberFormat: TGroupBox
          Left = 210
          Top = 160
          Width = 185
          Height = 59
          Caption = '.'
          TabOrder = 3
          object sbNumberDecimal: TSpeedButton
            Left = 16
            Top = 24
            Width = 50
            Height = 25
            GroupIndex = 2
            OnClick = cbOptimiseClick
          end
          object sbNumberBinary: TSpeedButton
            Left = 67
            Top = 24
            Width = 50
            Height = 25
            GroupIndex = 2
            OnClick = cbOptimiseClick
          end
          object sbNumberHex: TSpeedButton
            Left = 118
            Top = 24
            Width = 50
            Height = 25
            GroupIndex = 2
            Down = True
            OnClick = cbOptimiseClick
          end
        end
        object gbNumberGrouping: TGroupBox
          Left = 210
          Top = 330
          Width = 185
          Height = 122
          Caption = '.'
          TabOrder = 4
          object sbNumberSize8bit: TSpeedButton
            Left = 16
            Top = 24
            Width = 50
            Height = 25
            GroupIndex = 2
            Down = True
            Caption = '8 bit'
            OnClick = sbNumberSize8bitClick
          end
          object sbNumberSize16bit: TSpeedButton
            Left = 67
            Top = 24
            Width = 50
            Height = 25
            GroupIndex = 2
            Caption = '16 bit'
            OnClick = sbNumberSize8bitClick
          end
          object sbNumberSize32bit: TSpeedButton
            Left = 118
            Top = 24
            Width = 50
            Height = 25
            GroupIndex = 2
            Caption = '32 bit'
            OnClick = sbNumberSize8bitClick
          end
          object sbNumberSize8bitSwap: TSpeedButton
            Left = 16
            Top = 55
            Width = 152
            Height = 25
            GroupIndex = 2
            OnClick = sbNumberSize8bitClick
          end
          object sbNumberSize16bitSwap: TSpeedButton
            Left = 16
            Top = 86
            Width = 152
            Height = 25
            GroupIndex = 2
            OnClick = sbNumberSize8bitClick
          end
        end
        object gbEachLine: TGroupBox
          Left = 15
          Top = 276
          Width = 185
          Height = 90
          Caption = '.'
          TabOrder = 5
          object sbOutputRow: TSpeedButton
            Tag = 1
            Left = 16
            Top = 24
            Width = 75
            Height = 25
            GroupIndex = 1
            Down = True
            Caption = '.'
            OnClick = cbDirectionChange
          end
          object sbOutputFrame: TSpeedButton
            Tag = 1
            Left = 97
            Top = 24
            Width = 75
            Height = 25
            GroupIndex = 1
            Caption = '.'
            OnClick = cbDirectionChange
          end
          object sbOutputBytes: TSpeedButton
            Tag = 1
            Left = 16
            Top = 55
            Width = 75
            Height = 25
            GroupIndex = 1
            Caption = '.'
            OnClick = cbDirectionChange
          end
          object cbLineCount: TComboBox
            Left = 93
            Top = 57
            Width = 75
            Height = 23
            Style = csDropDownList
            TabOrder = 0
            OnClick = cbDirectionChange
          end
        end
        object gbRGB: TGroupBox
          Left = 15
          Top = 381
          Width = 185
          Height = 160
          Caption = '.'
          TabOrder = 6
          Visible = False
          object sbRGB: TSpeedButton
            Left = 16
            Top = 24
            Width = 40
            Height = 25
            GroupIndex = 2
            Down = True
            Caption = 'RGB'
            OnClick = sbRGBClick
          end
          object sbBGR: TSpeedButton
            Left = 55
            Top = 24
            Width = 40
            Height = 25
            GroupIndex = 2
            Caption = 'BGR'
            OnClick = sbRGBClick
          end
          object sbGRB: TSpeedButton
            Left = 95
            Top = 24
            Width = 40
            Height = 25
            GroupIndex = 2
            Caption = 'GRB'
            OnClick = sbRGBClick
          end
          object shapeBackgroundPixels: TShape
            Left = 73
            Top = 90
            Width = 88
            Height = 24
            Brush.Color = clBlack
            OnMouseDown = shapeBackgroundPixelsMouseDown
          end
          object Label1: TLabel
            Left = 40
            Top = 96
            Width = 3
            Height = 15
            Caption = '.'
          end
          object sbBRG: TSpeedButton
            Left = 135
            Top = 24
            Width = 40
            Height = 25
            GroupIndex = 2
            Caption = 'BRG'
            OnClick = sbRGBClick
          end
          object Label6: TLabel
            Left = 16
            Top = 130
            Width = 3
            Height = 15
            Caption = '.'
          end
          object Label7: TLabel
            Left = 111
            Top = 130
            Width = 10
            Height = 15
            Caption = '%'
          end
          object cbChangeBackgroundPixels: TCheckBox
            Left = 16
            Top = 64
            Width = 152
            Height = 17
            Caption = '.'
            TabOrder = 0
            OnClick = cbOptimiseClick
          end
          object groupBoxRGBBrightness: TEdit
            Left = 73
            Top = 128
            Width = 32
            Height = 23
            TabOrder = 1
            Text = '100'
          end
        end
        object gbNumberGroupingRGB: TGroupBox
          Left = 210
          Top = 230
          Width = 185
          Height = 90
          Caption = '.'
          TabOrder = 7
          Visible = False
          object sbNumberSizeRGB8bits: TSpeedButton
            Left = 16
            Top = 24
            Width = 152
            Height = 25
            GroupIndex = 2
            Caption = '.'
            OnClick = sbNumberSize8bitClick
          end
          object sbNumberSizeRGB32bits: TSpeedButton
            Left = 16
            Top = 55
            Width = 152
            Height = 25
            GroupIndex = 2
            Down = True
            Caption = '.'
            OnClick = sbNumberSize8bitClick
          end
        end
        object gbRGBColourSpace: TGroupBox
          Left = 210
          Top = 458
          Width = 185
          Height = 90
          Caption = 'Colour Space'
          TabOrder = 8
          Visible = False
          object sbCSRGB32: TSpeedButton
            Left = 16
            Top = 24
            Width = 152
            Height = 25
            GroupIndex = 2
            Down = True
            Caption = 'RGB32'
            OnClick = cbOptimiseClick
          end
          object sbCSRGB565: TSpeedButton
            Left = 16
            Top = 55
            Width = 152
            Height = 25
            GroupIndex = 2
            Caption = 'RGB565'
            OnClick = cbOptimiseClick
          end
        end
        object bResetCode: TBitBtn
          Left = 15
          Top = 590
          Width = 380
          Height = 22
          ModalResult = 1
          TabOrder = 9
          OnClick = bResetCodeClick
        end
      end
      object Panel4: TPanel
        Left = 409
        Top = 0
        Width = 595
        Height = 617
        Align = alClient
        TabOrder = 1
        object reExport: TRichEdit
          Left = 1
          Top = 1
          Width = 593
          Height = 592
          Align = alClient
          Font.Charset = ANSI_CHARSET
          Font.Color = clWindowText
          Font.Height = -12
          Font.Name = 'Courier New'
          Font.Style = []
          Lines.Strings = (
            ''
            ''
            ''
            
              '        Click the Build Code buttom below to generate the data..' +
              '.'
            ''
            
              '        The more pixels you have the longer it will take to buil' +
              'd.'
            
              '        Large displays with a lot of animation may take many sec' +
              'onds.'
            ''
            '        Please be patient!'
            ''
            
              '        This preview will show the first $X lines of output, thi' +
              's setting'
            '        can be altered in Preferences.'
            ''
            
              '        Auto-build will be enabled on this page if the number of' +
              ' pixels'
            
              '        is fewer than the setting entered on the Prefereces page' +
              '.'
            '        (File menu -> Preferences)')
          ParentFont = False
          PlainText = True
          ReadOnly = True
          ScrollBars = ssVertical
          TabOrder = 0
          OnMouseWheelDown = reExportMouseWheelDown
          OnMouseWheelUp = reExportMouseWheelUp
        end
        object pPreviewStatus: TPanel
          Left = 1
          Top = 593
          Width = 593
          Height = 23
          Align = alBottom
          TabOrder = 1
        end
      end
    end
    object tsBinary: TTabSheet
      Caption = '.'
      ImageIndex = 1
      object Panel3: TPanel
        Left = 0
        Top = 0
        Width = 409
        Height = 617
        Align = alLeft
        BevelInner = bvRaised
        BevelOuter = bvLowered
        TabOrder = 0
        object gbSourceBinary: TGroupBox
          Left = 15
          Top = 8
          Width = 185
          Height = 257
          Caption = 'Source'
          TabOrder = 0
          object sbBinaryDataRows: TSpeedButton
            Left = 16
            Top = 24
            Width = 75
            Height = 25
            GroupIndex = 1
            Down = True
            OnClick = sbBinaryDataRowsClick
          end
          object sbBinaryDataColumns: TSpeedButton
            Left = 97
            Top = 24
            Width = 75
            Height = 25
            GroupIndex = 1
            OnClick = sbBinaryDataRowsClick
          end
          object Label3: TLabel
            Left = 16
            Top = 120
            Width = 3
            Height = 15
            Caption = '.'
          end
          object Label4: TLabel
            Left = 87
            Top = 142
            Width = 11
            Height = 15
            Caption = 'to'
          end
          object lBinarySelectiveOutput: TLabel
            Left = 16
            Top = 173
            Width = 3
            Height = 15
            Caption = '.'
          end
          object Label10: TLabel
            Left = 87
            Top = 195
            Width = 11
            Height = 15
            Caption = 'to'
          end
          object cbBinaryDirection: TComboBox
            Left = 16
            Top = 55
            Width = 152
            Height = 23
            Style = csDropDownList
            TabOrder = 0
            OnChange = cbOptimiseClick
          end
          object cbBinaryScanDirection: TComboBox
            Left = 16
            Top = 84
            Width = 152
            Height = 23
            Style = csDropDownList
            TabOrder = 1
            OnChange = cbOptimiseClick
          end
          object eBinaryFrameStart: TEdit
            Left = 16
            Top = 139
            Width = 55
            Height = 23
            TabOrder = 2
            Text = '1'
            OnClick = cbOptimiseClick
            OnExit = cbOptimiseClick
          end
          object eBinaryFrameEnd: TEdit
            Left = 113
            Top = 139
            Width = 55
            Height = 23
            TabOrder = 3
            Text = '1'
            OnExit = cbOptimiseClick
          end
          object cbBinaryOptimise: TCheckBox
            Left = 16
            Top = 229
            Width = 152
            Height = 17
            Caption = '.'
            TabOrder = 4
            Visible = False
            OnClick = cbOptimiseClick
          end
          object eBinarySelectiveStart: TEdit
            Left = 16
            Top = 192
            Width = 55
            Height = 23
            ParentCustomHint = False
            TabOrder = 5
            Text = '1'
            OnExit = cbOptimiseClick
          end
          object eBinarySelectiveEnd: TEdit
            Left = 113
            Top = 192
            Width = 55
            Height = 23
            TabOrder = 6
            Text = '1'
            OnExit = cbOptimiseClick
          end
        end
        object gbLSBBinary: TGroupBox
          Left = 15
          Top = 279
          Width = 185
          Height = 58
          Caption = '.'
          TabOrder = 1
          object sbBinaryLSBLeft: TSpeedButton
            Left = 16
            Top = 24
            Width = 75
            Height = 25
            GroupIndex = 1
            Down = True
            OnClick = cbOptimiseClick
          end
          object sbBinaryLSBRight: TSpeedButton
            Left = 93
            Top = 24
            Width = 75
            Height = 25
            GroupIndex = 1
            OnClick = cbOptimiseClick
          end
        end
        object gbNumberGroupingBinary: TGroupBox
          Left = 210
          Top = 8
          Width = 185
          Height = 60
          Caption = '.'
          TabOrder = 2
          object sbBinaryNumberSize8bit: TSpeedButton
            Left = 16
            Top = 24
            Width = 44
            Height = 25
            GroupIndex = 2
            Down = True
            Caption = '8 bit'
            OnClick = cbOptimiseClick
          end
          object sbBinaryNumberSize8bitSwap: TSpeedButton
            Left = 62
            Top = 24
            Width = 106
            Height = 25
            GroupIndex = 2
            Caption = '8 bit (swap nibbles)'
            OnClick = cbOptimiseClick
          end
          object sbBinaryNumberSize16bitSwap: TSpeedButton
            Left = 16
            Top = 86
            Width = 152
            Height = 25
            GroupIndex = 2
            Caption = '16 bit (swap bytes)'
          end
        end
        object gbBinaryRGB: TGroupBox
          Left = 15
          Top = 356
          Width = 185
          Height = 165
          Caption = '.'
          TabOrder = 3
          Visible = False
          object sbBinaryRGB: TSpeedButton
            Left = 16
            Top = 24
            Width = 40
            Height = 25
            GroupIndex = 2
            Down = True
            Caption = 'RGB'
            OnClick = sbRGBClick
          end
          object sbBinaryBGR: TSpeedButton
            Left = 55
            Top = 24
            Width = 40
            Height = 25
            GroupIndex = 2
            Caption = 'BGR'
            OnClick = sbRGBClick
          end
          object sbBinaryGRB: TSpeedButton
            Left = 95
            Top = 24
            Width = 40
            Height = 25
            GroupIndex = 2
            Caption = 'GRB'
            OnClick = sbRGBClick
          end
          object shapeBinaryBackgroundPixels: TShape
            Left = 73
            Top = 90
            Width = 88
            Height = 24
            Brush.Color = clBlack
            OnMouseDown = shapeBackgroundPixelsMouseDown
          end
          object Label5: TLabel
            Left = 40
            Top = 96
            Width = 3
            Height = 15
            Caption = '.'
          end
          object sbBinaryBRG: TSpeedButton
            Left = 135
            Top = 24
            Width = 40
            Height = 25
            GroupIndex = 2
            Caption = 'BRG'
            OnClick = sbRGBClick
          end
          object Label8: TLabel
            Left = 25
            Top = 138
            Width = 3
            Height = 15
            Caption = '.'
          end
          object Label11: TLabel
            Left = 119
            Top = 138
            Width = 10
            Height = 15
            Caption = '%'
          end
          object cbBinaryChangeBackgroundPixels: TCheckBox
            Left = 16
            Top = 64
            Width = 152
            Height = 17
            Caption = '.'
            TabOrder = 0
            OnClick = cbOptimiseClick
          end
          object groupBoxBinaryRGBBrightness: TEdit
            Left = 81
            Top = 136
            Width = 32
            Height = 23
            TabOrder = 1
            Text = '100'
            OnExit = cbOptimiseClick
          end
        end
        object gbNumberGroupingBinaryRGB: TGroupBox
          Left = 210
          Top = 172
          Width = 185
          Height = 67
          Caption = 'Number Grouping'
          TabOrder = 4
          Visible = False
          object sbBinaryNumberSizeRGB8bits: TSpeedButton
            Left = 16
            Top = 24
            Width = 152
            Height = 25
            GroupIndex = 2
            Down = True
            OnClick = sbNumberSize8bitClick
          end
        end
        object gbFileContents: TGroupBox
          Left = 210
          Top = 79
          Width = 185
          Height = 80
          Caption = '.'
          TabOrder = 5
          object rbSaveAnimation: TRadioButton
            Left = 24
            Top = 26
            Width = 145
            Height = 17
            Caption = '.'
            Checked = True
            TabOrder = 0
            TabStop = True
            OnClick = cbOptimiseClick
          end
          object rbSaveFrame: TRadioButton
            Left = 24
            Top = 50
            Width = 145
            Height = 17
            Caption = '.'
            TabOrder = 1
            OnClick = cbOptimiseClick
          end
        end
        object gbBinaryColourSpaceRGB: TGroupBox
          Left = 210
          Top = 252
          Width = 185
          Height = 90
          Caption = 'Colour Space'
          TabOrder = 6
          Visible = False
          object sbBCSRGB32: TSpeedButton
            Left = 16
            Top = 24
            Width = 152
            Height = 25
            GroupIndex = 2
            Down = True
            Caption = 'RGB32'
            OnClick = cbOptimiseClick
          end
          object sbBCSRGB565: TSpeedButton
            Left = 16
            Top = 55
            Width = 152
            Height = 25
            GroupIndex = 2
            Caption = 'RGB565'
            OnClick = cbOptimiseClick
          end
        end
        object cbSDCardExport: TCheckBox
          Left = 16
          Top = 550
          Width = 250
          Height = 17
          Caption = 'Split for SD Card (1000 pixels per file)'
          TabOrder = 7
          OnClick = cbSDCardExportClick
        end
        object eBatchSize: TEdit
          Left = 270
          Top = 548
          Width = 60
          Height = 23
          TabOrder = 8
          Text = '1000'
          Enabled = False
        end
        object bResetBinary: TBitBtn
          Left = 15
          Top = 590
          Width = 380
          Height = 22
          ModalResult = 1
          TabOrder = 9
          OnClick = bResetBinaryClick
        end
      end
      object mBinary: TMemo
        Left = 409
        Top = 0
        Width = 595
        Height = 617
        Align = alClient
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -12
        Font.Name = 'Courier New'
        Font.Style = []
        ParentFont = False
        ScrollBars = ssVertical
        TabOrder = 1
      end
    end
  end
  object sdExport: TSaveDialog
    DefaultExt = '.h'
    Filter = 'C-style header file (.h)|*.h|Include file (.inc)|*.inc'
    Options = [ofOverwritePrompt, ofHideReadOnly, ofEnableSizing]
    Left = 392
    Top = 16
  end
  object cdExport: TColorDialog
    Left = 432
    Top = 16
  end
end
