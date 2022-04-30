
namespace SistemaDeInventarioOD.Vistas.Opciones.Secundarias
{
    partial class BuscarAlmacenSecundaria
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnVolverMenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(472, 467);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnVolverMenu
            // 
            this.btnVolverMenu.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnVolverMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolverMenu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVolverMenu.Image = global::SistemaDeInventarioOD.Properties.Resources.previous;
            this.btnVolverMenu.Location = new System.Drawing.Point(13, 12);
            this.btnVolverMenu.Name = "btnVolverMenu";
            this.btnVolverMenu.Size = new System.Drawing.Size(64, 64);
            this.btnVolverMenu.TabIndex = 6;
            this.btnVolverMenu.UseVisualStyleBackColor = false;
            // 
            // BuscarAlmacenSecundaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(496, 561);
            this.Controls.Add(this.btnVolverMenu);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(512, 600);
            this.MinimumSize = new System.Drawing.Size(512, 600);
            this.Name = "BuscarAlmacenSecundaria";
            this.Text = "BuscarAlmacenSecundaria";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnVolverMenu;
    }
}