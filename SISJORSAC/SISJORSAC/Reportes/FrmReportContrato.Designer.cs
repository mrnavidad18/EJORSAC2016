namespace SISJORSAC
{
    partial class FrmReportContrato
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
            this.ConjuntoDatos = new SISJORSAC.ConjuntoDatos();
            this.SP_TBL_CONTRATO_REPORTEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SP_TBL_CONTRATO_REPORTETableAdapter = new SISJORSAC.ConjuntoDatosTableAdapters.SP_TBL_CONTRATO_REPORTETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ConjuntoDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_TBL_CONTRATO_REPORTEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SP_TBL_CONTRATO_REPORTEBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SISJORSAC.Reportes.ReporteContrato.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(755, 453);
            this.reportViewer1.TabIndex = 0;
            // 
            // ConjuntoDatos
            // 
            this.ConjuntoDatos.DataSetName = "ConjuntoDatos";
            this.ConjuntoDatos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SP_TBL_CONTRATO_REPORTEBindingSource
            // 
            this.SP_TBL_CONTRATO_REPORTEBindingSource.DataMember = "SP_TBL_CONTRATO_REPORTE";
            this.SP_TBL_CONTRATO_REPORTEBindingSource.DataSource = this.ConjuntoDatos;
            // 
            // SP_TBL_CONTRATO_REPORTETableAdapter
            // 
            this.SP_TBL_CONTRATO_REPORTETableAdapter.ClearBeforeFill = true;
            // 
            // FrmReportContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 453);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReportContrato";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmReportContrato";
            this.Load += new System.EventHandler(this.FrmReportContrato_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ConjuntoDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_TBL_CONTRATO_REPORTEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SP_TBL_CONTRATO_REPORTEBindingSource;
        private ConjuntoDatos ConjuntoDatos;
        private ConjuntoDatosTableAdapters.SP_TBL_CONTRATO_REPORTETableAdapter SP_TBL_CONTRATO_REPORTETableAdapter;
    }
}