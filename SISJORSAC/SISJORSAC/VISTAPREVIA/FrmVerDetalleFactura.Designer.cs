namespace SISJORSAC
{
    partial class FrmVerDetalleFactura
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
            this.SP_IMPRIMIR_FACTURABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ConjuntoDatos = new SISJORSAC.ConjuntoDatos();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SP_IMPRIMIR_FACTURATableAdapter = new SISJORSAC.ConjuntoDatosTableAdapters.SP_IMPRIMIR_FACTURATableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SP_IMPRIMIR_FACTURABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConjuntoDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // SP_IMPRIMIR_FACTURABindingSource
            // 
            this.SP_IMPRIMIR_FACTURABindingSource.DataMember = "SP_IMPRIMIR_FACTURA";
            this.SP_IMPRIMIR_FACTURABindingSource.DataSource = this.ConjuntoDatos;
            // 
            // ConjuntoDatos
            // 
            this.ConjuntoDatos.DataSetName = "ConjuntoDatos";
            this.ConjuntoDatos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SP_IMPRIMIR_FACTURABindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SISJORSAC.VISTAPREVIA.RptImprimirFactura.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(864, 561);
            this.reportViewer1.TabIndex = 0;
            // 
            // SP_IMPRIMIR_FACTURATableAdapter
            // 
            this.SP_IMPRIMIR_FACTURATableAdapter.ClearBeforeFill = true;
            // 
            // FrmVerDetalleFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 561);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmVerDetalleFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVerDetalleFactura";
            this.Load += new System.EventHandler(this.FrmVerDetalleFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SP_IMPRIMIR_FACTURABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConjuntoDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SP_IMPRIMIR_FACTURABindingSource;
        private ConjuntoDatos ConjuntoDatos;
        private ConjuntoDatosTableAdapters.SP_IMPRIMIR_FACTURATableAdapter SP_IMPRIMIR_FACTURATableAdapter;
    }
}