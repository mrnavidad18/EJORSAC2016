﻿#pragma checksum "..\..\ElegirFactura.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0C628F0C4300055DAA59E11581503E00"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.33440
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Behaviours;
using MahApps.Metro.Controls;
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


namespace SISJORSAC {
    
    
    /// <summary>
    /// ElegirFactura
    /// </summary>
    public partial class ElegirFactura : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\ElegirFactura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbtSinGuia;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\ElegirFactura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbtConGuia;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\ElegirFactura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtnroGuia;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\ElegirFactura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIngresar;
        
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
            System.Uri resourceLocater = new System.Uri("/SISJORSAC;component/elegirfactura.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ElegirFactura.xaml"
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
            this.rbtSinGuia = ((System.Windows.Controls.RadioButton)(target));
            
            #line 13 "..\..\ElegirFactura.xaml"
            this.rbtSinGuia.Checked += new System.Windows.RoutedEventHandler(this.rbtSinGuia_Checked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.rbtConGuia = ((System.Windows.Controls.RadioButton)(target));
            
            #line 14 "..\..\ElegirFactura.xaml"
            this.rbtConGuia.Checked += new System.Windows.RoutedEventHandler(this.rbtConGuia_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtnroGuia = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnIngresar = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\ElegirFactura.xaml"
            this.btnIngresar.Click += new System.Windows.RoutedEventHandler(this.btnIngresar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

