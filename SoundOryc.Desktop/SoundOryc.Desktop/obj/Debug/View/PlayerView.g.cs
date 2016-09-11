﻿#pragma checksum "..\..\..\View\PlayerView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A9E3907EA86E0A135B3E457ED3FE8D27"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GalaSoft.MvvmLight.Command;
using MahApps.Metro.Controls;
using SoundOryc.Desktop.ViewModel;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interactivity;
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


namespace SoundOryc.Desktop.View {
    
    
    /// <summary>
    /// PlayerView
    /// </summary>
    public partial class PlayerView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\View\PlayerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider psTimeProgress;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\View\PlayerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblActualTime;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\View\PlayerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTotalTime;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\View\PlayerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblArtistName;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\View\PlayerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblSongName;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\View\PlayerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnQueue;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\View\PlayerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPrev;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\View\PlayerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPlayPause;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\View\PlayerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNext;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\View\PlayerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider psVolume;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\View\PlayerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPlayMode;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\View\PlayerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnVolume;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SoundOryc.Desktop;component/view/playerview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\PlayerView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.psTimeProgress = ((System.Windows.Controls.Slider)(target));
            return;
            case 2:
            this.lblActualTime = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.lblTotalTime = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.lblArtistName = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lblSongName = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.btnQueue = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.btnPrev = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.btnPlayPause = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.btnNext = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            this.psVolume = ((System.Windows.Controls.Slider)(target));
            return;
            case 11:
            this.btnPlayMode = ((System.Windows.Controls.Button)(target));
            return;
            case 12:
            this.btnVolume = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

