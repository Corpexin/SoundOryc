﻿#pragma checksum "..\..\..\View\RegisterDialogView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6EA917E4DACDB36518AE5F2390FF9AED"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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
    /// RegisterDialogView
    /// </summary>
    public partial class RegisterDialogView : MahApps.Metro.Controls.Dialogs.CustomDialog, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\View\RegisterDialogView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\View\RegisterDialogView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button closeRDialogButton;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\View\RegisterDialogView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbRUsername;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\View\RegisterDialogView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox tbRPassword;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\View\RegisterDialogView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox tbRePassword;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\View\RegisterDialogView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblRInfoRL;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\View\RegisterDialogView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRRegister;
        
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
            System.Uri resourceLocater = new System.Uri("/SoundOryc.Desktop;component/view/registerdialogview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\RegisterDialogView.xaml"
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
            this.lbl = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.closeRDialogButton = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.tbRUsername = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbRPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 52 "..\..\..\View\RegisterDialogView.xaml"
            this.tbRPassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.PasswordBox_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tbRePassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 54 "..\..\..\View\RegisterDialogView.xaml"
            this.tbRePassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.rePasswordBox_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lblRInfoRL = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.btnRRegister = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

