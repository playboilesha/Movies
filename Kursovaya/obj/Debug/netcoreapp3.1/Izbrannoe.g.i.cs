﻿#pragma checksum "..\..\..\Izbrannoe.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E1133CA539C527134C46A5C0F5E69813BDFB18AA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Kursovaya;
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


namespace Kursovaya {
    
    
    /// <summary>
    /// Izbrannoe
    /// </summary>
    public partial class Izbrannoe : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 52 "..\..\..\Izbrannoe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label login;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Izbrannoe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button tema1;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Izbrannoe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button tema2;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Izbrannoe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button main;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\Izbrannoe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Non;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\Izbrannoe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listviewUsers;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Kursovaya;V1.0.0.0;component/izbrannoe.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Izbrannoe.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 1 "..\..\..\Izbrannoe.xaml"
            ((Kursovaya.Izbrannoe)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.login = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.tema1 = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\Izbrannoe.xaml"
            this.tema1.Click += new System.Windows.RoutedEventHandler(this.temaBlack);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tema2 = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\Izbrannoe.xaml"
            this.tema2.Click += new System.Windows.RoutedEventHandler(this.temaWhite);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 61 "..\..\..\Izbrannoe.xaml"
            ((System.Windows.Controls.Image)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Log_out);
            
            #line default
            #line hidden
            return;
            case 6:
            this.main = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\Izbrannoe.xaml"
            this.main.Click += new System.Windows.RoutedEventHandler(this.MainStr);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 68 "..\..\..\Izbrannoe.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Zhanr);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 72 "..\..\..\Izbrannoe.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Search);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 73 "..\..\..\Izbrannoe.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Exite);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Non = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.listviewUsers = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 12:
            
            #line 137 "..\..\..\Izbrannoe.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Delete);
            
            #line default
            #line hidden
            break;
            case 13:
            
            #line 145 "..\..\..\Izbrannoe.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Opisanie);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

