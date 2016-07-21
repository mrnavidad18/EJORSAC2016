namespace SISJORSAC.Reportes
{
    partial class Tipo_de_Clientes
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
            this.cboClienteReporte = new System.Windows.Forms.ComboBox();
            this.btnReporteClientes = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboClienteReporte
            // 
            this.cboClienteReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClienteReporte.FormattingEnabled = true;
            this.cboClienteReporte.Items.AddRange(new object[] {
            "---SELECIONAR--",
            "NATURAL",
            "JURIDICA",
            "TODOS"});
            this.cboClienteReporte.Location = new System.Drawing.Point(135, 38);
            this.cboClienteReporte.Name = "cboClienteReporte";
            this.cboClienteReporte.Size = new System.Drawing.Size(176, 21);
            this.cboClienteReporte.TabIndex = 0;
            // 
            // btnReporteClientes
            // 
            this.btnReporteClientes.Location = new System.Drawing.Point(93, 75);
            this.btnReporteClientes.Name = "btnReporteClientes";
            this.btnReporteClientes.Size = new System.Drawing.Size(123, 34);
            this.btnReporteClientes.TabIndex = 1;
            this.btnReporteClientes.Text = "Ver Reporte";
            this.btnReporteClientes.UseVisualStyleBackColor = true;
            this.btnReporteClientes.Click += new System.EventHandler(this.btnReporteClientes_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Elegir Clientes";
            // 
            // Tipo_de_Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 121);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReporteClientes);
            this.Controls.Add(this.cboClienteReporte);
            this.Name = "Tipo_de_Clientes";
            this.Text = "Tipo_de_Clientes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboClienteReporte;
        private System.Windows.Forms.Button btnReporteClientes;
        private System.Windows.Forms.Label label1;
    }
}