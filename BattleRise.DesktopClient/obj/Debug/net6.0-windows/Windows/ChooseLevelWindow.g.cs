﻿#pragma checksum "..\..\..\..\Windows\ChooseLevelWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "213C90AE6685F86CC196DA53229C7D308DED83A8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BattleRise.DesktopClient.Windows;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace BattleRise.DesktopClient.Windows {
    
    
    /// <summary>
    /// ChooseLevelWindow
    /// </summary>
    public partial class ChooseLevelWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Windows\ChooseLevelWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock text_name;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Windows\ChooseLevelWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock text_army;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Windows\ChooseLevelWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock text_countOfFighters;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Windows\ChooseLevelWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock text_reward;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Windows\ChooseLevelWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_battle;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BattleRise.DesktopClient;component/windows/chooselevelwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\ChooseLevelWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.text_name = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.text_army = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.text_countOfFighters = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.text_reward = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.button_battle = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\..\Windows\ChooseLevelWindow.xaml"
            this.button_battle.Click += new System.Windows.RoutedEventHandler(this.OnStartClick);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 15 "..\..\..\..\Windows\ChooseLevelWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnPreviousClick);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 16 "..\..\..\..\Windows\ChooseLevelWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnNextClick);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 17 "..\..\..\..\Windows\ChooseLevelWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnExitClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

