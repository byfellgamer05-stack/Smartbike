namespace Smartbike
{
    partial class Eliminar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Eliminar));
            this.numfac = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cua = new System.Windows.Forms.DataGridView();
            this.facturasBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.facturasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facturasBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.facturasBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // numfac
            // 
            this.numfac.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numfac.Location = new System.Drawing.Point(251, 53);
            this.numfac.Name = "numfac";
            this.numfac.Size = new System.Drawing.Size(236, 31);
            this.numfac.TabIndex = 0;
            this.numfac.TextChanged += new System.EventHandler(this.numfac_TextChanged);
            this.numfac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numfac_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(246, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Buscar numero de fac.";
            // 
            // cua
            // 
            this.cua.AllowUserToAddRows = false;
            this.cua.AllowUserToOrderColumns = true;
            this.cua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.cua.BackgroundColor = System.Drawing.Color.White;
            this.cua.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.cua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cua.Location = new System.Drawing.Point(12, 107);
            this.cua.Name = "cua";
            this.cua.RowHeadersVisible = false;
            this.cua.Size = new System.Drawing.Size(797, 242);
            this.cua.TabIndex = 47;
            this.cua.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cua_CellContentClick);
            // 
            // facturasBindingSource3
            // 
            this.facturasBindingSource3.DataMember = "facturas";
            // 
            // facturasBindingSource
            // 
            this.facturasBindingSource.DataMember = "facturas";
            // 
            // facturasBindingSource1
            // 
            this.facturasBindingSource1.DataMember = "facturas";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(650, 352);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 20);
            this.label11.TabIndex = 49;
            this.label11.Text = "Eliminar";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(640, 379);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(102, 50);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 48;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // facturasBindingSource2
            // 
            this.facturasBindingSource2.DataMember = "facturas";
            // 
            // Eliminar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.cua);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numfac);
            this.MaximizeBox = false;
            this.Name = "Eliminar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eliminar";
            this.Load += new System.EventHandler(this.Eliminar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox numfac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView cua;
   //     private eliteDataSet eliteDataSet;
        private System.Windows.Forms.BindingSource facturasBindingSource;
  //      private eliteDataSetTableAdapters.facturasTableAdapter facturasTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn numfaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
  //      private eliteDataSet1 eliteDataSet1;
        private System.Windows.Forms.BindingSource facturasBindingSource1;
     //   private eliteDataSet1TableAdapters.facturasTableAdapter facturasTableAdapter1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.BindingSource facturasBindingSource2;
        private System.Windows.Forms.BindingSource facturasBindingSource3;
    }
}