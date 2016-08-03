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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteClientesJuridicos));
            this.sPTBLCLIENTELISTARREPORTEJURIDICOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sP_TBL_CLIENTE_LISTAR_REPORTE_JURIDICOTableAdapter = new SISJORSAC.DataSetPrincipalTableAdapters.SP_TBL_CLIENTE_LISTAR_REPORTE_JURIDICOTableAdapter();
            this.dataSetPrincipal = new SISJORSAC.DataSetPrincipal();
            ((System.ComponentModel.ISupportInitialize)(this.sPTBLCLIENTELISTARREPORTEJURIDICOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // sPTBLCLIENTELISTARREPORTEJURIDICOBindingSource
            // 
            this.sPTBLCLIENTELISTARREPORTEJURIDICOBindingSource.DataMember = "SP_TBL_CLIENTE_LISTAR_REPORTE_JURIDICO";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.DocumentMapWidth = 15;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sPTBLCLIENTELISTARREPORTEJURIDICOBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SISJORSAC.Reportes.InformeClientesJuridicos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1014, 616);
            this.reportViewer1.TabIndex = 0;
            // 
            // sP_TBL_CLIENTE_LISTAR_REPORTE_JURIDICOTableAdapter
            // 
            this.sP_TBL_CLIENTE_LISTAR_REPORTE_JURIDICOTableAdapter.ClearBeforeFill = true;
            // 
            // dataSetPrincipal
            // 
            this.dataSetPrincipal.DataSetName = "DataSetPrincipal";
            this.dataSetPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ReporteClientesJuridicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1014, 616);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReporteClientesJuridicos";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ReporteClientesJuridicos";
            this.TransparencyKey = System.Drawing.Color.Blue;
            this.Load += new System.EventHandler(this.ReporteClientesJuridicos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sPTBLCLIENTELISTARREPORTEJURIDICOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPrincipal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sPTBLCLIENTELISTARREPORTEJURIDICOBindingSource;
        private DataSetPrincipalTableAdapters.SP_TBL_CLIENTE_LISTAR_REPORTE_JURIDICOTableAdapter sP_TBL_CLIENTE_LISTAR_REPORTE_JURIDICOTableAdapter;
        private DataSetPrincipal dataSetPrincipal;

    }
}