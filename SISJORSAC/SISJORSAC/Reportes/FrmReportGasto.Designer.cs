namespace SISJORSAC
{
    partial class FrmReportGasto
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
            this.SP_REPORTE_GASTOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SP_REPORTE_GASTOSTableAdapter = new SISJORSAC.ConjuntoDatosTableAdapters.SP_REPORTE_GASTOSTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ConjuntoDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_REPORTE_GASTOSBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SP_REPORTE_GASTOSBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SISJORSAC.Reportes.ReportGasto.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(782, 441);
            this.reportViewer1.TabIndex = 0;
            // 
            // ConjuntoDatos
            // 
            this.ConjuntoDatos.DataSetName = "ConjuntoDatos";
            this.ConjuntoDatos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SP_REPORTE_GASTOSBindingSource
            // 
            this.SP_REPORTE_GASTOSBindingSource.DataMember = "SP_REPORTE_GASTOS";
            this.SP_REPORTE_GASTOSBindingSource.DataSource = this.ConjuntoDatos;
            // 
            // SP_REPORTE_GASTOSTableAdapter
            // 
            this.SP_REPORTE_GASTOSTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReportGasto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 441);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReportGasto";
            this.Text = "FrmReportGasto";
            this.Load += new System.EventHandler(this.FrmReportGasto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ConjuntoDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_REPORTE_GASTOSBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SP_REPORTE_GASTOSBindingSource;
        private ConjuntoDatos ConjuntoDatos;
        private ConjuntoDatosTableAdapters.SP_REPORTE_GASTOSTableAdapter SP_REPORTE_GASTOSTableAdapter;
    }
}