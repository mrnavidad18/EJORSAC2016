namespace SISJORSAC
{
    partial class FrmVerDetalleBoleta
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
            this.SP_TBL_BOLETA_IMPRIMIRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ConjuntoDatos = new SISJORSAC.ConjuntoDatos();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SP_TBL_BOLETA_IMPRIMIRTableAdapter = new SISJORSAC.ConjuntoDatosTableAdapters.SP_TBL_BOLETA_IMPRIMIRTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SP_TBL_BOLETA_IMPRIMIRBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConjuntoDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // SP_TBL_BOLETA_IMPRIMIRBindingSource
            // 
            this.SP_TBL_BOLETA_IMPRIMIRBindingSource.DataMember = "SP_TBL_BOLETA_IMPRIMIR";
            this.SP_TBL_BOLETA_IMPRIMIRBindingSource.DataSource = this.ConjuntoDatos;
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
            reportDataSource1.Value = this.SP_TBL_BOLETA_IMPRIMIRBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SISJORSAC.VISTAPREVIA.RptImprimirBoleta.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(738, 556);
            this.reportViewer1.TabIndex = 0;
            // 
            // SP_TBL_BOLETA_IMPRIMIRTableAdapter
            // 
            this.SP_TBL_BOLETA_IMPRIMIRTableAdapter.ClearBeforeFill = true;
            // 
            // FrmVerDetalleBoleta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 556);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmVerDetalleBoleta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVerDetalleBoleta";
            this.Load += new System.EventHandler(this.FrmVerDetalleBoleta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SP_TBL_BOLETA_IMPRIMIRBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConjuntoDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SP_TBL_BOLETA_IMPRIMIRBindingSource;
        private ConjuntoDatos ConjuntoDatos;
        private ConjuntoDatosTableAdapters.SP_TBL_BOLETA_IMPRIMIRTableAdapter SP_TBL_BOLETA_IMPRIMIRTableAdapter;
    }
}