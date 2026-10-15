namespace Smartbike
{
    partial class historial
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
            this.regis = new System.Windows.Forms.DataGridView();
            this.codDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.artDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preciofDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eliteDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buscar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.regis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registroBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eliteDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // regis
            // 
            this.regis.AutoGenerateColumns = false;
            this.regis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.regis.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.regis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.regis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codDataGridViewTextBoxColumn,
            this.cantDataGridViewTextBoxColumn,
            this.artDataGridViewTextBoxColumn,
            this.itDataGridViewTextBoxColumn,
            this.preciofDataGridViewTextBoxColumn});
            this.regis.DataSource = this.registroBindingSource;
            this.regis.Location = new System.Drawing.Point(-5, 37);
            this.regis.Name = "regis";
            this.regis.RowHeadersVisible = false;
            this.regis.Size = new System.Drawing.Size(803, 415);
            this.regis.TabIndex = 0;
            this.regis.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.regis_CellClick);
            this.regis.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.regis_CellContentClick);
            this.regis.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.regis_CellDoubleClick);
            this.regis.DoubleClick += new System.EventHandler(this.regis_DoubleClick);
            // 
            // codDataGridViewTextBoxColumn
            // 
            this.codDataGridViewTextBoxColumn.DataPropertyName = "cod";
            this.codDataGridViewTextBoxColumn.HeaderText = "Codigo";
            this.codDataGridViewTextBoxColumn.Name = "codDataGridViewTextBoxColumn";
            // 
            // cantDataGridViewTextBoxColumn
            // 
            this.cantDataGridViewTextBoxColumn.DataPropertyName = "cant";
            this.cantDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantDataGridViewTextBoxColumn.Name = "cantDataGridViewTextBoxColumn";
            // 
            // artDataGridViewTextBoxColumn
            // 
            this.artDataGridViewTextBoxColumn.DataPropertyName = "art";
            this.artDataGridViewTextBoxColumn.HeaderText = "Articulo";
            this.artDataGridViewTextBoxColumn.Name = "artDataGridViewTextBoxColumn";
            // 
            // itDataGridViewTextBoxColumn
            // 
            this.itDataGridViewTextBoxColumn.DataPropertyName = "it";
            this.itDataGridViewTextBoxColumn.HeaderText = "Itbis";
            this.itDataGridViewTextBoxColumn.Name = "itDataGridViewTextBoxColumn";
            // 
            // preciofDataGridViewTextBoxColumn
            // 
            this.preciofDataGridViewTextBoxColumn.DataPropertyName = "preciof";
            this.preciofDataGridViewTextBoxColumn.HeaderText = "Precio final";
            this.preciofDataGridViewTextBoxColumn.Name = "preciofDataGridViewTextBoxColumn";
            // 
            // registroBindingSource
            // 
            this.registroBindingSource.DataMember = "registro";
            this.registroBindingSource.DataSource = this.eliteDataSet1BindingSource;
            // 
            // buscar
            // 
            this.buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscar.Location = new System.Drawing.Point(103, 7);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(278, 29);
            this.buscar.TabIndex = 1;
            this.buscar.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.buscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Buscar";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(30, 487);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(307, 29);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(113, 459);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Referencia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(603, 459);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ubicación";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(577, 487);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(190, 29);
            this.textBox2.TabIndex = 5;
            // 
            // historial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.ClientSize = new System.Drawing.Size(799, 526);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.regis);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximizeBox = false;
            this.Name = "historial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "historial";
            this.Load += new System.EventHandler(this.historial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.regis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registroBindingSource)).EndInit();
          //  ((System.ComponentModel.ISupportInitialize)(this.eliteDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView regis;
        private System.Windows.Forms.BindingSource eliteDataSet1BindingSource;
  //      private eliteDataSet1 eliteDataSet1;
 //       private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private System.Windows.Forms.BindingSource registroBindingSource;
 //       private eliteDataSet1TableAdapters.registroTableAdapter registroTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn codDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn artDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn preDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn preciofDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox buscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
    }
}