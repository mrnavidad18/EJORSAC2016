﻿#pragma checksum "..\..\FrmChoferRegistro.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DDCFDC11DBD6F41C6325789573672C22"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.34014
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
    /// FrmChoferRegistro
    /// </summary>
    public partial class FrmChoferRegistro : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\FrmChoferRegistro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridChofer;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\FrmChoferRegistro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNombres;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\FrmChoferRegistro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtApellidos;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\FrmChoferRegistro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNroBrevete;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\FrmChoferRegistro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAgregarChofer;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\FrmChoferRegistro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLimpiarTodo;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\FrmChoferRegistro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNroCertificado;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\FrmChoferRegistro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtVehiculoMARCA;
        
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
            System.Uri resourceLocater = new System.Uri("/SISJORSAC;component/frmchoferregistro.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\FrmChoferRegistro.xaml"
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
            this.GridChofer = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.txtNombres = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtApellidos = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtNroBrevete = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnAgregarChofer = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\FrmChoferRegistro.xaml"
            this.btnAgregarChofer.Click += new System.Windows.RoutedEventHandler(this.btnServicio_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnLimpiarTodo = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\FrmChoferRegistro.xaml"
            this.btnLimpiarTodo.Click += new System.Windows.RoutedEventHandler(this.btnLimpiarTodo_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txtNroCertificado = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txtVehiculoMARCA = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

