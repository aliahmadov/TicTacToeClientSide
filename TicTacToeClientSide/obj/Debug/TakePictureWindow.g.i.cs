﻿#pragma checksum "..\..\TakePictureWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5ED06E8A15E29CE9C267D27898EAF7A2CF54CEFBA60D2B7FDF89A3E129B99320"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using TicTacToeClientSide;


namespace TicTacToeClientSide {
    
    
    /// <summary>
    /// TakePictureWindow
    /// </summary>
    public partial class TakePictureWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 43 "..\..\TakePictureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel cameraPanel;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\TakePictureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image picturePreview;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\TakePictureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StreamBtn;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\TakePictureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CaptureBtn;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\TakePictureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image captureImage;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\TakePictureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameTxtBox;
        
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
            System.Uri resourceLocater = new System.Uri("/TicTacToeClientSide;component/takepicturewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TakePictureWindow.xaml"
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
            
            #line 8 "..\..\TakePictureWindow.xaml"
            ((TicTacToeClientSide.TakePictureWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cameraPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.picturePreview = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.StreamBtn = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\TakePictureWindow.xaml"
            this.StreamBtn.Click += new System.Windows.RoutedEventHandler(this.StreamBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CaptureBtn = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\TakePictureWindow.xaml"
            this.CaptureBtn.Click += new System.Windows.RoutedEventHandler(this.CaptureBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.captureImage = ((System.Windows.Controls.Image)(target));
            return;
            case 7:
            this.nameTxtBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

