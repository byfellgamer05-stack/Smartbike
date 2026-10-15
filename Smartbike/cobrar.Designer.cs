namespace Smartbike
{
    partial class cobrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cobrar));
            this.totalf = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cr = new System.Windows.Forms.Button();
            this.paga = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cambio = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // totalf
            // 
            this.totalf.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalf.Location = new System.Drawing.Point(181, 331);
            this.totalf.Name = "totalf";
            this.totalf.Size = new System.Drawing.Size(436, 35);
            this.totalf.TabIndex = 0;
            this.totalf.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.totalf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.totalf_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(347, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(239, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(309, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // cr
            // 
            this.cr.BackColor = System.Drawing.Color.Gainsboro;
            this.cr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cr.Location = new System.Drawing.Point(657, 331);
            this.cr.Name = "cr";
            this.cr.Size = new System.Drawing.Size(104, 34);
            this.cr.TabIndex = 3;
            this.cr.Text = "Cobrar";
            this.cr.UseVisualStyleBackColor = false;
            this.cr.Click += new System.EventHandler(this.cr_Click);
            // 
            // paga
            // 
            this.paga.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paga.Location = new System.Drawing.Point(181, 156);
            this.paga.Name = "paga";
            this.paga.Size = new System.Drawing.Size(436, 35);
            this.paga.TabIndex = 4;
            this.paga.TextChanged += new System.EventHandler(this.paga_TextChanged);
            this.paga.KeyDown += new System.Windows.Forms.KeyEventHandler(this.paga_KeyDown);
            this.paga.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.paga_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(301, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Dinero recibido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(347, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Devuelta";
            // 
            // cambio
            // 
            this.cambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cambio.Location = new System.Drawing.Point(181, 243);
            this.cambio.Name = "cambio";
            this.cambio.Size = new System.Drawing.Size(436, 35);
            this.cambio.TabIndex = 6;
            this.cambio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cambio_KeyDown);
            // 
            // cobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 390);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cambio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.paga);
            this.Controls.Add(this.cr);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.totalf);
            this.MaximizeBox = false;
            this.Name = "cobrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "cobrar";
            this.Load += new System.EventHandler(this.cobrar_Load);
            this.Shown += new System.EventHandler(this.cobrar_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox totalf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button cr;
        private System.Windows.Forms.TextBox paga;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cambio;
    }
}