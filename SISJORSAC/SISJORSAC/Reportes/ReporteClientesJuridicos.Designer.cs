namespace SISJORSAC.Reportes
{
    partial class ReporteClientesJuridicos
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSetPrincipal = new SISJORSAC.DataSetPrincipal();
            this.sPTBLCLIENTELISTARREPORTEJURIDICOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sP_TBL_CLIENTE_LISTAR_REPORTE_JURIDICOTableAdapter = new SISJORSAC.DataSetPrincipalTableAdapters.SP_TBL_CLIENTE_LISTAR_REPORTE_JURIDICOTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPTBLCLIENTELISTARREPORTEJURIDICOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sPTBLCLIENTELISTARREPORTEJURIDICOBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SISJORSAC.Reportes.InformeClientesJuridicos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(920, 516);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSetPrincipal
            // 
            this.dataSetPrincipal.DataSetName = "DataSetPrincipal";
            this.dataSetPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sPTBLCLIENTELISTARREPORTEJURIDICOBindingSource
            // 
            this.sPTBLCLIENTELISTARREPORTEJURIDICOBindingSource.DataMember = "SP_TBL_CLIENTE_LISTAR_REPORTE_JURIDICO";
            this.sPTBLCLIENTELISTARREPORTEJURIDICOBindingSource.DataSource = this.dataSetPrincipal;
            // 
            // sP_TBL_CLIENTE_LISTAR_REPORTE_JURIDICOTableAdapter
            // 
            this.sP_TBL_CLIENTE_LISTAR_REPORTE_JURIDICOTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteClientesJuridicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 516);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReporteClientesJuridicos";
            this.Text = "ReporteClientesJuridicos";
            this.Load += new System.EventHandler(this.ReporteClientesJuridicos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPTBLCLIENTELISTARREPORTEJURIDICOBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSetPrincipal dataSetPrincipal;
        private System.Windows.Forms.BindingSource sPTBLCLIENTELISTARREPORTEJURIDICOBindingSource;
        private DataSetPrincipalTableAdapters.SP_TBL_CLIENTE_LISTAR_REPORTE_JURIDICOTableAdapter sP_TBL_CLIENTE_LISTAR_REPORTE_JURIDICOTableAdapter;

    }
}