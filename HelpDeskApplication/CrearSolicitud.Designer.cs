namespace HelpDeskApplication
{
    partial class frmCrearSolicitud
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCrearSolicitud));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rtxtDetalleSolicitud = new System.Windows.Forms.RichTextBox();
            this.txtSolicitante = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDepartamentos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNuevoCS = new System.Windows.Forms.ToolStripButton();
            this.btnEditaCS = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarCS = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGuardarCS = new System.Windows.Forms.ToolStripButton();
            this.btnCancelarCS = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.rtxtDetalleSolicitud);
            this.groupBox1.Controls.Add(this.txtSolicitante);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbDepartamentos);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(11, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(917, 319);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Solicitud de Servicio";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Detalle de la Solicitud";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(654, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // rtxtDetalleSolicitud
            // 
            this.rtxtDetalleSolicitud.Location = new System.Drawing.Point(22, 112);
            this.rtxtDetalleSolicitud.Name = "rtxtDetalleSolicitud";
            this.rtxtDetalleSolicitud.Size = new System.Drawing.Size(626, 178);
            this.rtxtDetalleSolicitud.TabIndex = 7;
            this.rtxtDetalleSolicitud.Text = "";
            // 
            // txtSolicitante
            // 
            this.txtSolicitante.BackColor = System.Drawing.Color.Gainsboro;
            this.txtSolicitante.Enabled = false;
            this.txtSolicitante.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSolicitante.Location = new System.Drawing.Point(354, 53);
            this.txtSolicitante.Name = "txtSolicitante";
            this.txtSolicitante.Size = new System.Drawing.Size(294, 26);
            this.txtSolicitante.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(350, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Solicitante";
            // 
            // cbDepartamentos
            // 
            this.cbDepartamentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDepartamentos.FormattingEnabled = true;
            this.cbDepartamentos.Location = new System.Drawing.Point(27, 51);
            this.cbDepartamentos.Name = "cbDepartamentos";
            this.cbDepartamentos.Size = new System.Drawing.Size(263, 28);
            this.cbDepartamentos.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Depto. Destino";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevoCS,
            this.btnEditaCS,
            this.btnEliminarCS,
            this.toolStripSeparator1,
            this.btnGuardarCS,
            this.btnCancelarCS});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(940, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNuevoCS
            // 
            this.btnNuevoCS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNuevoCS.Enabled = false;
            this.btnNuevoCS.Image = global::HelpDeskApplication.Properties.Resources.if_free_10_463016;
            this.btnNuevoCS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevoCS.Name = "btnNuevoCS";
            this.btnNuevoCS.Size = new System.Drawing.Size(28, 28);
            this.btnNuevoCS.Text = "toolStripButton1";
            // 
            // btnEditaCS
            // 
            this.btnEditaCS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditaCS.Enabled = false;
            this.btnEditaCS.Image = global::HelpDeskApplication.Properties.Resources.if_edit_173002;
            this.btnEditaCS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditaCS.Name = "btnEditaCS";
            this.btnEditaCS.Size = new System.Drawing.Size(28, 28);
            this.btnEditaCS.Text = "toolStripButton2";
            // 
            // btnEliminarCS
            // 
            this.btnEliminarCS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminarCS.Enabled = false;
            this.btnEliminarCS.Image = global::HelpDeskApplication.Properties.Resources.if_free_27_616650;
            this.btnEliminarCS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarCS.Name = "btnEliminarCS";
            this.btnEliminarCS.Size = new System.Drawing.Size(28, 28);
            this.btnEliminarCS.Text = "toolStripButton1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btnGuardarCS
            // 
            this.btnGuardarCS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGuardarCS.Image = global::HelpDeskApplication.Properties.Resources.if_floppy_285657;
            this.btnGuardarCS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardarCS.Name = "btnGuardarCS";
            this.btnGuardarCS.Size = new System.Drawing.Size(28, 28);
            this.btnGuardarCS.Text = "toolStripButton4";
            this.btnGuardarCS.Click += new System.EventHandler(this.btnGuardarCS_Click);
            // 
            // btnCancelarCS
            // 
            this.btnCancelarCS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCancelarCS.Enabled = false;
            this.btnCancelarCS.Image = global::HelpDeskApplication.Properties.Resources.if_free_09_463017;
            this.btnCancelarCS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelarCS.Name = "btnCancelarCS";
            this.btnCancelarCS.Size = new System.Drawing.Size(28, 28);
            this.btnCancelarCS.Text = "toolStripButton5";
            // 
            // frmCrearSolicitud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(940, 365);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCrearSolicitud";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CrearSolicitud";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCrearSolicitud_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSolicitante;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbDepartamentos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox rtxtDetalleSolicitud;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNuevoCS;
        private System.Windows.Forms.ToolStripButton btnEditaCS;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnGuardarCS;
        private System.Windows.Forms.ToolStripButton btnCancelarCS;
        private System.Windows.Forms.ToolStripButton btnEliminarCS;
    }
}