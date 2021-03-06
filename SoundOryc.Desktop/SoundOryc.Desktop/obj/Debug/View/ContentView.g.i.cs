﻿#pragma checksum "..\..\..\View\ContentView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BC1DAA15762483B503BFF4D46BA8C93F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using GalaSoft.MvvmLight.Command;
using Itenso.Windows.Controls.ListViewLayout;
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
    /// ContentView
    /// </summary>
    public partial class ContentView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 42 "..\..\..\View\ContentView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSongs;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\View\ContentView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnArtists;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\View\ContentView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAlbums;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\View\ContentView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblPlaylistName;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\View\ContentView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvSongs;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\View\ContentView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContextMenu menu;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\View\ContentView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem addQueue;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\View\ContentView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem addPlaylist;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\View\ContentView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem createNew;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\View\ContentView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem deleteSong;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\View\ContentView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button loadNextListButton;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\View\ContentView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button loadPrevListButton;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\View\ContentView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblPage;
        
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
            System.Uri resourceLocater = new System.Uri("/SoundOryc.Desktop;component/view/contentview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\ContentView.xaml"
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
            this.btnSongs = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.btnArtists = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.btnAlbums = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.lblPlaylistName = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lvSongs = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            this.menu = ((System.Windows.Controls.ContextMenu)(target));
            return;
            case 7:
            this.addQueue = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 8:
            this.addPlaylist = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 9:
            this.createNew = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 10:
            this.deleteSong = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 11:
            this.loadNextListButton = ((System.Windows.Controls.Button)(target));
            return;
            case 12:
            this.loadPrevListButton = ((System.Windows.Controls.Button)(target));
            return;
            case 13:
            this.lblPage = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

