﻿namespace SISJORSAC.Reportes
{
    partial class ReporteClientesNaturales
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteClientesNaturales));
            this.sPTBLCLIENTELISTARREPORTENATURALBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetPrincipal = new SISJORSAC.DataSetPrincipal();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sP_TBL_CLIENTE_LISTAR_REPORTE_NATURALTableAdapter = new SISJORSAC.DataSetPrincipalTableAdapters.SP_TBL_CLIENTE_LISTAR_REPORTE_NATURALTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sPTBLCLIENTELISTARREPORTENATURALBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // sPTBLCLIENTELISTARREPORTENATURALBindingSource
            // 
            this.sPTBLCLIENTELISTARREPORTENATURALBindingSource.DataMember = "SP_TBL_CLIENTE_LISTAR_REPORTE_NATURAL";
            this.sPTBLCLIENTELISTARREPORTENATURALBindingSource.DataSource = this.dataSetPrincipal;
            // 
            // dataSetPrincipal
            // 
            this.dataSetPrincipal.DataSetName = "DataSetPrincipal";
            this.dataSetPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sPTBLCLIENTELISTARREPORTENATURALBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SISJORSAC.Reportes.InformeClientesNaturales.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1014, 616);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ReportRefresh += new System.ComponentModel.CancelEventHandler(this.reportViewer1_ReportRefresh);
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // sP_TBL_CLIENTE_LISTAR_REPORTE_NATURALTableAdapter
            // 
            this.sP_TBL_CLIENTE_LISTAR_REPORTE_NATURALTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteClientesNaturales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1014, 616);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReporteClientesNaturales";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ReporteClientes";
            this.TransparencyKey = System.Drawing.Color.Aquamarine;
            this.Load += new System.EventHandler(this.ReporteClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sPTBLCLIENTELISTARREPORTENATURALBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPrincipal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSetPrincipal dataSetPrincipal;
        private System.Windows.Forms.BindingSource sPTBLCLIENTELISTARREPORTENATURALBindingSource;
        private DataSetPrincipalTableAdapters.SP_TBL_CLIENTE_LISTAR_REPORTE_NATURALTableAdapter sP_TBL_CLIENTE_LISTAR_REPORTE_NATURALTableAdapter;

    }
}