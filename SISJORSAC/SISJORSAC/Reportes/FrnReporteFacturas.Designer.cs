namespace SISJORSAC
{
    partial class FrnReporteFacturas
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
            this.SP_TBL_FACTURA_BUSCAR_X_FECHASBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SP_TBL_FACTURA_BUSCAR_X_FECHASTableAdapter = new SISJORSAC.ConjuntoDatosTableAdapters.SP_TBL_FACTURA_BUSCAR_X_FECHASTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ConjuntoDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_TBL_FACTURA_BUSCAR_X_FECHASBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SP_TBL_FACTURA_BUSCAR_X_FECHASBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SISJORSAC.Reportes.RtpInformeFacturas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(708, 508);
            this.reportViewer1.TabIndex = 0;
            // 
            // ConjuntoDatos
            // 
            this.ConjuntoDatos.DataSetName = "ConjuntoDatos";
            this.ConjuntoDatos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SP_TBL_FACTURA_BUSCAR_X_FECHASBindingSource
            // 
            this.SP_TBL_FACTURA_BUSCAR_X_FECHASBindingSource.DataMember = "SP_TBL_FACTURA_BUSCAR_X_FECHAS";
            this.SP_TBL_FACTURA_BUSCAR_X_FECHASBindingSource.DataSource = this.ConjuntoDatos;
            // 
            // SP_TBL_FACTURA_BUSCAR_X_FECHASTableAdapter
            // 
            this.SP_TBL_FACTURA_BUSCAR_X_FECHASTableAdapter.ClearBeforeFill = true;
            // 
            // FrnReporteFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 508);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrnReporteFacturas";
            this.Text = "FrnReporteFacturas";
            this.Load += new System.EventHandler(this.FrnReporteFacturas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ConjuntoDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_TBL_FACTURA_BUSCAR_X_FECHASBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SP_TBL_FACTURA_BUSCAR_X_FECHASBindingSource;
        private ConjuntoDatos ConjuntoDatos;
        private ConjuntoDatosTableAdapters.SP_TBL_FACTURA_BUSCAR_X_FECHASTableAdapter SP_TBL_FACTURA_BUSCAR_X_FECHASTableAdapter;
    }
}