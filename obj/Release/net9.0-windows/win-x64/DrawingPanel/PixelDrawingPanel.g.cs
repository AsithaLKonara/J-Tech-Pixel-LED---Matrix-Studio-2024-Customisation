﻿#pragma checksum "..\..\..\..\..\DrawingPanel\PixelDrawingPanel.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8FAC49E7A93221B6F0F1079E30DBE47F5E41F7D1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace JTechPixelLED.DrawingPanel {
    
    
    /// <summary>
    /// PixelDrawingPanel
    /// </summary>
    public partial class PixelDrawingPanel : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\..\DrawingPanel\PixelDrawingPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock FrameLabel;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\DrawingPanel\PixelDrawingPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider GridSizeSlider;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\..\DrawingPanel\PixelDrawingPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox RgbModeCheck;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\..\DrawingPanel\PixelDrawingPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.UniformGrid PixelGrid;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\..\DrawingPanel\PixelDrawingPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Snackbar PanelSnackbar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.7.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/JTechPixelLED;component/drawingpanel/pixeldrawingpanel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\DrawingPanel\PixelDrawingPanel.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\..\..\DrawingPanel\PixelDrawingPanel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PrevFrame_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.FrameLabel = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            
            #line 14 "..\..\..\..\..\DrawingPanel\PixelDrawingPanel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NextFrame_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 17 "..\..\..\..\..\DrawingPanel\PixelDrawingPanel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddFrame_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 20 "..\..\..\..\..\DrawingPanel\PixelDrawingPanel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteFrame_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 23 "..\..\..\..\..\DrawingPanel\PixelDrawingPanel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CloneFrame_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 26 "..\..\..\..\..\DrawingPanel\PixelDrawingPanel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PlayAnimation_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 29 "..\..\..\..\..\DrawingPanel\PixelDrawingPanel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.StopAnimation_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 32 "..\..\..\..\..\DrawingPanel\PixelDrawingPanel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Export_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 35 "..\..\..\..\..\DrawingPanel\PixelDrawingPanel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Import_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.GridSizeSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 39 "..\..\..\..\..\DrawingPanel\PixelDrawingPanel.xaml"
            this.GridSizeSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.GridSizeSlider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.RgbModeCheck = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 13:
            this.PixelGrid = ((System.Windows.Controls.Primitives.UniformGrid)(target));
            return;
            case 14:
            this.PanelSnackbar = ((MaterialDesignThemes.Wpf.Snackbar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

