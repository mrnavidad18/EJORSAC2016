namespace SISJORSAC
{
    partial class FrmImprimirContrato
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
            this.SP_TBL_CONTRATO_IMPRIMIR_2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ConjuntoDatos = new SISJORSAC.ConjuntoDatos();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SP_TBL_CONTRATO_IMPRIMIR_2TableAdapter = new SISJORSAC.ConjuntoDatosTableAdapters.SP_TBL_CONTRATO_IMPRIMIR_2TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SP_TBL_CONTRATO_IMPRIMIR_2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConjuntoDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // SP_TBL_CONTRATO_IMPRIMIR_2BindingSource
            // 
            this.SP_TBL_CONTRATO_IMPRIMIR_2BindingSource.DataMember = "SP_TBL_CONTRATO_IMPRIMIR_2";
            this.SP_TBL_CONTRATO_IMPRIMIR_2BindingSource.DataSource = this.ConjuntoDatos;
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
            reportDataSource1.Value = this.SP_TBL_CONTRATO_IMPRIMIR_2BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SISJORSAC.Reportes.ImprimirContrato.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(795, 733);
            this.reportViewer1.TabIndex = 0;
            // 
            // SP_TBL_CONTRATO_IMPRIMIR_2TableAdapter
            // 
            this.SP_TBL_CONTRATO_IMPRIMIR_2TableAdapter.ClearBeforeFill = true;
            // 
            // FrmImprimirContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 733);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmImprimirContrato";
            this.Text = "FrmImprimirContrato";
            this.Load += new System.EventHandler(this.FrmImprimirContrato_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SP_TBL_CONTRATO_IMPRIMIR_2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConjuntoDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SP_TBL_CONTRATO_IMPRIMIR_2BindingSource;
        private ConjuntoDatos ConjuntoDatos;
        private ConjuntoDatosTableAdapters.SP_TBL_CONTRATO_IMPRIMIR_2TableAdapter SP_TBL_CONTRATO_IMPRIMIR_2TableAdapter;
    }
}